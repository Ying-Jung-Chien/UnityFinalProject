using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject attackTrigger;
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
    //public static bool isGetHit { get; set; } = false;
    //public static bool isDead { get; set; } = false;

    private Vector3 initPos;
    private Vector3 initDir;
    private Vector3 targetPos;
    private Vector3 velocity;
    private bool smoothToTarget;
    private bool spiralTrigger;
    private bool dashToPlayer;
    private bool backToInitPos;
    private bool justStartFlying;
    private float _dampTime;
    private float curTime;
    private float nextTime;
    private float counter;
    private int spiralCounter;
    private int attackCounter;
    private int attackRandomNum;


    private void Init()
    {
        nextTime = 0;
        counter = 0;
        spiralCounter = -1;
        spiralTrigger = false;
        attackCounter = 0;
        attackRandomNum = -1;
        justStartFlying = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        initPos = transform.position;
        initDir = transform.forward;
        smoothToTarget = false;
        _dampTime = dampTime;
        spiralSize = spiral.Length;
        dashToPlayer = false;
        backToInitPos = false;
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        scream = goScream;
        fly = goFly;

        curTime = Time.time;

        if (goFly)
        {
            goFly = false;
            justStartFlying = true;
            float steps = Time.deltaTime * transitionSpead;
            targetPos = new Vector3(transform.position.x, 12, transform.position.z - 15);
            dampTime = 10;
            smoothToTarget = true;
            attackRandomNum = Random.Range(attackFreq_LowerBound, attackFreq_UpperBound);
            attackCounter = 0;
        }

        if (attackCounter == attackRandomNum)
        {
            //Debug.Log("attackCounter == attackRandomNum = " + attackCounter);
            dashToPlayer = true;
            dampTime = 1;
            targetPos = player.transform.position;// + new Vector3(0, 0.9f, 0);
            attackRandomNum = Random.Range(10, 40);
            attackCounter = 0;
        }

        if (spiralTrigger && spiralCounter > -1)
        {
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
        }

        if (smoothToTarget)
        {
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
                    transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, initPos - transform.position, Time.deltaTime * rotateSpeed, 0.0F));
                    if (Vector3.Distance(transform.forward, (initPos - transform.position) / Vector3.Distance(initPos, transform.position)) <= 1)
                    {
                        dampTime = 3;
                        targetPos = initPos;
                        dashToPlayer = false;
                        backToInitPos = true;
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
                        goFly = true;
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
}
