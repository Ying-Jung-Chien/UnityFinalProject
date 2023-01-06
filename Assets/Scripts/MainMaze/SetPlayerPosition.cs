using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerPosition : MonoBehaviour
{
    private CharacterController _controller;
    
    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();

        if(DontDestroyVariable.lastRoom == 3){
            DontDestroyVariable.passRoom3 = true;
            transform.position = new Vector3(21, 0, 27);
            transform.forward = new Vector3(0, 0, 1);
        } else if(DontDestroyVariable.lastRoom == 2){
            DontDestroyVariable.passRoom2 = true;
            transform.position = new Vector3(53, 0, 0);
            transform.forward = new Vector3(1, 0, 0);
        } else if(DontDestroyVariable.lastRoom == 1){
            DontDestroyVariable.passRoom1 = true;
            transform.position = new Vector3(58, 0, 33);
            transform.forward = new Vector3(-1, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) {
            if (Input.GetKeyDown(KeyCode.Z)) {
                DontDestroyVariable.passRoom1 = true;
                _controller.enabled = false;
                transform.position = new Vector3(58, 0, 33);
                transform.forward = new Vector3(-1, 0, 0);
                _controller.enabled = true;
            } else if (Input.GetKeyDown(KeyCode.X)) {
                DontDestroyVariable.passRoom2 = true;
                _controller.enabled = false;
                transform.position = new Vector3(53, 0, 0);
                transform.forward = new Vector3(1, 0, 0);
                _controller.enabled = true;
            } else if (Input.GetKeyDown(KeyCode.C)) {
                DontDestroyVariable.passRoom3 = true;
                _controller.enabled = false;
                transform.position = new Vector3(21, 0, 27);
                transform.forward = new Vector3(0, 0, 1);
                _controller.enabled = true;
            } 
        }
    }
}
