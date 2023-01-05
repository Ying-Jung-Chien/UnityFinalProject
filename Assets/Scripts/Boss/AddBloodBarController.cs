using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBloodBarController : MonoBehaviour
{
    public float clockwiseRoatateSpeed = 3f;

    private float curTime;
    private float nextTime;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        curTime = Time.time;
        Rotate();
    }

    void Rotate()
    {
        transform.Rotate(Vector3.down * clockwiseRoatateSpeed, Space.World);
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Boss")
        {
            if (curTime > nextTime)
            {
                //Debug.Log("addblood");
                nextTime = Time.time + 0.5f;
                Boss.Health = (Boss.Health + 10f > Boss._maxHealth) ? Boss._maxHealth : Boss.Health + 10f;
            }
        }
    }
}
