using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class reset2 : MonoBehaviour, IPointerClickHandler
{
    public UnityEvent rightClick;

    public item item1;
    public item item2;
    public item item3;
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
        if (BossTest.bossA == 0)
        {
            AddNewItem(item1);
        }
        else if (BossTest.bossA == 1)
        {
            AddNewItem(item2);
        }
        else if (BossTest.bossA == 2)
        {
            AddNewItem(item3);
        }

        if (BossTest.bossB == 0)
        {
            AddNewItem(item1);
        }
        else if (BossTest.bossB == 1)
        {
            AddNewItem(item2);
        }
        else if (BossTest.bossB == 2)
        {
            AddNewItem(item3);
        }

        if (BossTest.bossC == 0)
        {
            AddNewItem(item1);
        }
        else if (BossTest.bossC == 1)
        {
            AddNewItem(item2);
        }
        else if (BossTest.bossC == 2)
        {
            AddNewItem(item3);
        }

        BossTest.bossA = -1;
        BossTest.bossB = -1;
        BossTest.bossC = -1;
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
