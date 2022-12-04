using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class PlayerControllerInBossScene : MonoBehaviour
{
    public float collisionForceStrength = 300f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Boss.goScream)
        {
            gameObject.GetComponent<CharacterController>().enabled = false;
            gameObject.GetComponent<Animator>().enabled = false;
        }
        else
        {
            gameObject.GetComponent<CharacterController>().enabled = true;
            gameObject.GetComponent<Animator>().enabled = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision.name = " + collision.transform.name);
        if(collision.transform.tag == "Boss")
        {
            // 停止操作
            gameObject.GetComponent<CharacterController>().enabled = false;
            gameObject.GetComponent<Animator>().enabled = false;

            // 增加作用力
            Vector3 curPos = transform.position;
            Vector3 colliderPos = collision.transform.position;
            Vector3 forceDir = (colliderPos - curPos) * 10 + new Vector3(0, 5, 0);
            Debug.Log("forceDir = " + forceDir);
            gameObject.GetComponent<ImpactReceiver>().AddImpact(forceDir, collisionForceStrength);

            // 開放操作
            gameObject.GetComponent<CharacterController>().enabled = true;
            gameObject.GetComponent<Animator>().enabled = true;
        }
    }
}
