using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class PlayerControllerInBossScene : MonoBehaviour
{
    public GameObject boss;
    public float forceStrength = 300f;

    private bool oneSet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(Boss.goScream)
        {
            oneSet = true;
            gameObject.GetComponent<CharacterController>().enabled = false;
            gameObject.GetComponent<Animator>().enabled = false;
            gameObject.GetComponent<Rigidbody>().Sleep();
        }
        else
        {
            if (oneSet)
            {
                oneSet = false;
                gameObject.GetComponent<CharacterController>().enabled = true;
                gameObject.GetComponent<Animator>().enabled = true;
                gameObject.GetComponent<Rigidbody>().WakeUp();
            }
        }
        */
    }

    /*
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnter");
        Debug.Log("collision.name = " + collision.transform.name);
        if(collision.transform.tag == "Boss")
        {
            // 停止操作
            gameObject.GetComponent<CharacterController>().enabled = false;
            gameObject.GetComponent<Animator>().enabled = false;
            gameObject.GetComponent<Rigidbody>().Sleep();

            // 增加作用力
            Vector3 curPos = transform.position;
            Vector3 colliderPos = collision.transform.position;
            Debug.Log(colliderPos - curPos);
            Vector3 forceDir = (colliderPos - curPos) * 100 + new Vector3(0, 2, 0);
            Debug.Log("forceDir = " + forceDir);
            gameObject.GetComponent<ImpactReceiver>().AddImpact(forceDir, forceStrength);

            // 開放操作
            gameObject.GetComponent<CharacterController>().enabled = true;
            gameObject.GetComponent<Animator>().enabled = true;
            gameObject.GetComponent<Rigidbody>().WakeUp();
        }
    }
    */
}
