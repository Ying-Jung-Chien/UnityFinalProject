using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPuzzle : MonoBehaviour
{
    private Renderer renderer;
    public Camera camera;
    private bool MouseIn;
    public GameObject boardgame;
    void Start()
    {
        renderer = GetComponent<Renderer>();
        MouseIn = false;
        
    }

    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
            foreach(RaycastHit hit in Physics.RaycastAll (ray))
            {
                if (hit.collider == GetComponent<Collider>())
                {
                    boardgame.SetActive(true);
                    break;
                }
            }
        }
        
    }
}
