using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addtest1 : MonoBehaviour
{
    public item thisItem;
    public inventory playerInventory;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            AddNewItem();
        }
    }

    public void AddNewItem()
    {
        if (!playerInventory.itemList.Contains(thisItem))
        {
            playerInventory.itemList.Add(thisItem);
        }
        else
        {
            thisItem.itemHeld += 1;
        }
        manager.ReflashItem();
    }
}
