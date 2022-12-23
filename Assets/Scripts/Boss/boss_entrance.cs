using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_entrance : MonoBehaviour
{
    public GameObject trap_ball;
    private GameObject trap_ball_clone;
    private float start_time;

    public static bool trap_activate = true;

    // Start is called before the first frame update
    void Start()
    {
        start_time = Time.time;
        generate_trap_ball();
    }

    // Update is called once per frame
    void Update()
    {
        if (trap_activate)
        {
            if (Time.time - start_time > 10.0f)
            {
                generate_trap_ball();
            }
        }
    }

    void generate_trap_ball()
    {
        Vector3 pos = trap_ball.transform.position;
        Quaternion rot = trap_ball.transform.rotation;
        trap_ball_clone = (GameObject)Instantiate(trap_ball, pos, rot);
        trap_ball_clone.SetActive(true);
        start_time = Time.time;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            trap_activate = false;
            if (trap_ball_clone)
            {
                Destroy(trap_ball_clone);
            }
        }
    }
}
