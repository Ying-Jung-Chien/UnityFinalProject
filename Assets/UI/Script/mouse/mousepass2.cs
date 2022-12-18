using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class mousepass2 : MonoBehaviour, IPointerClickHandler
{
    public UnityEvent rightClick;

    public AudioClip good;
    public AudioClip bad;
    public AudioSource audioPlayer;
    // Start is called before the first frame update
    void Start()
    {
        rightClick.AddListener(new UnityAction(ButtonRightClick));
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            rightClick.Invoke();
        }
    }

    private void ButtonRightClick()
    {
        if (north.northA == 3 && north.northB == 0 && north.northC == 2 && north.northD == 4 && north.northE == 1)
        {
            audioPlayer.PlayOneShot(good);
            north.wrong3 = 2;
        }
        else
        {
            audioPlayer.PlayOneShot(bad);
            north.wrong3 = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
