using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skillcomtrol : MonoBehaviour
{
    public static int skill_choose = 0;
    public GameObject skill1;
    public GameObject skill2;
    public GameObject skill3;

    public Image skillmask1;
    public Image skillmask2;
    public Image skillmask3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        skillmask1.fillAmount -= 0.002f;
        skillmask2.fillAmount -= 0.01f;
        skillmask3.fillAmount -= 0.01f;
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
