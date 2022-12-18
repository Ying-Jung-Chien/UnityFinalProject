using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopGhost : MonoBehaviour
{
    public GameObject lightcontrol;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
            foreach(RaycastHit hit in Physics.RaycastAll (ray))
            {
                if (hit.collider == GetComponent<Collider>())
                {
                    lightcontrol.GetComponent<LightsControl>().SetStopLight();
                }
            }
        }
    }
    
}
