using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class manager : MonoBehaviour
{
    static manager instance;
    public static int status = 0;

    public inventory mybag;
    public GameObject slotGrid;
    public slot slotPrefab;
    public TextMeshProUGUI itemInfo;
    public inventory playerInventory;

    private int check = 0;

    void Awake()
    {
        if(instance != null) Destroy(this);
        instance = this;
    }

    /*private void OnEnable()
    {
        //ReflashItem();
    }*/
    void Update()
    {
        if(check == 0)
        {
            ReflashItem();
            instance.itemInfo.text = "";
            check = 1;
        }
    }

    public static void UpdateItemUse()
    {
        for (int i = 0; i < instance.mybag.itemList.Count; i++)
        {
            if (instance.mybag.itemList[i].itemactive == 1)
            {
                if (instance.mybag.itemList[i].itemType == 0)
                {
                    instance.mybag.itemList[i].itemHeld -= 1;
                }else if (instance.mybag.itemList[i].name == "key" && status == 1)
                {
                    instance.mybag.itemList[i].itemHeld -= 1;
                    status = 0;
                }
                else
                {
                    UpdateItemInfo("使用無效", instance.mybag.itemList[i]);
                }

                if(instance.mybag.itemList[i].itemHeld == 0)
                {
                    UpdateItemInfo("", instance.mybag.itemList[i]);
                }
            } 
        }
        ReflashItem();
    }

    public static void UpdateItemInfo(string IntoDescription, item item)
    {
        instance.itemInfo.text = IntoDescription;
        for (int i = 0; i < instance.mybag.itemList.Count; i++)
        {
            instance.mybag.itemList[i].itemactive = 0;
        }
        if (IntoDescription != "") item.itemactive = 1;
        ReflashItem();
    }

    public static void CreateNewItem(item item)
    {
        slot newitem = Instantiate(instance.slotPrefab, instance.slotGrid.transform.position, Quaternion.identity);
        newitem.gameObject.transform.SetParent(instance.slotGrid.transform);
        newitem.slotitem = item;
        if (item.itemactive == 1)
        {
            newitem.slotImage.sprite = item.itemimage1;
            newitem.slotNumber.text = item.itemHeld.ToString();
        }
        else
        {
            newitem.slotImage.sprite = item.itemimage;
            newitem.slotNumber.text = item.itemHeld.ToString();
        }
    }

    public static void ReflashItem()
    {
        for(int i = 0; i < instance.slotGrid.transform.childCount; i++)
        {
            if (instance.slotGrid.transform.childCount == 0) break;
            Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
        }

        for(int i = 0;i < instance.mybag.itemList.Count; i++)
        {
            if(instance.mybag.itemList[i].itemHeld != 0)
            {
                CreateNewItem(instance.mybag.itemList[i]);
            }
        }
    }
}
