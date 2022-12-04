using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public GameObject blackDragon;

    private bool firstScream;
    // Start is called before the first frame update
    void Start()
    {
        firstScream = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (firstScream)
        {
            //保存碰撞信息
            RaycastHit m_hit;
            Ray ray = new Ray(blackDragon.transform.position, player.transform.position - blackDragon.transform.position);
            if (Physics.Raycast(ray, out m_hit, Vector3.Distance(blackDragon.transform.position, player.transform.position)))
            {

                if (m_hit.transform.tag != "Player" && m_hit.transform.name != "Boss")
                {
                    //Debug.Log("Collider name: " + m_hit.transform.name);
                    Debug.DrawLine(blackDragon.transform.position, player.transform.position, Color.red);
                }
                else
                {
                    Boss.goScream = true;
                    firstScream = false;
                }
            }
        }
    }
}
