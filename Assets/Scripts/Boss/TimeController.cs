using System;
using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public GameObject player;
    public GameObject showPositionPrefeb;
    public GameObject showRepPrefeb;
    public GameObject representativeObj;
    public GameObject forceDirArrow;
    public float cdTime = 10.0f;
    public float lenOfRecord_s = 5.0f; // (s)
    public float frequence_s = 0.1f; // (s)
    public float forceStrength = 300;
    public int ghostRelicNum = 10;
    public float turnBackTimeWidth = 0.1f;

    public static bool pressT;

    private Animator playerAnim;
    private bool isTurningBackTheClock;
    private float curTime;
    private float nextTime;
    private float startTime;
    private float endTime;
    private float nextTimeInTurningBack;
    private Vector3[] pastPosition;
    private Quaternion[] pastRotation;
    private int[] pastAnimationHash;
    private GameObject[] showedPosPrefeb;
    private GameObject[] showedRepPrefeb;
    private int showedCurPosCounter;
    private int pastPosIndex;
    private int timePosIndex;
    private int totalNumOfPos;
    private Vector3 velocity;
    private Vector3 bias = new Vector3(0, 0.9f, 0);


    // Start is called before the first frame update
    void Start()
    {
        playerAnim = player.GetComponent<Animator>();
        representativeObj.SetActive(false);
        curTime = Time.time;
        startTime = endTime = 0.0f;
        nextTime = curTime + frequence_s;
        pastPosIndex = 0;
        isTurningBackTheClock = false;
        totalNumOfPos = (int)(lenOfRecord_s / frequence_s);
        Debug.Log("totalNumOfPos = " + totalNumOfPos);
        pastPosition = new Vector3[totalNumOfPos];
        pastRotation = new Quaternion[totalNumOfPos];
        pastAnimationHash = new int[totalNumOfPos];
        showedPosPrefeb = new GameObject[totalNumOfPos];
        showedRepPrefeb = new GameObject[totalNumOfPos];
    }

    // Update is called once per frame
    void Update()
    {
        
        curTime = Time.time;
        if (curTime >= nextTime)
        {
            nextTime += frequence_s;
            if (!isTurningBackTheClock)
            {
                pastPosition[pastPosIndex] = player.transform.position;
                pastRotation[pastPosIndex] = player.transform.rotation;
                pastAnimationHash[pastPosIndex] = playerAnim.GetCurrentAnimatorStateInfo(0).fullPathHash;

                pastPosIndex = (pastPosIndex + 1) % totalNumOfPos;
            }
        }

        if (pressT)
        {
            //Debug.Log("keydown T, " + (curTime > startTime + 0.1f));
            pressT = false;
            if ((curTime > startTime + 0.1f) && (isTurningBackTheClock))
            {
                //Debug.Log("turn off time controller");
                isTurningBackTheClock = false;
                InactivePrefebs();

                // 改變 player 的位置
                player.transform.position = pastPosition[timePosIndex];

                // 增加作用力
                Vector3 curPos = pastPosition[timePosIndex];
                int preIndex = (timePosIndex - 1 < 0) ? (totalNumOfPos - 1) : (timePosIndex - 1);
                Vector3 prePos = pastPosition[preIndex];
                player.GetComponent<ImpactReceiver>().AddImpact((prePos - curPos), Vector3.Distance(curPos, prePos) * forceStrength);
                Debug.Log("curPos = " + curPos + ", prePos = " + prePos + ", forceDir = " + (prePos - curPos));

                // Delete all showPos prefeb
                DestoryPosPrefeb();

                // 改變面向
                player.transform.rotation = pastRotation[timePosIndex];

                // 開放操作
                UCanMove();
            }
            else if (curTime > endTime + cdTime)
            {
                isTurningBackTheClock = true;
                ActivePrefebs();

                // 停止操作
                UCanNOTMove();

                // Show all prePos
                ShowPosPrefeb();

                startTime = curTime;
                endTime = curTime + cdTime + 0.01f;
                nextTimeInTurningBack = curTime + frequence_s;
                timePosIndex = (pastPosIndex - 1 < 0) ? (totalNumOfPos - 1) : (pastPosIndex - 1);
                showedCurPosCounter = 0;
                //Debug.Log("stratTime = " + startTime + ", endTime = " + endTime);
            }

        }

        if (isTurningBackTheClock)
        {
            //Debug.Log("isTurningBackTheClock");
            if (curTime >= nextTimeInTurningBack)
            {
                Debug.Log("curPrePosIdx = " + timePosIndex + ", showedCurPosCounter = " + showedCurPosCounter);
                nextTimeInTurningBack += turnBackTimeWidth;

                // Show Player_rep
                representativeObj.transform.position = Vector3.SmoothDamp(representativeObj.transform.position, pastPosition[timePosIndex], ref velocity, turnBackTimeWidth/10);
                representativeObj.transform.rotation = pastRotation[timePosIndex];
                Player_repAnimation.curStateHash = pastAnimationHash[timePosIndex];
                Player_repAnimation.PlayPlayer_repAnimation = true;

                // Show force direction arrow
                if (showedCurPosCounter < totalNumOfPos - 1)
                {
                    forceDirArrow.transform.position = Vector3.SmoothDamp(forceDirArrow.transform.position, pastPosition[timePosIndex] + bias, ref velocity, turnBackTimeWidth/10);
                    int nextIdx = (timePosIndex - 1 < 0) ? (totalNumOfPos - 1) : (timePosIndex - 1);
                    forceDirArrow.transform.rotation = Quaternion.LookRotation(pastPosition[nextIdx] - representativeObj.transform.position);
                }

                // Show ghost relic
                if (showedCurPosCounter > 0)
                {
                    int preIdx = ((timePosIndex + 1) % totalNumOfPos);
                    showedRepPrefeb[showedCurPosCounter - 1] = Instantiate(showRepPrefeb, pastPosition[preIdx], Quaternion.identity);
                    showedRepPrefeb[showedCurPosCounter - 1].transform.rotation = pastRotation[preIdx];
                    showedRepPrefeb[showedCurPosCounter - 1].GetComponent<Animator>().enabled = true;
                    showedRepPrefeb[showedCurPosCounter - 1].GetComponent<Animator>().Play(pastAnimationHash[preIdx]);
                    if(showedCurPosCounter > 1)
                        showedRepPrefeb[showedCurPosCounter - 2].GetComponent<Animator>().enabled = false;
                    if (showedCurPosCounter >= ghostRelicNum)
                        Destroy(showedRepPrefeb[showedCurPosCounter - ghostRelicNum]);
                }
                showedCurPosCounter++;


                timePosIndex = (timePosIndex - 1 < 0) ? (totalNumOfPos - 1) : (timePosIndex - 1);
                if (timePosIndex == pastPosIndex)
                {
                    //Debug.Log("last position");
                    isTurningBackTheClock = false;
                    InactivePrefebs();

                    // Delete all showPos prefeb
                    DestoryPosPrefeb();

                    // 開放操作
                    UCanMove();
                }
            }
        }

    }

    void UCanMove()
    {
        //Debug.Log("U can move! But U didn't use the ability of time-control.");
        player.GetComponent<CharacterController>().enabled = true;
        player.GetComponent<Animator>().enabled = true;
        player.GetComponent<Collider>().enabled = true;
        player.GetComponent<Rigidbody>().WakeUp();
    }

    void UCanNOTMove()
    {
        //Debug.Log("U can not move...");
        player.GetComponent<CharacterController>().enabled = false;
        player.GetComponent<Animator>().enabled = false;
        player.GetComponent<Collider>().enabled = false;
        player.GetComponent<Rigidbody>().Sleep();
    }

    void ShowPosPrefeb()
    {
        //Debug.Log("Show Pos.");
        showedPosPrefeb[0] = Instantiate(showPositionPrefeb, pastPosition[0] + new Vector3(0, 0.5f, 0), Quaternion.identity);
        for (int i = 1; i < totalNumOfPos; i++)
        {
            //Debug.Log("Put prefab on position " + pastPosition[i] + ". Hash Idx of animation is " + pastAnimationIdx[i]);
            showedPosPrefeb[i] = Instantiate(showPositionPrefeb, pastPosition[i] + new Vector3(0, 0.5f, 0), Quaternion.identity);
        }
    }

    void DestoryPosPrefeb()
    {
        for (int i = 0; i < totalNumOfPos; i++)
        {
            Destroy(showedPosPrefeb[i]);
            if (showedRepPrefeb[i] != null)
            {
                Destroy(showedRepPrefeb[i]);
            }
        }
    }

    void ActivePrefebs()
    {
        representativeObj.transform.position = pastPosition[((pastPosIndex - 1) % totalNumOfPos)];
        representativeObj.transform.rotation = pastRotation[((pastPosIndex - 1) % totalNumOfPos)];
        representativeObj.SetActive(true);
        forceDirArrow.transform.position = pastPosition[((pastPosIndex - 1) % totalNumOfPos)];
        forceDirArrow.transform.rotation = pastRotation[((pastPosIndex - 1) % totalNumOfPos)];
        forceDirArrow.SetActive(true);
    }

    void InactivePrefebs()
    {
        representativeObj.SetActive(false);
        forceDirArrow.SetActive(false);
    }
}
