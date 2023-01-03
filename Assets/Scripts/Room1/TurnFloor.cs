using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnFloor : MonoBehaviour
{
    public GameObject floor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player"){
            floor.GetComponent<Animation>().Play("TurnAround");
        }
    }
}
