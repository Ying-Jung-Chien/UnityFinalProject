using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterAController : MonoBehaviour
{
    public float attackTimeInterval = 2.0f;
    public float attackDistance = 2.0f;
    public static float monsterAHealth =  100.0f;

    private NavMeshAgent agent;
    private Transform player;
	private bool hasAniComp = false;
    private bool isTriggerPlayer = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        if ( GetComponent<Animation>() != null ) hasAniComp = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (DetectPlayerA.isPlayerIn) ChaseAndAttackPlayer();
        else Back();
    }

    bool CheckAniClip ( string clipname )
	{	
		if( this.GetComponent<Animation>().GetClip(clipname) == null ) 
			return false;
		else if ( this.GetComponent<Animation>().GetClip(clipname) != null ) 
			return true;

		return false;
	}

    void ChaseAndAttackPlayer()
    {
        agent.SetDestination(player.position + player.forward);
        if ( hasAniComp == true ) {
            if ( CheckAniClip( "run" ) && agent.remainingDistance > attackDistance) {
				GetComponent<Animation>().CrossFade("run");
			} else if (agent.remainingDistance <= attackDistance) {
                if ( GetComponent<Animation>().IsPlaying("run") && CheckAniClip( "idle01" ) )
                    GetComponent<Animation>().CrossFade("idle01",0.5f);
                
                if ( !IsInvoking(nameof(Attack)) ) Invoke(nameof(Attack), attackTimeInterval);
            }
        }
    }
    void Attack()
    {
        if ( CheckAniClip( "attack01" ) ) {
            transform.LookAt(player);
			GetComponent<Animation>().CrossFade("attack01",0.2f);
			GetComponent<Animation>().CrossFadeQueued("idle01");
            if (isTriggerPlayer) {
                DontDestroyVariable.PlayerHealth -= 5.0f;
                if ( !IsInvoking(nameof(SetPlayerDamage)) ) Invoke(nameof(SetPlayerDamage), 0.5f);
            }
		}
    }

    void Back()
    {
        Vector3 origin = new Vector3(60, 0, 18);
        agent.SetDestination(origin);
        if ( hasAniComp == true ) {
            if ( CheckAniClip( "run" ) && agent.remainingDistance > 0.1) {
				GetComponent<Animation>().CrossFade("run");
			} else if (agent.remainingDistance <= 0.1) {
                if ( GetComponent<Animation>().IsPlaying("run") && CheckAniClip( "idle01" ) )
                    GetComponent<Animation>().CrossFade("idle01",0.5f);
                transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
            }
        }
    }

    void SetPlayerDamage()
    {
        DontDestroyVariable.PlayerDamage = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        isTriggerPlayer = false;
        if (other.gameObject.tag == "Player") {
            isTriggerPlayer = true;
        }
    }
}
