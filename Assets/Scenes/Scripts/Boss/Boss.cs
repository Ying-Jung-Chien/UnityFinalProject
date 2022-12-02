using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject direction;
    public GameObject player;
    public GameObject EScornor;
    public GameObject WScornor;
    public GameObject ENcornor;
    public GameObject WNcornor;
    //public GameObject attackTrigger;
    public float Health = 1000;
    public float transitionSpead = 0.5f;
    //public float dampTime;

    public bool scream;
    public bool fly;

    public static float Speed { get; set; } = 3.5f;
    public static float TouchATK { get; set; } = 10;
    public static float ATK { get; set; } = 20;
    public static bool goScream { get; set; } = false;
    public static bool goFly { get; set; } = false;
    public static bool isIdle { get; set; } = false;
    public static bool isRotating { get; set; } = false;
    public static bool isGetHit { get; set; } = false;
    public static bool isDead { get; set; } = false;

    private Vector3 initPos;
    private Quaternion initRotation;
    private Vector3 targetPos;
    private Quaternion targetRotation;
    private Vector3 velocity;
    private bool smoothToTarget;
    private float dampTime;
    private float curTime;
    private float nextTime;
    private float counter;
    private int cornorCounter;
    private bool cornorTrigger;

    private void Init()
    {
        initPos = transform.position;
        initRotation = transform.rotation;
        smoothToTarget = false;
        dampTime = 10;
        nextTime = 0;
        counter = 0;
        cornorCounter = -1;
        cornorTrigger = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        scream = goScream;
        fly = goFly;

        curTime = Time.time;

        if(goFly)
        {
            goFly = false;
            float steps = Time.deltaTime * transitionSpead;
            targetPos = new Vector3(transform.position.x, 12, transform.position.z - 15);
            targetRotation = Quaternion.Euler(-30, 180, 0);
            smoothToTarget = true;
        }

        if (cornorCounter == 0 && cornorTrigger)
        {
            targetPos = EScornor.transform.position;
            float aDotb = Vector3.Dot(direction.transform.position - transform.position, targetPos - transform.position);
            float aLen = Vector3.Distance(direction.transform.position, transform.position);
            float bLen = Vector3.Distance(EScornor.transform.position, transform.position);
            if (targetRotation.eulerAngles.x != 0)
                targetRotation = Quaternion.Euler(0, 180, 0);
            else
                targetRotation = Quaternion.Euler(0, transform.eulerAngles.y + Mathf.Acos(aDotb / aLen / bLen) * 180 / Mathf.PI, 0);
            dampTime = 7;
            cornorTrigger = false;
        }
        else if (cornorCounter == 1 && cornorTrigger)
        {
            targetPos = WScornor.transform.position;
            float aDotb = Vector3.Dot(direction.transform.position - transform.position, targetPos - transform.position);
            float aLen = Vector3.Distance(direction.transform.position, transform.position);
            float bLen = Vector3.Distance(WScornor.transform.position, transform.position);
            targetRotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y + Mathf.Acos(aDotb / aLen / bLen) * 180 / Mathf.PI, 0);
            dampTime = 3;
            cornorTrigger = false;
        }
        else if (cornorCounter == 2 && cornorTrigger)
        {
            float aDotb = Vector3.Dot(direction.transform.position - transform.position, WNcornor.transform.position - transform.position);
            float aLen = Vector3.Distance(direction.transform.position, transform.position);
            float bLen = Vector3.Distance(WNcornor.transform.position, transform.position);
            targetRotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y + Mathf.Acos(aDotb / aLen / bLen) * 180 / Mathf.PI, 0);
            targetPos = WNcornor.transform.position;
            dampTime = 7;
            cornorTrigger = false;
        }
        else if (cornorCounter == 3 && cornorTrigger)
        {
            targetPos = ENcornor.transform.position;
            float aDotb = Vector3.Dot(direction.transform.position - transform.position, targetPos - transform.position);
            float aLen = Vector3.Distance(direction.transform.position, transform.position);
            float bLen = Vector3.Distance(WScornor.transform.position, transform.position);
            targetRotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y + Mathf.Acos(aDotb / aLen / bLen) * 180 / Mathf.PI, 0);
            dampTime = 3;
            cornorTrigger = false;
        }

        if (smoothToTarget)
        {
            if (Vector3.Distance(transform.position, targetPos) >= 8)
            {
                if (cornorCounter == -1 && curTime >= nextTime)
                {
                    counter += 1f;
                    nextTime = curTime + 0.2f;
                    dampTime = Mathf.Max(dampTime - (0.1f * counter), 3);
                }
                Debug.Log("targetPos = " + targetPos + ", targetRotation = " + targetRotation.eulerAngles);
                if (Mathf.Abs(transform.rotation.eulerAngles.y - targetRotation.eulerAngles.y) > 70)
                {
                    //isRotating = true;
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 1f);
                }
                else
                {
                    isRotating = false;
                    transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, dampTime);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 1f);
                }
            }
            else
            {
                cornorCounter = (cornorCounter + 1) % 4;
                cornorTrigger = true;
            }
        }
    }
}
