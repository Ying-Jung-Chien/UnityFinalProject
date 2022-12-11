using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class mousehourse : MonoBehaviour, IPointerClickHandler
{
    public UnityEvent rightClick;
    public GameObject show1;
    public GameObject show2;
    public GameObject close1;
    public GameObject close2;

    public item item1;
    public item item2;
    public inventory playerInventory;

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
        manager.UpdateItemUse(1);
        if (DontDestroyVariable.useHorseEye == true)
        {
            audioPlayer.PlayOneShot(good);
            show1.SetActive(true);
            close1.SetActive(false);
            AddNewItem(item1);
            AddNewItem(item2);
        }else{
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
