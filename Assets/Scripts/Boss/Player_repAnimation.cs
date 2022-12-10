using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_repAnimation : MonoBehaviour
{
    private int idleState;
    private int walkState;
    private int runState;
    private int jumpState;
    private int fallState;
    private int landState;
    private int attackState;
    private int normalState;
    private int fireballState;
    private int shieldState;
    private int damageState;
    private Animator animator;
    private float curTime;
    private float nextTime;
    private int[] stateHash;


    //public GameObject shield;
    //private float startTime;
    //public GameObject fireball;
    //private GameObject fireball_clone;

    //public AudioSource audioPlayer;
    //public AudioClip bgmshield;
    //public AudioClip attack;
    public static int curStateIdx;
    public static bool PlayPlayer_repAnimation;

    // Start is called before the first frame update
    void Start()
    {
        idleState = Animator.StringToHash("Base Layer.Male Idle");
        walkState = Animator.StringToHash("Base Layer.Male_Sword_Walk");
        runState = Animator.StringToHash("Base Layer.Male Sword Sprint");
        jumpState = Animator.StringToHash("Base Layer.Male Jump Up");
        fallState = Animator.StringToHash("Base Layer.Male Fall");
        landState = Animator.StringToHash("Base Layer.Male Land");
        attackState = Animator.StringToHash("Base Layer.Male Attack 3");
        normalState = Animator.StringToHash("Base Layer.Male Attack 3");
        fireballState = Animator.StringToHash("Base Layer.Standing_2H_Magic_Attack_01");
        shieldState = Animator.StringToHash("Base Layer.Standing_2H_Magic_Area_Attack_01");
        damageState = Animator.StringToHash("Base Layer.Male Sword Damage Light");

        animator = gameObject.GetComponent<Animator>();

        //                       0          1            2          3          4          5            6         7
        stateHash = new int[8] { idleState, damageState, jumpState, fallState, landState, attackState, runState, walkState };

    }

    // Update is called once per frame
    void Update()
    {
        curTime = Time.time;
        if (PlayPlayer_repAnimation)
        {
            //Debug.Log("Play Player_rep animation. Current state is " + stateHash[curStateIdx]);
            nextTime = curTime + 0.01f;
            PlayPlayer_repAnimation = false;
            animator.enabled = true;
            animator.Play(stateHash[curStateIdx], 0);
        }
        else if(curTime > nextTime)
        {
            animator.enabled = false;
        }
    }

    bool IsInState(int stateHash)
    {
        return animator.GetCurrentAnimatorStateInfo(0).fullPathHash == stateHash;
    }

    bool CurrentStateDone()
    {
        return animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.8f;
    }

    public void PlayState(int stateHash)
    {
        animator.Play(stateHash, 0);
    }

    void PlayStateIfNotInState(int stateHash)
    {
        if (!IsInState(stateHash))
            PlayState(stateHash);
    }
}
