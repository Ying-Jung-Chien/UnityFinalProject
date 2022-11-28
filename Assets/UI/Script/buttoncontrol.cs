using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttoncontrol : MonoBehaviour
{
    public GameObject bag;
    public GameObject bagbutton1;
    public AudioClip press;
    public AudioClip over;
    public AudioSource audioPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Showbag()
    {
        bag.gameObject.SetActive(true);
        bagbutton1.gameObject.SetActive(true);
        audioPlayer.PlayOneShot(over);
    }

    public void hidebag()
    {
        bag.gameObject.SetActive(false);
        bagbutton1.gameObject.SetActive(false);
        audioPlayer.PlayOneShot(over);
    }
}
