using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class story : MonoBehaviour
{
    public GameObject story1;
    public GameObject story2;
    public GameObject story3;
    public GameObject story4;
    public GameObject story5;
    public GameObject story6;
    public GameObject story7;
    public GameObject story8;
    public GameObject story9;
    public GameObject story10;
    public GameObject story11;
    public GameObject story12;
    public GameObject story13;
    public GameObject story14;
    public GameObject story15;
    public GameObject story16;
    public GameObject story17;
    public GameObject start;
    public GameObject fade;

    public static int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    IEnumerator Wait() {
        yield return new WaitForSeconds(1.0f);
        story1.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(i == 0){
        	StartCoroutine(Wait());
        }else if(i == 1){
        	story2.SetActive(true);
        	Destroy(story1);
        }else if(i == 2){
        	story3.SetActive(true);
        	Destroy(story2);
        }else if(i == 3){
        	story4.SetActive(true);
        	Destroy(story3);
        }else if(i == 4){
        	story5.SetActive(true);
        	Destroy(story4);
        }else if(i == 5){
        	story6.SetActive(true);
        	Destroy(story5);
        }else if(i == 6){
        	story7.SetActive(true);
        	Destroy(story6);
        }else if(i == 7){
        	story8.SetActive(true);
        	Destroy(story7);
        }else if(i == 8){
        	story9.SetActive(true);
        	Destroy(story8);
        }else if(i == 9){
        	story17.SetActive(true);
        	story10.SetActive(true);
        	Destroy(story9);
        }else if(i == 10){
        	story11.SetActive(true);
        	Destroy(story17);
        	Destroy(story10);
        }else if(i == 11){
        	story12.SetActive(true);
        	Destroy(story11);
        }else if(i == 12){
        	story13.SetActive(true);
        	Destroy(story12);
        }else if(i == 13){
        	story14.SetActive(true);
        	Destroy(story13);
        }else if(i == 14){
        	story15.SetActive(true);
        	Destroy(story14);
        }else if(i == 15){
        	story16.SetActive(true);
        	Destroy(story15);
        }else{
        	fade.SetActive(true);
        	start.SetActive(true);
        	Destroy(this);
        }
    }
}
