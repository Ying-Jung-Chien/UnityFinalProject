using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skillCD : MonoBehaviour
{
    public static int skill_choose = 0;
    public GameObject skill1;
    public GameObject skill2;
    public GameObject skill3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (skill_choose == 0)
        {
            skill1.gameObject.SetActive(true);
            skill2.gameObject.SetActive(false);
            skill3.gameObject.SetActive(false);
        }
        else if (skill_choose == 1)
        {
            skill1.gameObject.SetActive(false);
            skill2.gameObject.SetActive(true);
            skill3.gameObject.SetActive(false);
        }
        else if (skill_choose == 2)
        {
            skill1.gameObject.SetActive(false);
            skill2.gameObject.SetActive(false);
            skill3.gameObject.SetActive(true);
        }
    }
}
