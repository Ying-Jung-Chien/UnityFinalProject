using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coffin : MonoBehaviour
{
    private Renderer renderer;
    public bool click_coffin;
    public Camera camera;
    private GameObject coffin;
    private CoffinAnimation coffinanimation;
    private bool MouseIn;
    void Start()
    {
        renderer = GetComponent<Renderer>();
        click_coffin = false;
        coffin = this.gameObject.transform.parent.gameObject;
        coffinanimation = coffin.GetComponent<CoffinAnimation>();
    }

    private void OnMouseEnter()
    {
	    renderer.material.color = Color.red;
        MouseIn = true;
    }

    private void OnMouseExit()
    {
        renderer.material.color = Color.white;
        MouseIn = false;
    }
    void Update()
    {
        if (click_coffin)click_coffin = false;
        if (Input.GetMouseButtonDown(0))
        {

            if (MouseIn)
            {
                click_coffin = true;
                coffinanimation.OpenCoffin();
            }
        }
    }
}

