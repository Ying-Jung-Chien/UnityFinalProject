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

    public GameObject skill20;
    public GameObject skill30;
    public GameObject skillmask20;
    public GameObject skillmask30;
    public GameObject frame1;
    public GameObject frame2;
    public GameObject frame3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        skillmask1.fillAmount -= 0.002f;
        skillmask2.fillAmount -= 0.02f;
        //skillmask3.fillAmount -= 0.006f;
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

        if(DontDestroyVariable.getball2 == true){
            frame1.SetActive(false);
            frame2.SetActive(true);
            skill20.SetActive(true);
            skillmask20.SetActive(true);
        }

        if(DontDestroyVariable.getball3 == true){
            frame1.SetActive(false);
            frame2.SetActive(false);
            frame3.SetActive(true);
            skill20.SetActive(true);
            skillmask20.SetActive(true);
            skill30.SetActive(true);
            skillmask30.SetActive(true);
        }
    }
}
