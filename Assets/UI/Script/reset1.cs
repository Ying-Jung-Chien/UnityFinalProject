using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class reset1 : MonoBehaviour, IPointerClickHandler
{
    public UnityEvent rightClick;

    public item item1;
    public item item2;
    public item item4;
    public item item7;
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
        if (nine.nineA == 1)
        {
            AddNewItem(item1);
        }
        else if (nine.nineA == 2)
        {
            AddNewItem(item2);
        }
        else if (nine.nineA == 4)
        {
            AddNewItem(item4);
        }
        else if (nine.nineA == 7)
        {
            AddNewItem(item7);
        }
        else if (nine.nineA == 8)
        {
            AddNewItem(item8);
        }

        if (nine.nineB == 1)
        {
            AddNewItem(item1);
        }
        else if (nine.nineB == 2)
        {
            AddNewItem(item2);
        }
        else if (nine.nineB == 4)
        {
            AddNewItem(item4);
        }
        else if (nine.nineB == 7)
        {
            AddNewItem(item7);
        }
        else if (nine.nineB == 8)
        {
            AddNewItem(item8);
        }

        if (nine.nineC == 1)
        {
            AddNewItem(item1);
        }
        else if (nine.nineC == 2)
        {
            AddNewItem(item2);
        }
        else if (nine.nineC == 4)
        {
            AddNewItem(item4);
        }
        else if (nine.nineC == 7)
        {
            AddNewItem(item7);
        }
        else if (nine.nineC == 8)
        {
            AddNewItem(item8);
        }

        if (nine.nineD == 1)
        {
            AddNewItem(item1);
        }
        else if (nine.nineD == 2)
        {
            AddNewItem(item2);
        }
        else if (nine.nineD == 4)
        {
            AddNewItem(item4);
        }
        else if (nine.nineD == 7)
        {
            AddNewItem(item7);
        }
        else if (nine.nineD == 8)
        {
            AddNewItem(item8);
        }

        if (nine.nineE == 1)
        {
            AddNewItem(item1);
        }
        else if (nine.nineE == 2)
        {
            AddNewItem(item2);
        }
        else if (nine.nineE == 4)
        {
            AddNewItem(item4);
        }
        else if (nine.nineE == 7)
        {
            AddNewItem(item7);
        }
        else if (nine.nineE == 8)
        {
            AddNewItem(item8);
        }

        nine.nineA = 0;
        nine.nineB = 0;
        nine.nineC = 0;
        nine.nineD = 0;
        nine.nineE = 0;
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
