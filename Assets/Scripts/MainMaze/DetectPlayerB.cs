using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayerB : MonoBehaviour
{
    public static bool isPlayerIn = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            isPlayerIn = isPlayerIn ? false : true;
    }
}
