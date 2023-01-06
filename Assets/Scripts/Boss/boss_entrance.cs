using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_entrance : MonoBehaviour
{
    public GameObject trap_ball;
    private GameObject trap_ball_clone;
    private float start_time;
    public GameObject player;

    public GameObject R_door;
    public GameObject L_door;

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
        if (player.GetComponent<break_door>().door_open)
        {
            if (R_door.transform.eulerAngles.y > 246.9f || R_door.transform.eulerAngles.y == 0) { R_door.transform.Rotate(0, -1, 0); }
            if (L_door.transform.eulerAngles.y < 98.9f) { L_door.transform.Rotate(0, 1, 0); }
            trap_activate = false;
            if (trap_ball_clone)
            {
                Destroy(trap_ball_clone);
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
}
