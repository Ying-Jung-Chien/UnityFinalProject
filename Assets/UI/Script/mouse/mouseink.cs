using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class mouseink : MonoBehaviour, IPointerClickHandler
{
    public UnityEvent rightClick;
    public GameObject close1;

    public GameObject show1;

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
        manager.UpdateItemUse(16);
        if (DontDestroyVariable.useWater == true)
        {
            audioPlayer.PlayOneShot(good);
            close1.SetActive(false);
            show1.SetActive(true);
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
