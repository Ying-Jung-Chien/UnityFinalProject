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
    public GameObject bossFireBall;

    private bool firstScream;

    // Start is called before the first frame update
    void Start()
    {
        firstScream = true;
        //firstScream = false;
    }

    // Update is called once per frame
    void Update()
    {
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

        if (Input.GetKeyDown(KeyCode.F))
        {
            GameObject fireball = Instantiate(bossFireBall, blackDragonHeadFront.transform.position, Quaternion.Euler(180, 0, 0));
            //GameObject fireball = Instantiate(bossFireBall, blackDragonHeadFront.transform.position, Quaternion.identity);
            fireball.GetComponent<BossFireBallController>().Init(blackDragonHead.transform.position, blackDragonHeadFront.transform.position, player.transform.position);
        }
    }
}
