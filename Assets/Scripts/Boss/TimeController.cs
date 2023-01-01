using System;
using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public Camera mainCamera;
    public Camera timeRepCamera;
    public Camera lightRepCamera;
    public GameObject player;
    public GameObject blackDragon;
    public GameObject showRepPrefab;
    public GameObject representativeObj;
    public GameObject repLightObj;
    public GameObject forceDirArrow;
    public float cdTime = 10.0f;
    public float lenOfRecord_s = 5.0f; // (s)
    public float frequence_s = 0.1f; // (s)
    public float forceStrength = 300;
    public float turnBackTimeWidth = 0.1f;
    public float ejectDelay_s = 0.5f;
    public float switchDelay_s = 1.0f;
    public int shoePosRepDensity = 5;

    public static bool pressT = false;
    public static bool isInvincibleState = false;

    private static Vector3 _initPlayerPos;
    private static Animator playerAnim;
    private static bool goStorePos;
    private static bool isTurningBackTheClock;
    private static float curTime;
    private static float nextTime;
    private static float tmp;
    private static float startTime;
    private static float endTime;
    private static float nextTimeInTurningBack;
    private static Vector3[] pastPosition;
    private static Quaternion[] pastRotation;
    private static int[] pastAnimationHash;
    private static GameObject[] showedRepPrefab;
    private static GameObject showedPreLightPrefab;
    private static int showedCurPosCounter;
    private static int pastPosIndex;
    private static int timePosIndex;
    private static int totalNumOfPos;
    private static Vector3 velocity;
    private static Vector3 bias = new Vector3(0, 0.9f, 0);
    private static bool playerRepLightScale = false;
    private bool playRepAnimation = false;
    private float nextRepTime = 0f;
    private int curRepIdx = 0;
    private int repCounter = 0;

    void InitArrays()
    {
        for(int i = 0; i< totalNumOfPos; i++)
            pastPosition[i] = new Vector3(0, 0, 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        _initPlayerPos = player.transform.position;
        playerAnim = player.GetComponent<Animator>();
        representativeObj.SetActive(false);
        curTime = Time.time;
        startTime = endTime = 0.0f;
        nextTime = curTime + frequence_s;
        pastPosIndex = 0;
        goStorePos = true;
        isTurningBackTheClock = false;
        totalNumOfPos = (int)(lenOfRecord_s / frequence_s);
        Debug.Log("totalNumOfPos = " + totalNumOfPos);
        pastPosition = new Vector3[totalNumOfPos];
        pastRotation = new Quaternion[totalNumOfPos];
        pastAnimationHash = new int[totalNumOfPos];
        showedRepPrefab = new GameObject[totalNumOfPos];
        switchDelay_s = switchDelay_s > ejectDelay_s ? switchDelay_s : ejectDelay_s;
    }

    // Update is called once per frame
    void Update()
    {
        curTime = Time.time;
        if (curTime >= nextTime)
        {
            nextTime += frequence_s;
            //Debug.Log(curTime);
            if (goStorePos)
            {
                pastPosition[pastPosIndex] = player.transform.position;
                pastRotation[pastPosIndex] = player.transform.rotation;
                if(playerAnim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Idle Walk Run Blend"))
                {
                    if(playerAnim.GetFloat("Speed") < 2)
                    {
                        pastAnimationHash[pastPosIndex] = Animator.StringToHash("Base Layer.Male Idle");
                    }
                    else
                    {
                        pastAnimationHash[pastPosIndex] = Animator.StringToHash("Base Layer.Male Sprint");
                    }
                }
                else
                {
                    pastAnimationHash[pastPosIndex] = playerAnim.GetCurrentAnimatorStateInfo(0).fullPathHash;
                }

                pastPosIndex = (pastPosIndex + 1) % totalNumOfPos;
            }
        }

        if (playRepAnimation && curTime >= nextRepTime)
        {
            nextRepTime = Time.time + 0.01f;
            if (repCounter % shoePosRepDensity == 0)
            {
                showedRepPrefab[curRepIdx] = Instantiate(showRepPrefab, pastPosition[curRepIdx], Quaternion.identity);
                showedRepPrefab[curRepIdx].transform.rotation = pastRotation[curRepIdx];
                showedRepPrefab[curRepIdx].GetComponent<Animator>().Play(pastAnimationHash[curRepIdx]);
            }
            curRepIdx = (curRepIdx - 1 < 0) ? (totalNumOfPos - 1) : (curRepIdx - 1);
            repCounter++;
            if (curRepIdx == pastPosIndex || repCounter > totalNumOfPos)
            {
                playRepAnimation = false;
                repCounter = 0;
            }
        }

        if (isTurningBackTheClock && !playerRepLightScale && !playRepAnimation)
        {
            //Debug.Log("isTurningBackTheClock");
            TurnBackTheClock();
        }

        if(playerRepLightScale)
        {
            forceDirArrow.transform.position = showedPreLightPrefab.transform.position + bias;
            int nextIdx = (timePosIndex - 1 < 0) ? (totalNumOfPos - 1) : (timePosIndex - 1);
            forceDirArrow.transform.rotation = Quaternion.LookRotation(pastPosition[nextIdx] - showedPreLightPrefab.transform.position);

            if (curTime >= tmp)
                showedPreLightPrefab.GetComponent<Animator>().enabled = false;

        }
    }

    private void FixedUpdate()
    {
        if (pressT)
        {
            //string str = pastPosition[0].ToString();
            //for (int i = 0; i < 10; i++)
            //    str += (", " + pastPosition[i]);
            //Debug.Log("past position is " + str);
            //Debug.Log("keydown T, " + (curTime > startTime + 0.1f));
            pressT = false;
            if (playRepAnimation)
                return;

            PressT();
        }
    }

    void TurnBackTheClock()
    {
        if (curTime >= nextTimeInTurningBack)
        {
            //Debug.Log("curPrePosIdx = " + timePosIndex + ", showedCurPosCounter = " + showedCurPosCounter);
            nextTimeInTurningBack = Time.time + turnBackTimeWidth;

            // Delete Rep when passing
            int preIdx = (timePosIndex + 1 >= totalNumOfPos) ? (totalNumOfPos - timePosIndex - 1) : timePosIndex + 1;
            if (showedRepPrefab[preIdx] != null)
            {
                Destroy(showedRepPrefab[preIdx]);
            }

            // Show Player_rep
            mainCamera.enabled = false;
            timeRepCamera.enabled = true;
            representativeObj.transform.position = Vector3.SmoothDamp(representativeObj.transform.position, pastPosition[timePosIndex], ref velocity, turnBackTimeWidth / 20);
            representativeObj.transform.rotation = pastRotation[timePosIndex];
            Player_repAnimation.curStateHash = pastAnimationHash[timePosIndex];
            Player_repAnimation.PlayPlayer_repAnimation = true;

            // Show force direction arrow
            if (showedCurPosCounter < totalNumOfPos - 1)
            {
                forceDirArrow.transform.position = Vector3.SmoothDamp(forceDirArrow.transform.position, representativeObj.transform.position + bias, ref velocity, turnBackTimeWidth / 20);
                int nextIdx = (timePosIndex - 1 < 0) ? (totalNumOfPos - 1) : (timePosIndex - 1);
                forceDirArrow.transform.rotation = Quaternion.LookRotation(pastPosition[nextIdx] - representativeObj.transform.position);
            }

            timePosIndex = (timePosIndex - 1 < 0) ? (totalNumOfPos - 1) : (timePosIndex - 1);
            if (timePosIndex == pastPosIndex)
            {
                //Debug.Log("last position");
                mainCamera.enabled = true;

                InactivePrefabs();

                // Delete all showPos Prefab
                DestoryShowedRepPrefab();

                // 開放操作
                player.SetActive(true);
                UCanMove();

                endTime = Time.time;
                goStorePos = true;
                isTurningBackTheClock = false;
                isInvincibleState = false;
            }
        }
    }

    void PressT()
    {
        if ((curTime > startTime + 0.1f) && (isTurningBackTheClock && !playerRepLightScale))
        {
            Debug.Log("turn off time controller");
            isTurningBackTheClock = false;
            showedPreLightPrefab = repLightObj;
            showedPreLightPrefab.SetActive(true);
            showedPreLightPrefab.GetComponent<Animator>().enabled = true;
            showedPreLightPrefab.GetComponent<Animator>().Play(representativeObj.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).fullPathHash);
            showedPreLightPrefab.transform.rotation = pastRotation[timePosIndex];
            showedPreLightPrefab.transform.position = pastPosition[timePosIndex];

            playerRepLightScale = true;
            tmp = Time.time + 0.05f;

            endTime = Time.time + 1000f;
            Invoke("Ejection", ejectDelay_s);
            Invoke("ShowPlayer", switchDelay_s);
        }
        else if (curTime > endTime + cdTime)
        {
            goStorePos = false;
            isTurningBackTheClock = true;
            isInvincibleState = true;
            ActivePrefabs();

            // 停止操作
            UCanNOTMove();

            // Show all prePos
            curRepIdx = (pastPosIndex - 1 < 0) ? (totalNumOfPos - 1) : (pastPosIndex - 1);
            playRepAnimation = true;

            startTime = curTime;
            nextTimeInTurningBack = curTime + frequence_s;
            timePosIndex = (pastPosIndex - 1 < 0) ? (totalNumOfPos - 1) : (pastPosIndex - 1);
            showedCurPosCounter = 0;
            //Debug.Log("stratTime = " + startTime + ", endTime = " + endTime);
        }
    }

    void Ejection()
    {
        //showedPreLightPrefab.transform.position = pastPosition[timePosIndex];
        Debug.Log("1. curPos = " + showedPreLightPrefab.transform.position + "originPos = " + pastPosition[timePosIndex]);
        playerRepLightScale = false;
        lightRepCamera.enabled = true;
        timeRepCamera.enabled = false;

        // Delete all showPos Prefab
        InactivePrefabs();
        DestoryShowedRepPrefab();

        // 增加作用力
        showedPreLightPrefab.transform.position = pastPosition[timePosIndex];
        Debug.Log("2. curPos = " + showedPreLightPrefab.transform.position + "originPos = " + pastPosition[timePosIndex]);
        Vector3 curPos = pastPosition[timePosIndex];
        int preIndex = (timePosIndex - 1 < 0) ? (totalNumOfPos - 1) : (timePosIndex - 1);
        Vector3 prePos = pastPosition[preIndex];
        Debug.Log("curPos = " + curPos + ", prePos = " + prePos + ", forceDir = " + (prePos - curPos) + "distance = " + Vector3.Distance(curPos, prePos));
        showedPreLightPrefab.GetComponent<ImpactReceiver_RepLight>().AddImpact((prePos - curPos), Vector3.Distance(curPos, prePos) * forceStrength);

        InitArrays();

        pastPosIndex = 0;
    }

    void ShowPlayer()
    {
        // 改變 player 狀態
        player.SetActive(true);
        player.transform.position = showedPreLightPrefab.transform.position;
        player.transform.rotation = showedPreLightPrefab.transform.rotation;
        mainCamera.enabled = true;
        showedPreLightPrefab.SetActive(false);

        // 開放操作
        UCanMove();
        isInvincibleState = false;

        endTime = Time.time;
        goStorePos = true;
    }

    void UCanMove()
    {
        //Debug.Log("U can move! But U didn't use the ability of time-control.");
        player.GetComponent<CharacterController>().enabled = true;
        player.GetComponent<Animator>().enabled = true;
        player.GetComponent<Collider>().enabled = true;
        player.GetComponent<Rigidbody>().WakeUp();
        Boss.timeStop = false;
        Boss.turnOffTimeStop = true;
    }

    void UCanNOTMove()
    {
        //Debug.Log("U can not move...");
        player.GetComponent<CharacterController>().enabled = false;
        player.GetComponent<Animator>().enabled = false;
        player.GetComponent<Collider>().enabled = false;
        player.GetComponent<Rigidbody>().Sleep();
        Boss.timeStop = true;
    }

    void DestoryShowedRepPrefab()
    {
        for (int i = 0; i < totalNumOfPos; i++)
        {
            if (showedRepPrefab[i] != null)
            {
                Destroy(showedRepPrefab[i]);
            }
        }
    }

    void ActivePrefabs()
    {
        int tmpIdx = (pastPosIndex - 1 < 0) ? (totalNumOfPos - 1) : (pastPosIndex - 1);
        timeRepCamera.enabled = true;
        representativeObj.transform.position = pastPosition[tmpIdx];
        representativeObj.transform.rotation = pastRotation[tmpIdx];
        representativeObj.GetComponent<Animator>().Play(pastAnimationHash[tmpIdx]);
        representativeObj.SetActive(true);
        forceDirArrow.transform.position = pastPosition[(pastPosIndex - 1 < 0) ? (totalNumOfPos - 1) : (pastPosIndex - 1)];
        forceDirArrow.transform.rotation = Quaternion.LookRotation(pastPosition[tmpIdx] - pastPosition[(tmpIdx - 1 < 0) ? (totalNumOfPos - 1) : (tmpIdx - 1)]);
        forceDirArrow.SetActive(true);
    }

    void InactivePrefabs()
    {
        representativeObj.SetActive(false);
        forceDirArrow.SetActive(false);
    }
}
