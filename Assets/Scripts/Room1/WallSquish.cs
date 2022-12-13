using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WallSquish : MonoBehaviour
{
    private bool solved;
    public GameObject WallLeft;
    public GameObject WallRight;
    // Start is called before the first frame update
    void Start()
    {
        solved = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!solved && WallRight.transform.position.z < 2){
            WallRight.transform.position =  WallRight.transform.position + new Vector3( 0, 0, 0.0002f);
        }
        
    }

   
}
