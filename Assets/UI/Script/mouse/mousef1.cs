using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class mousef1 : MonoBehaviour, IPointerClickHandler
{
    public UnityEvent rightClick;

    public AudioClip click;
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
        audioPlayer.PlayOneShot(click);
        flower.flowerA = (flower.flowerA + 1) % 4;
    }

    // Update is called once per frame
    void Update()
    {

    }
    
}
