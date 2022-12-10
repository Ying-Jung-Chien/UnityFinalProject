using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_repAnimation : MonoBehaviour
{
    public static int curStateHash;
    public static bool PlayPlayer_repAnimation;

    private Animator animator;
    private float curTime;
    private float nextTime;
    private int[] stateHash;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
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
            animator.Play(curStateHash, 0);
        }
        else if(curTime > nextTime)
        {
            animator.enabled = false;
        }
    }
}
