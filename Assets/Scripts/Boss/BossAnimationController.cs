using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimationController : MonoBehaviour
{
    private Animator animator;
    private float preDir;
    private float curDir;
    private float curTime;
    private float nextTime;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        preDir = curDir = transform.rotation.eulerAngles.y;
        nextTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        curDir = transform.rotation.eulerAngles.y;
        curTime = Time.time;

        if(Boss.goScream)
        {
            Debug.Log("Black dragon scream.");
            animator.SetBool("goScream", true);
            
            if (CurrentStateDone())
            {
                animator.SetBool("goScream", false);
                Boss.goScream = false;
                //Boss.goFly = true;
            }
        }

        if(Boss.goFly)
        {
            Debug.Log("Black dragon go fly.");
            animator.SetBool("goFly", true);
        }

        if(curTime > nextTime)
        {
            nextTime += 0.1f;
            preDir = curDir;
        }

        if(Boss.isRotating)
        {
            animator.SetBool("isRotating", true);
        }
        else
        {
            animator.SetBool("isRotating", false);
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
