using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject blackDragonHead;
    public GameObject blackDragonHeadFront;
    public GameObject bossFireBall;
    public GameObject direction;
    public GameObject player;
    public GameObject playerFront;
    public GameObject[] spiral;
    private int spiralSize;
    public float Health = 1000;
    public float transitionSpead = 0.5f;
    public float dampTime = 3f;
    public int attackFreq_UpperBound = 10;
    public int attackFreq_LowerBound = 40;
    public int fireBallNum_UpperBound = 10;
    public int fireBallNum_LowerBound = 5;
    public float fireBallAttackFrequence = 1.0f;
    public float rotateSpeed = 1f;

    public bool scream;
    public bool fly;

    public static float Speed { get; set; } = 3.5f;
    public static float TouchATK { get; set; } = 10;
    public static float ATK { get; set; } = 20;
    public static bool goScream { get; set; } = false;
    public static bool goFly { get; set; } = false;
    public static bool isIdle { get; set; } = false;
    public static bool goAttack { get; set; } = false;
    public static bool timeStop { get; set; } = false;
    public static bool turnOffTimeStop { get; set; } = false;

    private Vector3 initPos;
    private Vector3 initDir;
    private Vector3 curPos;
    private Vector3 targetPos;
    private Vector3 velocity;
    private bool smoothToTarget;
    private bool spiralTrigger;
    private bool dashToPlayer;
    private bool backToInitPos;
    private bool justStartFlying;
    private bool canFireBall;
    private float _dampTime;
    private float curTime;
    private float nextTime;
    private float nextFireBallTime;
    private float counter;
    private int spiralCounter;
    private int attackCounter;
    private int attackRandomNum;
    private int fireBallRandomNum;
    private int curFireBallNum;

    private void Init()
    {
        nextTime = 0;
        nextFireBallTime = 0;
        counter = 0;
        spiralCounter = -1;
        attackCounter = 0;
        attackRandomNum = -1;
        spiralTrigger = false;
        justStartFlying = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        initPos = transform.position;
        initDir = transform.forward;
        _dampTime = dampTime;
        spiralSize = spiral.Length;
        smoothToTarget = false;
        dashToPlayer = false;
        backToInitPos = false;
        canFireBall = false;
        fireBallRandomNum = 0;
        curFireBallNum = 0;
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        scream = goScream;
        fly = goFly;
        curTime = Time.time;
        curPos = transform.position;

        if(timeStop)
        {
            //Debug.Log("Boss.cs Update timeStop");
            transform.position = curPos;
            gameObject.GetComponent<Animator>().enabled = false;
            return;
        }

        if(turnOffTimeStop)
        {
            //Debug.Log("Boss.cs Update turnOffTimeStop");
            turnOffTimeStop = false;
            gameObject.GetComponent<Animator>().enabled = true;
        }

        if (goFly)
        {
            //Debug.Log("Boss.cs Update goFly");
            goFly = false;
            justStartFlying = true;
            smoothToTarget = true;
            //canFireBall = true;
            attackRandomNum = Random.Range(attackFreq_LowerBound, attackFreq_UpperBound);
            targetPos = new Vector3(transform.position.x, 12, transform.position.z - 15);
            dampTime = 10;
            attackCounter = 0;
        }

        if (attackCounter == attackRandomNum)
        {
            //Debug.Log("Boss.cs Update attackCounter == attackRandonNum");
            //Debug.Log("attackCounter == attackRandomNum = " + attackCounter);
            dashToPlayer = true;
            canFireBall = false;
            dampTime = 1;
            targetPos = player.transform.position;// + new Vector3(0, 0.9f, 0);
            attackRandomNum = Random.Range(attackFreq_LowerBound, attackFreq_UpperBound);
            attackCounter = 0;
        }

        if(canFireBall)
        {
            if(curTime >= nextFireBallTime)
            {
                if (fireBallRandomNum == 0)
                {
                    fireBallRandomNum = Random.Range(fireBallNum_LowerBound, fireBallNum_UpperBound);
                    curFireBallNum = 0;
                }
                else
                {
                    if (curFireBallNum == fireBallRandomNum)
                    {
                        nextFireBallTime = Time.time + fireBallAttackFrequence;
                        fireBallRandomNum = 0;
                    }
                    else
                        nextFireBallTime = Time.time + 0.05f;
                    GameObject fireball = Instantiate(bossFireBall, blackDragonHeadFront.transform.position, Quaternion.LookRotation(blackDragonHeadFront.transform.position - blackDragonHead.transform.position));
                    fireball.GetComponent<BossFireBallController>().Init(blackDragonHead.transform.position, blackDragonHeadFront.transform.position, player.transform.position);
                    curFireBallNum++;
                }
            }
        }

        if (spiralTrigger && spiralCounter > -1)
        {
            //Debug.Log("Boss.cs Update 'spiralTrigger && spiralCounter > -1'");
            targetPos = spiral[spiralCounter].transform.position;
            if (justStartFlying)
            {
                dampTime = 3;
                if (spiralCounter >= 2)
                    justStartFlying = false;
            }
            else
                dampTime = _dampTime;
            spiralTrigger = false;
            attackCounter++;
            if (spiralCounter > 0)
                canFireBall = true;
        }

        if (smoothToTarget)
        {
            //Debug.Log("Boss.cs Update smoothToTarget");
            if (dashToPlayer)
            {
                if (Vector3.Distance(transform.position, targetPos) <= 5 && Vector3.Distance(transform.position, targetPos) > 2)
                {
                    //Debug.Log("goAttack");
                    goAttack = true;
                }
                if (Vector3.Distance(transform.position, targetPos) <= 2)
                {
                    //Debug.Log("face to init pos");
                    goAttack = false;
                    Init();
                    Vector3 horizon = new Vector3(transform.forward.x, 0, transform.forward.z);
                    transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, horizon, Time.deltaTime * rotateSpeed, 0.0F));
                    if (Vector3.Distance(transform.forward, horizon / Vector3.Distance(horizon, Vector3.zero)) <= 1)
                    {
                        transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, initPos - transform.position, Time.deltaTime * rotateSpeed, 0.0F));
                        if (Vector3.Distance(transform.forward, (initPos - transform.position) / Vector3.Distance(initPos, transform.position)) <= 1)
                        {
                            dampTime = 3;
                            targetPos = initPos;
                            dashToPlayer = false;
                            backToInitPos = true;
                        }
                    }
                }
                else
                {
                    //Debug.Log("dashToplayer");
                    transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, dampTime);
                    transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, targetPos - transform.position, Time.deltaTime * 5, 0.0F));
                }

            }
            else if (backToInitPos)
            {
                //Debug.Log("backToInitPos");
                if (Vector3.Distance(transform.position, targetPos) <= 5)
                {
                    //Debug.Log("at init pos");
                    transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, dampTime);
                    transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, initDir, Time.deltaTime * rotateSpeed, 0.0F));
                    if (Vector3.Distance(transform.forward, initDir) <= 0.1)
                    {
                        backToInitPos = false;
                        smoothToTarget = false;
                        Invoke("GoFly", 5);
                    }
                }
                else
                {
                    transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, dampTime);
                    transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, targetPos - transform.position, Time.deltaTime * rotateSpeed, 0.0F));
                }
            }
            else if (Vector3.Distance(transform.position, targetPos) >= 5)
            {
                if (spiralCounter == -1 && curTime >= nextTime)
                {
                    counter += 1f;
                    nextTime = curTime + 0.2f;
                    dampTime = Mathf.Max(dampTime - (0.1f * counter), 3);
                }

                transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, dampTime);
                transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, targetPos - transform.position, Time.deltaTime * rotateSpeed, 0.0F));
            }
            else
            {
                spiralCounter = (spiralCounter + 1) % spiralSize;
                spiralTrigger = true;
            }
        }
    }

    void GoFly()
    {
        goFly = true;
    }
}
