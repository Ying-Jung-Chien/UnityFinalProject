using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public bool defeat;
    // Start is called before the first frame update
    void Start()
    {
        defeat = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnTriggerEnter(Collider other)
    {
       
        if(defeat){
            this.GetComponent<Animation>().Play("OpenDoor");
        }
        
        
    }
    public void SetDefeat(){
        defeat = true;
    }
}
