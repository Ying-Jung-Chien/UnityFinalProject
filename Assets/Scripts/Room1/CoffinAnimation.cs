using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffinAnimation : MonoBehaviour
{
    private Animation anim;
    public bool IsOpen;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();
        IsOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenCoffin(){
        if(anim != null && !IsOpen){
            anim.Play("OpenLid");
            IsOpen = true;
        }
    }
}
