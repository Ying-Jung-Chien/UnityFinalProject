using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimationController : MonoBehaviour
{
    public static float canGetAttackTime;

    private Animator animator;
    private float preDir;
    private float curDir;
    private float curTime;
    private float nextTime;
    private bool flag;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        preDir = curDir = transform.rotation.eulerAngles.y;
        nextTime = 0;
        flag = true;
    }

    // Update is called once per frame
    void Update()
    {
        curDir = transform.rotation.eulerAngles.y;
        curTime = Time.time;

        if (Boss.goScream)
        {
            Debug.Log("Black dragon scream.");
            animator.SetBool("goScream", true);

            if(flag)
            {
                flag = false;
                nextTime = curTime + 6f;
            }

            if (CurrentStateDone() && curTime >= nextTime)
            {
                animator.SetBool("goScream", false);
                Boss.goScream = false;
            }
        }

        if (Boss.goFly)
        {
            Debug.Log("Black dragon go fly.");
            Boss.goFly = false;
            animator.SetBool("goFly", true);
            flag = true;
        }

        if (Boss.goAttack)
        {
            animator.SetBool("goAttack", true);
        }
        else
        {
            animator.SetBool("goAttack", false);
        }

        
        if(Boss.getAttack)
        {
            if (curTime >= canGetAttackTime)
            {
                Boss.getAttack = false;
                animator.SetBool("getAttack", false);
            }
            else
                animator.SetBool("getAttack", true);
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

    void PlayState(int stateHash)
    {
        animator.Play(stateHash, 0);
    }

    void PlayStateIfNotInState(int stateHash)
    {
        if (!IsInState(stateHash))
            PlayState(stateHash);
    }
}
