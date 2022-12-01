using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator anim;
    public GameObject coffin;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(coffin.GetComponent<CoffinAnimation>().IsOpen){
            anim.SetTrigger("SitUp");
        }
    }
}
