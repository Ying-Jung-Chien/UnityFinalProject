using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeui1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(manager.status == 0)
        {
            this.gameObject.SetActive(false);
        }
    }
}
