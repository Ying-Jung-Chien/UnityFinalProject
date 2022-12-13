using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse : MonoBehaviour
{
    public GameObject testui;
    public GameObject testui1;
    public item key;
    public inventory playerInventory;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject obj = hit.collider.gameObject;
                if (obj.tag == "test")
                {
                    if(closeui.check == 1)
                    {
                        testui.gameObject.SetActive(true);
                        closeui.check = 0;
                    }
                    else
                    {
                        testui.gameObject.SetActive(true);
                        testui1.gameObject.SetActive(true);
                        manager.status = 1;
                    }
                    
                }else if (obj.tag == "key")
                {
                    obj.gameObject.SetActive(false);
                    AddNewItem(key);
                }

            }
        }
    }

    public void AddNewItem(item thisItem)
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
