using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPuzzle : MonoBehaviour
{
    private Renderer renderer;
    public Camera camera;
    private bool MouseIn;
    public GameObject boardgame;

    public AudioClip click;
    public AudioSource audioPlayer;
    void Start()
    {
        renderer = GetComponent<Renderer>();
        MouseIn = false;
        
    }

    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
            foreach(RaycastHit hit in Physics.RaycastAll (ray))
            {
                if (hit.collider == GetComponent<Collider>())
                {
                    audioPlayer.PlayOneShot(click);
                    boardgame.SetActive(true);
                    break;
                }
            }
        }
        
    }
}
