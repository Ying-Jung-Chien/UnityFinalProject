using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadRoom : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(DontDestroyVariable.useDoor1) {
            DontDestroyVariable.useDoor1 = false;
            DontDestroyVariable.lastRoom = 1;
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("Room1");
        } else if(DontDestroyVariable.useDoor2) {
            DontDestroyVariable.useDoor2 = false;
            DontDestroyVariable.lastRoom = 2;
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("Room2");
        } else if(DontDestroyVariable.useDoor3) {
            DontDestroyVariable.useDoor3 = false;
            DontDestroyVariable.lastRoom = 3;
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("Room3");
        }
    }
}
