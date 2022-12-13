using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class mousepass4 : MonoBehaviour, IPointerClickHandler
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
        if (nine.nineA == 4 && nine.nineB == 2 && nine.nineC == 7 && nine.nineD == 8 && nine.nineE == 1)
        {
            audioPlayer.PlayOneShot(good);
            nine.wrong5 = 2;
        }
        else
        {
            audioPlayer.PlayOneShot(bad);
            nine.wrong5 = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
