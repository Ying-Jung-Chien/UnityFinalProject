using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class buttonon : MonoBehaviour, IPointerEnterHandler
{
    public GameObject button;
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

    public void OnPointerEnter(PointerEventData eventData)
    {
        button.gameObject.SetActive(true);
        audioPlayer.PlayOneShot(over);
    }
}
