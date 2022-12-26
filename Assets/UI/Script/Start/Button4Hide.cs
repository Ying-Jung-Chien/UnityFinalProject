using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Button4Hide : MonoBehaviour, IPointerEnterHandler
{
    public GameObject arrow;
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
    	gameObject.SetActive(false);
        arrow.gameObject.SetActive(true);
        audioPlayer.PlayOneShot(over);
    }
}
