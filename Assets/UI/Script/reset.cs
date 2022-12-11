using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class reset : MonoBehaviour, IPointerClickHandler
{
    public UnityEvent rightClick;

    public item item2;
    public item item3;
    public item item4;
    public item item5;
    public item item6;
    public item item8;
    public inventory playerInventory;

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
        if (eight.eight2 == 2)
        {
            AddNewItem(item2);
        }
        else if (eight.eight2 == 3)
        {
            AddNewItem(item3);
        }
        else if (eight.eight2 == 4)
        {
            AddNewItem(item4);
        }
        else if (eight.eight2 == 5)
        {
            AddNewItem(item5);
        }
        else if (eight.eight2 == 6)
        {
            AddNewItem(item6);
        }
        else if (eight.eight2 == 8)
        {
            AddNewItem(item8);
        }

        if (eight.eight3 == 2)
        {
            AddNewItem(item2);
        }
        else if (eight.eight3 == 3)
        {
            AddNewItem(item3);
        }
        else if (eight.eight3 == 4)
        {
            AddNewItem(item4);
        }
        else if (eight.eight3 == 5)
        {
            AddNewItem(item5);
        }
        else if (eight.eight3 == 6)
        {
            AddNewItem(item6);
        }
        else if (eight.eight3 == 8)
        {
            AddNewItem(item8);
        }

        if (eight.eight4 == 2)
        {
            AddNewItem(item2);
        }
        else if (eight.eight4 == 3)
        {
            AddNewItem(item3);
        }
        else if (eight.eight4 == 4)
        {
            AddNewItem(item4);
        }
        else if (eight.eight4 == 5)
        {
            AddNewItem(item5);
        }
        else if (eight.eight4 == 6)
        {
            AddNewItem(item6);
        }
        else if (eight.eight4 == 8)
        {
            AddNewItem(item8);
        }

        if (eight.eight5 == 2)
        {
            AddNewItem(item2);
        }
        else if (eight.eight5 == 3)
        {
            AddNewItem(item3);
        }
        else if (eight.eight5 == 4)
        {
            AddNewItem(item4);
        }
        else if (eight.eight5 == 5)
        {
            AddNewItem(item5);
        }
        else if (eight.eight5 == 6)
        {
            AddNewItem(item6);
        }
        else if (eight.eight5 == 8)
        {
            AddNewItem(item8);
        }
        
        if (eight.eight6 == 2)
        {
            AddNewItem(item2);
        }
        else if (eight.eight6 == 3)
        {
            AddNewItem(item3);
        }
        else if (eight.eight6 == 4)
        {
            AddNewItem(item4);
        }
        else if (eight.eight6 == 5)
        {
            AddNewItem(item5);
        }
        else if (eight.eight6 == 6)
        {
            AddNewItem(item6);
        }
        else if (eight.eight6 == 8)
        {
            AddNewItem(item8);
        }
        
        if (eight.eight8 == 2)
        {
            AddNewItem(item2);
        }
        else if (eight.eight8 == 3)
        {
            AddNewItem(item3);
        }
        else if (eight.eight8 == 4)
        {
            AddNewItem(item4);
        }
        else if (eight.eight8 == 5)
        {
            AddNewItem(item5);
        }
        else if (eight.eight8 == 6)
        {
            AddNewItem(item6);
        }
        else if (eight.eight8 == 8)
        {
            AddNewItem(item8);
        }
        eight.eight2 = 0;
        eight.eight3 = 0;
        eight.eight4 = 0;
        eight.eight5 = 0;
        eight.eight6 = 0;
        eight.eight8 = 0;
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
