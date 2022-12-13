using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class mousepass1 : MonoBehaviour, IPointerClickHandler
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
        if (eight.eight2 == 2 && eight.eight3 == 3 && eight.eight4 == 4 && eight.eight5 == 5 && eight.eight6 == 6 && eight.eight8 == 8)
        {
            audioPlayer.PlayOneShot(good);
            eight.wrong1 = 2;
        }
        else
        {
            audioPlayer.PlayOneShot(bad);
            eight.wrong1 = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
