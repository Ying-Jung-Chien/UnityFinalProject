using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_switch : MonoBehaviour
{
    public GameObject Boss;
    public GameObject Bossblood;
    public GameObject black;
    public GameObject close;
    public AudioClip sound;
    public AudioClip dragon;
    public AudioSource audioPlayer;
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
        if(other.tag == "Player")
        {
            Boss.SetActive(true);
            Bossblood.SetActive(true);
            black.SetActive(true);
            close.SetActive(false);
            Debug.Log("switch open");
            audioPlayer.PlayOneShot(sound);
            StartCoroutine(ExampleCoroutine());
            Invoke("StartCamera", 2f);
        }
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(2);
        audioPlayer.PlayOneShot(dragon);
        Destroy(black);
    }

    void StartCamera()
    {
        GameController.start = true;
    }
}
