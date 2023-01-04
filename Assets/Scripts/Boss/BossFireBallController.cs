using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFireBallController : MonoBehaviour
{
    //public GameObject blackDragonHead;
    //public GameObject blackDragonHead_front;
    //public GameObject player;
    public float fireBallAttack = 10;
    public float traceDelay = 0.5f;
    public float speed = 5.0f;

    public static Vector3 _blackDragonHead_pos;
    public static Vector3 _blackDragonHead_front_pos;
    public static Vector3 _player_pos;

    private float curTime;
    private float nextTime;
    private float changeDirTime;
    private bool notInit = true;

    // Start is called before the first frame update
    void Start()
    {
        //_blackDragonHead_pos = blackDragonHead.transform.position;
        //_blackDragonHead_front_pos = blackDragonHead_front.transform.position;
        //_player_pos = player.transform.position;
        changeDirTime = Time.time + traceDelay;
    }

    public void Init(Vector3 blackDragonHead_pos, Vector3 blackDragonHead_front_pos, Vector3 player_pos)
    {
        _blackDragonHead_pos = blackDragonHead_pos;
        _blackDragonHead_front_pos = blackDragonHead_front_pos;
        _player_pos = player_pos + new Vector3(0, 0.5f, 0);
        notInit = false;
    }

    // Update is called once per frame
    void Update()
    {
        curTime = Time.time;

        if (notInit)
            return;

        if(curTime >= nextTime)
        {
            nextTime = curTime + 0.1f;

            if(curTime >= changeDirTime)
            {
                transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, _player_pos - transform.position, Time.deltaTime * 10, 0.0F));
            }
        }
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);

        if (Vector3.Distance(transform.position, _player_pos) <= 0.05f)
            Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
            if (!TimeController.isInvincibleState)
                DontDestroyVariable.PlayerHealth -= fireBallAttack * collision.gameObject.GetComponent<ThirdPersonController>().shield_c;
        Destroy(gameObject);
    }
}
