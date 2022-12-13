using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class mousebox1 : MonoBehaviour, IPointerClickHandler
{
    public UnityEvent rightClick;
    public GameObject close1;

    public item item;
    public inventory playerInventory;
    public GameObject alertui;

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
        manager.UpdateItemUse(15);
        if (DontDestroyVariable.useKey2 == true)
        {
            AddNewItem(item);
            audioPlayer.PlayOneShot(good);
            close1.SetActive(false);
            alertui.SetActive(true);
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

    public void AddNewItem(item item)
    {
        if (!playerInventory.itemList.Contains(item))
        {
            playerInventory.itemList.Add(item);
        }
        else
        {
            item.itemHeld += 1;
        }
        manager.ReflashItem();
    }

}
