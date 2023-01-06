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
    public AudioSource audioPlayer1;

    public GameObject ExplosionEffect;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        start_time = Time.time;
        audioPlayer1.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - start_time > 7.0f)
        {
            agent.enabled = false;
            audioPlayer1.Stop();
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
            audioPlayer1.Stop();
            //Destroy(gameObject);

            if (ExplosionEffect != null)
            {
            	ExplosionEffect.SetActive(true);
                GameObject exp = GameObject.Instantiate(ExplosionEffect, Vector3.zero, Quaternion.identity) as GameObject;
                exp.transform.position = player.transform.position + Vector3.up * 1;
                // Destroy after 4 sec
                GameObject.Destroy(exp, 4);
                // Destroy Self
                GameObject.Destroy(gameObject);                   
            }
        }
    }
}
