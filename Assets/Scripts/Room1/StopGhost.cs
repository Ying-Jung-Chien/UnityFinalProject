using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopGhost : MonoBehaviour
{
    public GameObject lightcontrol;
    public GameObject alertui;

    public AudioClip click;
    public AudioSource audioPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
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
                    alertui.SetActive(true);
                    audioPlayer.PlayOneShot(click);
                    lightcontrol.GetComponent<LightsControl>().SetStopLight();
                }
            }
        }
    }
    
}
