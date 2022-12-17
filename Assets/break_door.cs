using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class break_door : MonoBehaviour
{
    public GameObject R_door;
    public GameObject L_door;
    float rotateSpeed = 2f;
    Quaternion targetAngels_R;
    Quaternion targetAngels_L;

    public bool door_open = false;
    // Start is called before the first frame update
    void Start()
    {
        targetAngels_R = Quaternion.Euler(0, -113.1f, 0);
        targetAngels_L = Quaternion.Euler(0, 98.9f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (door_open == true)
        {
            if (R_door.transform.eulerAngles.y > 246.9f || R_door.transform.eulerAngles.y == 0) { R_door.transform.Rotate(0, -1, 0);  Debug.Log(R_door.transform.eulerAngles.y); }
            if (L_door.transform.eulerAngles.y < 98.9f) { L_door.transform.Rotate(0, 1, 0); }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == R_door || other == L_door || other.tag == "enemy")
        {
            door_open = true;
        }
    }
}
