using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public GameObject playerHead;
    public GameObject blackDragon;
    public GameObject blackDragonHead;
    public GameObject blackDragonHeadFront;
    public GameObject bossBlood;

    public static bool stopBoss = true;

    private bool firstScream;
    private bool test = false;

    // Start is called before the first frame update
    void Start()
    {
        firstScream = true;
        test = false;
        //firstScream = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha9))
        {
            test = !test;
            if (test)
            {
                Debug.Log("Testing state");
                boss_entrance.trap_activate = false;
                player.GetComponent<CharacterController>().enabled = false;
                player.transform.position = new Vector3(0, -1, -25);
                Invoke("ActiveCharacterController", 0.1f);
                
            }
            else
            {
                Debug.Log("Not testing state.");
                boss_entrance.trap_activate = true;
                blackDragon.SetActive(false);
                bossBlood.SetActive(false);
                player.GetComponent<CharacterController>().enabled = false;
                player.transform.position = new Vector3(0, -6.75f, -80f);
                Invoke("ActiveCharacterController", 0.1f);
            }
        }
        if(test)
        {
            if(Input.GetKeyDown(KeyCode.Alpha0))
            {
                blackDragon.SetActive(false);
                bossBlood.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                blackDragon.SetActive(true);
                bossBlood.SetActive(true);
            }
            if(Input.GetKeyDown(KeyCode.Alpha2))
            {
                Boss.goFly = true;
                blackDragon.GetComponent<Animator>().SetBool("goFly", true);
            }
            if(Input.GetKeyDown(KeyCode.Alpha3))
            {
                stopBoss = !stopBoss;
            }
        }

        if (firstScream)
        {
            //保存碰撞信息
            RaycastHit m_hit;
            Ray ray = new Ray(blackDragonHead.transform.position, playerHead.transform.position - blackDragonHead.transform.position);
            if (Physics.Raycast(ray, out m_hit, Vector3.Distance(blackDragonHead.transform.position, playerHead.transform.position)))
            {
                if (m_hit.transform.tag != "Player" && m_hit.transform.name != "Boss")
                {
                    //Debug.Log("Collider name: " + m_hit.transform.name);
                    Debug.DrawLine(blackDragonHead.transform.position, playerHead.transform.position, Color.red);
                }
                else
                {
                    Boss.goScream = true;
                    firstScream = false;
                }
            }
            else
            {
                Boss.goScream = true;
                firstScream = false;
            }
        }
    }

    void ActiveCharacterController()
    {
        player.GetComponent<CharacterController>().enabled = true;
    }
}
