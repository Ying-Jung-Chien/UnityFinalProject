using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class break_door : MonoBehaviour
{
    public GameObject R_door;
    public GameObject L_door;

    private bool door_open = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (door_open == true)
        {
            if (R_door.transform.eulerAngles.y > 246.9f || R_door.transform.eulerAngles.y == 0) { R_door.transform.Rotate(0, -1, 0); }
            if (L_door.transform.eulerAngles.y < 98.9f) { L_door.transform.Rotate(0, 1, 0); }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "door")
        {
            door_open = true;
        }
    }
}
