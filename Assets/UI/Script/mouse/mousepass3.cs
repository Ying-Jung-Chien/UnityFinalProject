using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class mousepass3 : MonoBehaviour, IPointerClickHandler
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
        if (flower.flowerA == 0 && flower.flowerB == 1 && flower.flowerC == 3 && flower.flowerD == 2)
        {
            audioPlayer.PlayOneShot(good);
            flower.wrong4 = 2;
        }
        else
        {
            audioPlayer.PlayOneShot(bad);
            flower.wrong4 = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
