using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject startObj;
    public float startObjDampTime = 1f;
    public float transformDistance = 5f;
    public GameObject player;
    public GameObject playerHead;
    public GameObject blackDragon;
    public GameObject blackDragonHead;
    public GameObject blackDragonHeadFront;
    public GameObject blackDragonSpine;
    public GameObject bossBlood;
    public GameObject[] cameraTargets;
    public GameObject[] crystals;
    public GameObject[] crystalCores;
    public GameObject enrichBossBloodObj;
    public GameObject enrichBossBloodBar;
    public GameObject testBossFireBall;

    public static bool stopBoss = false;
    public static bool start = false;

    private Vector3 velocity;
    private bool firstScream;
    private bool test = false;
    private bool addBlood = false;
    private float curTime;
    private float nextTime;
    private float endTime;
    private int camTarNum;
    private int curTarIdx = 0;
    private bool start_flag = false;
    private GameObject closestCrystal;


    // Start is called before the first frame update
    void Start()
    {
        firstScream = true;
        test = false;
        camTarNum = cameraTargets.Length;
        //firstScream = false;
        foreach (var crystal in crystals)
            crystal.SetActive(false);
        nextTime = curTime + 10000f;
        enrichBossBloodObj.SetActive(false);
        addBlood = false;
    }

    // Update is called once per frame
    void Update()
    {
        curTime = Time.time;

        if(Input.GetKeyDown(KeyCode.Equals))
        {
            test = !test;
            if (test)
            {
                Debug.Log("Testing state");
                boss_entrance.trap_activate = false;
                player.GetComponent<CharacterController>().enabled = false;
                player.transform.position = new Vector3(0, -1, -25);
                Invoke("ActiveCharacterController", 0.1f);
                
            }
            else
            {
                Debug.Log("Not testing state.");
                boss_entrance.trap_activate = true;
                blackDragon.SetActive(false);
                bossBlood.SetActive(false);
                player.GetComponent<CharacterController>().enabled = false;
                player.transform.position = new Vector3(0, -6.75f, -80f);
                Invoke("ActiveCharacterController", 0.1f);
            }
        }
        if(test)
        {
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                blackDragon.SetActive(false);
                bossBlood.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.Alpha9))
            {
                blackDragon.SetActive(true);
                bossBlood.SetActive(true);
            }
            if(Input.GetKeyDown(KeyCode.P))
            {
                Boss.Health -= 100f;
            }
            if(Input.GetKeyDown(KeyCode.Minus))
            {
                blackDragon.SetActive(true);
                bossBlood.SetActive(true);
                Debug.Log("Press 4");
                start = true;
            }
            if(Input.GetKeyDown(KeyCode.B))
            {
                foreach(var crystal in crystals)
                {
                    Destroy(crystal);
                }
            }
            if(Input.GetKeyDown(KeyCode.H))
            {
                DontDestroyVariable.PlayerHealth = 100f;
            }
            if(Input.GetKeyDown(KeyCode.F))
            {
                GameObject fireball = Instantiate(testBossFireBall, new Vector3(0, 10f, 0), Quaternion.identity);
                fireball.GetComponent<BossFireBallController>().Init(new Vector3(0, 5f, 0), new Vector3(0, 5f, 0), blackDragon.transform.position);
            }
        }

        if (start)
        {
            if(!start_flag)
            {
                start_flag = true;
                UCanNOTMove();
            }
            //Debug.Log("start");
            //Debug.Log("curTarIdx = " + curTarIdx + ", camTarNum = " + camTarNum);
            startObj.SetActive(true);
            foreach (var crystal in crystals)
                if (crystal != null)
                    crystal.SetActive(true);
            mainCamera.enabled = false;

            startObj.transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(startObj.transform.forward, blackDragon.transform.position - startObj.transform.position, Time.deltaTime * 1f, 0.0F));
            //startObj.transform.Translate(Vector3.forward * 1f * Time.deltaTime, Space.Self);
            startObj.transform.position = Vector3.SmoothDamp(startObj.transform.position, cameraTargets[curTarIdx].transform.position, ref velocity, startObjDampTime);
            if (Vector3.Distance(startObj.transform.position, cameraTargets[curTarIdx].transform.position) <= 5f)
            {
                curTarIdx++;
            }

            if (curTarIdx >= camTarNum)
            {
                mainCamera.enabled = true;
                startObj.SetActive(false);
                start = false;
                curTarIdx = 0;
                Boss.goFly = true;
                UCanMove();
                //nextTime = Time.time;
                addBlood = true;
            }
        }

        if (firstScream)
        {
            //保存碰撞信息
            RaycastHit m_hit;
            Ray ray = new Ray(blackDragonHead.transform.position, playerHead.transform.position - blackDragonHead.transform.position);
            if (Physics.Raycast(ray, out m_hit, Vector3.Distance(blackDragonHead.transform.position, playerHead.transform.position)))
            {
                if (m_hit.transform.tag != "Player" && m_hit.transform.name != "Boss")
                {
                    //Debug.Log("Collider name: " + m_hit.transform.name);
                    Debug.DrawLine(blackDragonHead.transform.position, playerHead.transform.position, Color.red);
                }
                else
                {
                    Boss.goScream = true;
                    firstScream = false;
                }
            }
            else
            {
                Boss.goScream = true;
                firstScream = false;
            }
        }

        if (addBlood)
        {
            if(closestCrystal == null)
            {
                enrichBossBloodObj.SetActive(false);
                addBlood = false;
                return;
            }
            Vector3 mid = (blackDragonSpine.transform.position + closestCrystal.transform.position) / 2;
            enrichBossBloodObj.transform.position = mid;
            enrichBossBloodObj.transform.rotation = Quaternion.LookRotation(blackDragonSpine.transform.position - closestCrystal.transform.position);
            enrichBossBloodBar.GetComponent<AddBloodBarController>().Stretch(Vector3.Distance(blackDragonSpine.transform.position, closestCrystal.transform.position));
            //enrichBossBloodBar.transform.localScale = new Vector3(0.2f, 0.2f, Vector3.Distance(blackDragonSpine.transform.position, closestCrystal.transform.position));
            enrichBossBloodObj.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        float minDist = 1000f;
        for (int i = 0; i < crystals.Length; i++)
        {
            if (crystals[i] == null)
                continue;
            if (minDist > Vector3.Distance(crystalCores[i].transform.position, blackDragon.transform.position))
            {
                closestCrystal = crystalCores[i];
                minDist = Vector3.Distance(closestCrystal.transform.position, blackDragon.transform.position);
            }
        }
    }

    void ActiveCharacterController()
    {
        player.GetComponent<CharacterController>().enabled = true;
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
}
