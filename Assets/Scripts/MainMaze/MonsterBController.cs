using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MonsterBController : MonoBehaviour
{
    public float attackTimeInterval = 2.0f;
    public float attackDistance = 2.0f;
    public static float monsterBHealth =  100.0f;
    public LayerMask playerLayer;

    private UnityEngine.AI.NavMeshAgent agent;
    private Transform player;
	private bool hasAniComp = false;

    public item thisitem;
    public inventory playerInventory;

    public GameObject alertui;

    public AudioClip click;
    public AudioSource audioPlayer;
    public ParticleSystem blood;
    
    public Image nowblood;
    public Image noblood;
    public Image head;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        if ( GetComponent<Animation>() != null ) hasAniComp = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!DontDestroyVariable.isMonsterBDead) {
            if (DetectPlayerB.isPlayerIn) ChaseAndAttackPlayer();
            else Back();
        }
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
        bool playerInAttackRange = Physics.CheckSphere(transform.position, attackDistance, playerLayer);

        if ( hasAniComp == true ) {
            nowblood.fillAmount = monsterBHealth / 100.0f;
            noblood.fillAmount = 1;
            head.fillAmount = 1;
            if ( CheckAniClip( "run" ) && !playerInAttackRange) {
                agent.SetDestination(player.position);
				GetComponent<Animation>().CrossFade("run");
			} else if (playerInAttackRange) {
                agent.SetDestination(transform.position);

                if ( GetComponent<Animation>().IsPlaying("run") && CheckAniClip( "idle01" ) )
                    GetComponent<Animation>().CrossFade("idle01",0.5f);
                
                if ( !IsInvoking(nameof(Attack)) ) Invoke(nameof(Attack), attackTimeInterval);
            }
        }
    }
    void Attack()
    {
        if ( CheckAniClip( "attack03" ) && GetComponent<Animation>().IsPlaying("idle01") ) {
            transform.LookAt(player);
			GetComponent<Animation>().CrossFade("attack03",0.2f);
			GetComponent<Animation>().CrossFadeQueued("idle01");
            if ( !IsInvoking(nameof(SetPlayerDamage)) ) Invoke(nameof(SetPlayerDamage), 0.5f);
		}
    }

    void Back()
    {
        Vector3 origin = new Vector3(72, 0, 3);
        agent.SetDestination(origin);
        if ( hasAniComp == true ) {
            nowblood.fillAmount = 0;
            noblood.fillAmount = 0;
            head.fillAmount = 0;
            if ( CheckAniClip( "run" ) && agent.remainingDistance > 0.1) {
				GetComponent<Animation>().CrossFade("run");
			} else if (agent.remainingDistance <= 0.1) {
                if ( GetComponent<Animation>().IsPlaying("run") && CheckAniClip( "idle01" ) )
                    GetComponent<Animation>().CrossFade("idle01",0.5f);
                transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            }
        }
    }

    void SetPlayerDamage()
    {
        bool playerInAttackRange = Physics.CheckSphere(transform.position, attackDistance, playerLayer);
        if (playerInAttackRange && GetComponent<Animation>().IsPlaying("attack03")) {
            DontDestroyVariable.PlayerHealth -= 5.0f;
            PlayerController.isDamaging = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Sword_2_Long" && PlayerController.isAttacking && !DontDestroyVariable.isMonsterBDead && !GetComponent<Animation>().IsPlaying("damage")) {
            monsterBHealth -= 10.0f;
            nowblood.fillAmount = monsterBHealth / 100.0f;
            blood.Play();
            // Debug.Log(monsterBHealth);
            if (monsterBHealth <= 0) {
                DontDestroyVariable.isMonsterBDead = true;
                DontDestroyVariable.getPuzzle[5] = 1;
                GetComponent<Animation>().CrossFade("dead",0.1f);
                audioPlayer.PlayOneShot(click);
                AddNewItem(thisitem);
                alertui.SetActive(true);
                StartCoroutine(Wait());
            } else {
                GetComponent<Animation>().CrossFade("damage",0.2f);
                GetComponent<Animation>().CrossFadeQueued("idle01");
            }
        }
    }

    public void AddNewItem(item item)
    {
        if (!playerInventory.itemList.Contains(item))
        {
            playerInventory.itemList.Add(item);
        }
        else
        {
            item.itemHeld += 1;
        }
        manager.ReflashItem();
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        Destroy(nowblood);
        Destroy(noblood);
        Destroy(head);
    }
}
