using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;    //使用UnityEngine.AI


public class trap_ball : MonoBehaviour
{
    private NavMeshAgent agent;    //宣告NavMeshAgent
    public GameObject target_obj;    //目標物件
    private float start_time;

    public AudioClip sound;
    public AudioSource audioPlayer;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        start_time = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - start_time > 7.0f)
        {
            agent.enabled = false;
            Destroy(gameObject);
        }
        else
        {
            agent.SetDestination(target_obj.transform.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            gameObject.GetComponent<Collider>().enabled = false;
            if (!TimeController.isInvincibleState)
            {
                DontDestroyVariable.PlayerHealth -= 10f * other.GetComponent<ThirdPersonController>().shield_c;
                audioPlayer.PlayOneShot(sound);
            }
            agent.enabled = false;
            Destroy(gameObject);
        }
    }
}
