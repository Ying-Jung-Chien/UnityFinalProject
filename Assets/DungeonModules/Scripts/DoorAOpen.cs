using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAOpen : MonoBehaviour
{
    public bool CanOpen;

    // Use this for initialization
    void Start()
    {
        CanOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
    }
    void OnTriggerEnter(Collider other)
    {
        if(CanOpen){
            GetComponent<Animator>().SetTrigger("DoorATrigger");
        }
        
    }
}