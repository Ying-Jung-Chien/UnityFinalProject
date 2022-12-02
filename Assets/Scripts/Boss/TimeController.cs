using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public GameObject player;
    //public GameObject showPositionPrefeb;
    public GameObject representativeObj;
    public float cdTime = 10.0f;
    public float lenOfRecord_s = 5.0f; // (s)
    public float frequence_s = 0.1f; // (s)
    public float forceStrength = 300;

    public static bool pressT;

    private bool isTurningBackTheClock;
    private float curTime;
    private float nextTime;
    private float startTime;
    private float endTime;
    private float nextTimeInTurningBack;
    private Vector3[] pastPosition;
    private Quaternion[] pastRotation;
    private int pastPosIndex;
    private int timePosIndex;
    private int totalNumOfPos;

    // Start is called before the first frame update
    void Start()
    {
        representativeObj.SetActive(false);
        curTime = Time.time;
        startTime = endTime = 0.0f;
        nextTime = curTime + frequence_s;
        pastPosIndex = 0;
        isTurningBackTheClock = false;
        totalNumOfPos = (int)(lenOfRecord_s / frequence_s);
        pastPosition = new Vector3[totalNumOfPos];
        pastRotation = new Quaternion[totalNumOfPos];
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
                pastRotation[pastPosIndex] = player.transform.rotation;
                pastPosIndex = (pastPosIndex + 1) % totalNumOfPos;
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
                player.transform.position = pastPosition[timePosIndex];

                // 增加作用力
                Vector3 curPos = pastPosition[timePosIndex];
                int preIndex = (timePosIndex - 1 < 0) ? (totalNumOfPos - 1) : (timePosIndex - 1);
                Vector3 prePos = pastPosition[preIndex];
                player.GetComponent<ImpactReceiver>().AddImpact((prePos - curPos), Vector3.Distance(curPos, prePos) * forceStrength);
                Debug.Log("curPos = " + curPos + ", prePos = " + prePos + ", forceDir = " + (prePos - curPos));

                // 改變面向
                player.transform.rotation = pastRotation[timePosIndex];

                // 開放操作
                player.GetComponent<CharacterController>().enabled = true;
                player.GetComponent<Animator>().enabled = true;
            }
            else if (curTime > endTime + cdTime)
            {
                Debug.Log("turn on time controller");
                representativeObj.transform.position = pastPosition[((pastPosIndex - 1) % totalNumOfPos)];
                representativeObj.transform.rotation = pastRotation[((pastPosIndex - 1) % totalNumOfPos)];
                representativeObj.SetActive(true);

                // 停止操作
                player.GetComponent<CharacterController>().enabled = false;
                player.GetComponent<Animator>().enabled = false;

                //for(int i = 0; i < 50; i++)
                //{
                //    int curIdx = (pastPosIndex + i) % 50;
                //    Instantiate(showPositionPrefeb, pastPosition[curIdx], showPositionPrefeb.transform.rotation);
                //}

                isTurningBackTheClock = true;
                startTime = curTime;
                endTime = curTime + lenOfRecord_s;
                nextTimeInTurningBack = curTime + frequence_s;
                timePosIndex = (pastPosIndex - 1 < 0) ? (totalNumOfPos - 1) : (pastPosIndex - 1);
                Debug.Log("stratTime = " + startTime + ", endTime = " + endTime);
            }

        }

        if (isTurningBackTheClock)
        {
            Debug.Log("isTurningBackTheClock");
            if(curTime >= nextTimeInTurningBack)
            {
                Debug.Log("next position");
                nextTimeInTurningBack += frequence_s;

                representativeObj.transform.position = pastPosition[timePosIndex];// + new Vector3(0, 0.9f, 0);
                representativeObj.transform.rotation = pastRotation[timePosIndex];
                //player.transform.position = pastPosition[timePosIndex];

                timePosIndex = (timePosIndex - 1 < 0) ? (totalNumOfPos - 1) : (timePosIndex - 1);
                if (timePosIndex == pastPosIndex)
                {
                    Debug.Log("last position");
                    isTurningBackTheClock = false;
                    representativeObj.SetActive(false);

                    // 開放操作
                    player.GetComponent<CharacterController>().enabled = true;
                    player.GetComponent<Animator>().enabled = true;
                }
            }
        }
        
    }
}
