 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private float timer;
    public float hurttime;
    public bool iscontact;

    public AudioClip hurt;
    public AudioSource audioPlayer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
        hurttime = 3f;
        iscontact = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player"){
            audioPlayer.PlayOneShot(hurt);
            DontDestroyVariable.PlayerHealth -= 5.0f;
            
        }
    }

     
}
