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
    void Start()
    {
        renderer = GetComponent<Renderer>();
        click_coffin = false;
        coffin = this.gameObject.transform.parent.gameObject;
        coffinanimation = coffin.GetComponent<CoffinAnimation>();
    }

    private void OnMouseEnter()
    {
        Debug.Log("Enter");
	    renderer.material.color = Color.red;
    }

    private void OnMouseExit()
    {
        renderer.material.color = Color.white;
    }
    void Update()
    {
        if(click_coffin)click_coffin = false;
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if (hitInfo.collider.gameObject == gameObject)
                {
                    click_coffin = true;
                    coffinanimation.OpenCoffin();
                }
            }
        }
    }
}

