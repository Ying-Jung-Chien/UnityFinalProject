using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerPosition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(DontDestroyVariable.lastRoom == 3){
            transform.position = new Vector3(21, 0, 27);
            transform.forward = new Vector3(0, 0, 1);
        } else if(DontDestroyVariable.lastRoom == 2){
            transform.position = new Vector3(53, 0, 0);
            transform.forward = new Vector3(1, 0, 0);
        } else if(DontDestroyVariable.lastRoom == 1){
            transform.position = new Vector3(58, 0, 33);
            transform.forward = new Vector3(-1, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
