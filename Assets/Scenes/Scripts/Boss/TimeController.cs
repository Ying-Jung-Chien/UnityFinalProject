using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public GameObject player;
    public GameObject showPositionPrefeb;
    public GameObject representativeObj;
    public float cdTime = 10.0f;

    public static float _cdTime;
    public static bool pressT;
    public static bool isTurningBackTheClock;
    public static float curTime;
    public static float nextTime;
    public static float startTime;
    public static float endTime;

    private float nextTimeInTurningBack;
    private Vector3[] pastPosition = new Vector3[50];
    private int pastPosIndex;
    private int timePosIndex;
    //private bool isTurningBackTheClock;
    

    // Start is called before the first frame update
    void Start()
    {
        _cdTime = cdTime;
        representativeObj.SetActive(false);
        curTime = Time.time;
        startTime = endTime = 0.0f;
        nextTime = curTime + 0.1f;
        pastPosIndex = 0;
        isTurningBackTheClock = false;
    }

    // Update is called once per frame
    void Update()
    {
        curTime = Time.time;
        if (curTime >= nextTime)
        {
            nextTime += 0.1f;
            if (!isTurningBackTheClock)
            {
                pastPosition[pastPosIndex] = player.transform.position;
                pastPosIndex = (pastPosIndex + 1) % 50;
            }
            /*
            string tmp = "";
            foreach (var vec in pastPosition)
            {
                tmp += vec.ToString();
            }
            Debug.Log(tmp);
            */
        }
        

        
        //if(Input.GetKeyDown(KeyCode.T))
        if(pressT)
        {
            Debug.Log("keydown T, " + (curTime > startTime + 0.1f));
            pressT = false;
            if ((curTime > startTime + 0.1f) && (isTurningBackTheClock))
            {
                Debug.Log("turn off time controller");
                isTurningBackTheClock = false;
                representativeObj.SetActive(false);

                // 改變 player 的位置
                player.GetComponent<CharacterController>().enabled = false;
                player.transform.position = pastPosition[timePosIndex];
                player.GetComponent<CharacterController>().enabled = true;
                

                // 增加作用力
                Vector3 curPos = pastPosition[timePosIndex];
                Vector3 prePos = pastPosition[(timePosIndex - 1 < 0 ? 49 : (pastPosIndex - 1))];
                player.GetComponent<ImpactReceiver>().AddImpact((curPos-prePos), Vector3.Distance(curPos, prePos) * 30);
            }
            else if (curTime > endTime + cdTime)
            {
                Debug.Log("turn on time controller");
                representativeObj.transform.position = pastPosition[((pastPosIndex - 1) % 50)];
                representativeObj.SetActive(true);
                //for(int i = 0; i < 50; i++)
                //{
                //    int curIdx = (pastPosIndex + i) % 50;
                //    Instantiate(showPositionPrefeb, pastPosition[curIdx], showPositionPrefeb.transform.rotation);
                //}
                isTurningBackTheClock = true;
                startTime = curTime;
                endTime = curTime + 5.0f;
                nextTimeInTurningBack = curTime + 0.1f;
                timePosIndex = (pastPosIndex - 1 < 0) ? 49 : (pastPosIndex - 1);
                Debug.Log("stratTime = " + startTime + ", endTime = " + endTime);
            }

        }

        if (isTurningBackTheClock)
        {
            Debug.Log("isTurningBackTheClock");
            if(curTime >= nextTimeInTurningBack)
            {
                Debug.Log("next position");
                nextTimeInTurningBack += 0.1f;

                representativeObj.transform.position = pastPosition[timePosIndex] + new Vector3(0, 0.9f, 0);
                //player.transform.position = pastPosition[timePosIndex];
                //Debug.Log("tragetPos: " + pastPosition[timePosIndex]);

                timePosIndex = (timePosIndex - 1 < 0) ? 49 : (timePosIndex - 1);
                if (timePosIndex == pastPosIndex)
                {
                    Debug.Log("last position");
                    isTurningBackTheClock = false;
                    representativeObj.SetActive(false);
                    player.SetActive(true);
                }
            }
        }
        
    }
}
