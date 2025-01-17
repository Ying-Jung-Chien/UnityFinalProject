using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public AudioClip attack;
	public AudioSource audioplayer;

	public static bool enemydead;

	private GameObject playerObject;
	// private Player player;
	
	public static float maxHealth;
    public static float Health;

	private float move = 20;
	private bool stop = false;	
	private float blend;
	private float delay = 0;
	public float AddRunSpeed = 1;
	public float AddWalkSpeed = 1;
	private bool hasAniComp = false;

	private NavMeshAgent agent;
    private Transform player_trans;
    public LayerMask whatIsGround, Player;
	    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
	public float timeAttacking;
    bool alreadyAttacked;
	public bool Attacking;
    public GameObject projectile;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    public static Animator anim;
    public GameObject coffin;
    private bool begining;
    private Vector3 previous;
    private float velocity;

   
    public LayerMask playerLayer;
    public static  GameObject Door;


    public Image nowblood;
    public Image noblood;
    public Image head;

    public AudioClip sound;
    public AudioSource audioPlayer;
    void Awake()
    {
        player_trans = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        maxHealth = 1000f;
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        enemydead = false;
		Health = maxHealth;

		playerObject = GameObject.Find("Player");
		
		Attacking = false;
        begining = true;
    }

    // Update is called once per frame
    void Update()
    {
        nowblood.fillAmount = Health / maxHealth;
        if(Health <= 0){
            Destroy(nowblood);
            Destroy(noblood);
            Destroy(head);
        }
        if(!enemydead){
            if(begining){
                if(coffin.GetComponent<CoffinAnimation>().IsOpen){
                    anim.SetTrigger("SitUp");
                }
                if(anim.GetCurrentAnimatorStateInfo(0).IsName("Stand")){
                    anim.applyRootMotion = true;
                    begining = false;
                }
            }
            else{
                velocity = ((transform.position - previous).magnitude) / Time.deltaTime;
                previous = transform.position;
    
                anim.SetFloat("Velocity",velocity);
                
                playerInSightRange = Physics.CheckSphere(transform.position, sightRange, Player);
                playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, Player);
            
                if (playerInSightRange && !playerInAttackRange) ChasePlayer();
                if (playerInAttackRange && playerInSightRange) AttackPlayer();
            }
        }
        

        if (Input.GetMouseButtonDown(1) && enemydead){
            Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
            foreach(RaycastHit hit in Physics.RaycastAll (ray))
            {
                if (hit.collider == this.transform.GetChild(2).GetComponent<Collider>())
                {
                    
                    break;
                }
            }
        }
    }

    void ChasePlayer()
    {
        transform.LookAt(player_trans);
        agent.SetDestination(player_trans.position);
    }

    // void SearchWalkPoint()
    // {
    //     //Calculate random point in range
    //     float randomZ = Random.Range(-walkPointRange, walkPointRange);
    //     float randomX = Random.Range(-walkPointRange, walkPointRange);

    //     walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
    //     if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround)){
	// 		if(!Physics.Raycast(walkPoint, -transform.right, 4f, whatIsGround) && !Physics.Raycast(walkPoint, transform.right,4f, whatIsGround) && !Physics.Raycast(walkPoint, -transform.forward, 4f, whatIsGround) && !Physics.Raycast(walkPoint, transform.forward, 4f, whatIsGround))
	// 			walkPointSet = true;
	// 	}
            
    // }

    bool CheckAniClip ( string clipname )
	{	
        
		if( this.GetComponent<Animation>().GetClip(clipname) == null ) 
			return false;
		else if ( this.GetComponent<Animation>().GetClip(clipname) != null ) 
			return true;

		return false;
	}

    void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(player_trans);

        if (!alreadyAttacked)
        {
            ///Attack code here
           
			// StartCoroutine(PlayAttackSound());
			
			// if ( hasAniComp == true ){	
                
			// 	if ( CheckAniClip( "Attack" ) == false ) return;
			// 	// GetComponent<Animation>().CrossFade("attack_short_001",0.0f);
			// 	// GetComponent<Animation>().CrossFadeQueued("idle_combat");
			// }
            ///End of attack code
            anim.SetTrigger("Attack");
            AttackingStart();
            alreadyAttacked = true;
			Invoke(nameof(AttackingStop), timeAttacking);
            
            
        }
        
    }

    IEnumerator PlayAttackSound(){
		yield return new WaitForSeconds(0.5f);
	}
	 private void AttackingStart()
    {
        Attacking = true;
        
    }
	 private void AttackingStop()
    {
        Attacking = false;
        bool playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerLayer);
        if (playerInAttackRange ) {
            print("damage");
            audioplayer.PlayOneShot(attack);
            DontDestroyVariable.PlayerHealth -= 5.0f;
            PlayerController.isDamaging = true;
        }
        Invoke(nameof(ResetAttack), timeBetweenAttacks);

        
    }

	 private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public static void TakeDamage(float damage)
    {
		anim.SetTrigger("Damage");
        Health -= damage;
		// healthBarImage.fillAmount = Mathf.Clamp((float)health / maxHealth, 0, 1f);
        if (Health <= 0){
			enemydead = true;
			anim.SetTrigger("Dead");
            Door.GetComponent<OpenDoor>().SetDefeat();
			// Invoke(nameof(DestroyEnemy), 2f);
		}
    }
    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other){
        if(other.name == "Sword_2_Long" && PlayerController.isAttacking){
            audioplayer.PlayOneShot(sound);
            TakeDamage(100);
        }
    }

    


}


