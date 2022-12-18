using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class mouseink1 : MonoBehaviour, IPointerClickHandler
{
    public UnityEvent rightClick;
    public GameObject close1;

    public GameObject show1;

    public AudioClip good;
    public AudioClip bad;
    public AudioSource audioPlayer;

    public item thisitem;
    public inventory playerInventory;

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
        manager.UpdateItemUse(17);
        if (DontDestroyVariable.useInk == true)
        {
            audioPlayer.PlayOneShot(good);
            close1.SetActive(false);
            show1.SetActive(true);
            AddNewItem(thisitem);
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
