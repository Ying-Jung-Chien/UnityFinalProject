using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerInBossScene : MonoBehaviour
{
    private float curTime;
    private float nextTime;
    private float biteTime;
    private bool gotBite = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        curTime = Time.time;
        if(curTime >= biteTime + 5f)
        {
            gotBite = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("player OnCollisionEnter " + collision.transform.tag);
        if(collision.transform.tag == "Boss")
        {
            if (TimeController.isInvincibleState)
                return;
            if(curTime >= nextTime)
            {
                nextTime = Time.time + 1.0f;
                if(Boss.goAttack)
                {
                    if (!gotBite)
                    {
                        Debug.Log("gotBite");
                        DontDestroyVariable.PlayerHealth -= Boss.biteAttack * gameObject.GetComponent<ThirdPersonController>().shield_c;
                        gotBite = true;
                        biteTime = Time.time;
                    }
                }
                else
                {
                    DontDestroyVariable.PlayerHealth -= Boss.touchBossAttack * gameObject.GetComponent<ThirdPersonController>().shield_c;
                }
            }
        }
    }
}
