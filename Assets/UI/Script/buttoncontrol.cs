using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttoncontrol : MonoBehaviour
{
    public GameObject bag;
    public GameObject close1;
    public AudioClip press;
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
        audioPlayer.PlayOneShot(press);
    }

    public void hidebag()
    {
        bag.gameObject.SetActive(false);
        close1.gameObject.SetActive(false);
        audioPlayer.PlayOneShot(press);
    }
}
