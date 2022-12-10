using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
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

    public GameObject shield;
    private float startTime;
    public GameObject fireball;
    private GameObject fireball_clone;

    public AudioSource audioPlayer;
    public AudioClip bgmshield;
    public AudioClip attack;

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
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerController.isDamaging){
            if(IsInState(damageState)){
                if(CurrentStateDone()) PlayerController.isDamaging = false;
            } 
            else PlayStateIfNotInState(damageState);
            
        }
        else if(PlayerController.isRising){
            PlayStateIfNotInState(jumpState);
        }
        else if(PlayerController.isFalling){
            if(IsInState(jumpState)){
                PlayState(fallState);
            }
        }
        else if(PlayerController.isLanding){
            if(IsInState(fallState)){
                PlayState(landState);
            }
            if(IsInState(landState)){
                if(CurrentStateDone()) PlayerController.isLanding = false;
            }
        }
        else if(PlayerController.isAttacking){
            if(IsInState(attackState)){
                if(attackState == fireballState)
                {
                    if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.45f)
                    {
                        Vector3 pos = transform.position + new Vector3(transform.TransformDirection(Vector3.forward).x * 2, 1, transform.TransformDirection(Vector3.forward).z * 2);
                        Quaternion rot = transform.rotation;
                        fireball_clone = (GameObject)Instantiate(fireball, pos, rot);
                        fireball_clone.SetActive(true);
                        PlayerController.isAttacking = false;
                    }
                }
                else if (CurrentStateDone())
                {
                    if (attackState == shieldState)
                    {
                        shield.SetActive(true);
                        audioPlayer.PlayOneShot(bgmshield);
                        startTime = Time.time;
                    }
                    if (attackState == normalState)
                    {
                        audioPlayer.PlayOneShot(attack);
                    }
                    PlayerController.isAttacking = false;
                }

            }
            if (gameObject.GetComponent<test>().current_skill == 0)
            {
                attackState = normalState;
            }
            else if(gameObject.GetComponent<test>().current_skill == 1)
            {
                attackState = fireballState;
            }
            else if(gameObject.GetComponent<test>().current_skill == 2)
            {
                attackState = shieldState;
            }
            PlayStateIfNotInState(attackState); 
        }
        else if(PlayerController.isRunning){
            PlayStateIfNotInState(runState);
        }
        else if(PlayerController.isWalking){
            PlayStateIfNotInState(walkState);
        }
        else{
            PlayStateIfNotInState(idleState);
        }
        if(Time.time - startTime > 10.0f)
        {
            shield.SetActive(false);
        }
    }

    bool IsInState(int stateHash){
        return animator.GetCurrentAnimatorStateInfo(0).fullPathHash == stateHash;
    }

    bool CurrentStateDone(){
        return animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.8f;
    }

    void PlayState(int stateHash){
        animator.Play(stateHash, 0);
    }

    void PlayStateIfNotInState(int stateHash){
        if(!IsInState(stateHash))
            PlayState(stateHash);
    }
}