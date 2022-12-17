using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class mouseboard4 : MonoBehaviour, IPointerClickHandler
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
        manager.UpdateItemUse(19);
        if (DontDestroyVariable.useChess == true)
        {
            audioPlayer.PlayOneShot(good);
            board.boardA = 5;
        }
        else
        {
            audioPlayer.PlayOneShot(bad);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    
}
