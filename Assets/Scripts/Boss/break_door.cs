using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class break_door : MonoBehaviour
{
    public AudioClip sound;
    public AudioSource audioPlayer;


    public bool door_open = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "door")
        {
            audioPlayer.PlayOneShot(sound);
            door_open = true;
        }
    }
}
