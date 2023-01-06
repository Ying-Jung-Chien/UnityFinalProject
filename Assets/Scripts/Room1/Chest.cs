using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private Animation anim;
    private Renderer renderer;
    public Camera camera;
    private bool MouseIn;
    private bool IsOpen;
    public AudioClip click;
    public AudioSource audioPlayer;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        anim = GetComponent<Animation>();
        MouseIn = false;
        IsOpen = false;
        
    }

    // Update is called once per frame
    void Update()
    {
       
        bool hovered = false;
        if (Input.GetMouseButtonDown(1) && !IsOpen){
            Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
            foreach(RaycastHit hit in Physics.RaycastAll (ray))
            {
                if (hit.collider == GetComponent<Collider>())
                {
                    audioPlayer.PlayOneShot(click);
                    OpenChest();
                    IsOpen = true;
                    break;
                }
            }
        }
        
        
    }

     private void OnMouseEnter()
    {
        
	    renderer.material.color = Color.white;
        MouseIn = true;
    }

    private void OnMouseExit()
    {
        renderer.material.color = Color.white;
        MouseIn = false;
    }
    public void OpenChest(){
        if(anim != null ){
            anim.Play("OpenChest");
            
        }
    }
}
