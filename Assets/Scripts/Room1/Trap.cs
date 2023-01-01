using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private float timer;
    public float hurttime;
    public bool iscontact;
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
        if(iscontact){
            timer += Time.deltaTime;
            if(timer > hurttime){
                DontDestroyVariable.PlayerHealth -= 5.0f;
                timer = 0;
            }
        }
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player"){
            iscontact = true;
            
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Player"){
            iscontact = false;
            
        }
    }
     
}
