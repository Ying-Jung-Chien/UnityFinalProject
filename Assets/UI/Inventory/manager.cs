using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class manager : MonoBehaviour
{
    public static manager instance;
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

    public static void UpdateItemUse(int k)
    {
        for (int i = 0; i < instance.mybag.itemList.Count; i++)
        {
            if (instance.mybag.itemList[i].itemactive == 1)
            {
                if (instance.mybag.itemList[i].name == "eye" && k == 1)
                {
                    instance.mybag.itemList[i].itemHeld -= 1;
                    DontDestroyVariable.useHorseEye = true;
                }
                else if (instance.mybag.itemList[i].name == "key" && k == 2)
                {
                    instance.mybag.itemList[i].itemHeld -= 1;
                    DontDestroyVariable.useKey = true;
                }
                else if (k == 3 && eight.eight2 == 0)
                {
                    if (instance.mybag.itemList[i].name == "2" || instance.mybag.itemList[i].name == "3" || instance.mybag.itemList[i].name == "4" || instance.mybag.itemList[i].name == "5" || instance.mybag.itemList[i].name == "6" || instance.mybag.itemList[i].name == "8")
                    {
                        instance.mybag.itemList[i].itemHeld -= 1;
                        eight.eight2 = instance.mybag.itemList[i].itemType;
                    }
                }
                else if (k == 4 && eight.eight3 == 0)
                {
                    if (instance.mybag.itemList[i].name == "2" || instance.mybag.itemList[i].name == "3" || instance.mybag.itemList[i].name == "4" || instance.mybag.itemList[i].name == "5" || instance.mybag.itemList[i].name == "6" || instance.mybag.itemList[i].name == "8")
                    {
                        instance.mybag.itemList[i].itemHeld -= 1;
                        eight.eight3 = instance.mybag.itemList[i].itemType;
                    }
                }
                else if (k == 5 && eight.eight4 == 0)
                {
                    if (instance.mybag.itemList[i].name == "2" || instance.mybag.itemList[i].name == "3" || instance.mybag.itemList[i].name == "4" || instance.mybag.itemList[i].name == "5" || instance.mybag.itemList[i].name == "6" || instance.mybag.itemList[i].name == "8")
                    {
                        instance.mybag.itemList[i].itemHeld -= 1;
                        eight.eight4 = instance.mybag.itemList[i].itemType;
                    }
                }
                else if (k == 6 && eight.eight5 == 0)
                {
                    if (instance.mybag.itemList[i].name == "2" || instance.mybag.itemList[i].name == "3" || instance.mybag.itemList[i].name == "4" || instance.mybag.itemList[i].name == "5" || instance.mybag.itemList[i].name == "6" || instance.mybag.itemList[i].name == "8")
                    {
                        instance.mybag.itemList[i].itemHeld -= 1;
                        eight.eight5 = instance.mybag.itemList[i].itemType;
                    }
                }
                else if (k == 7 && eight.eight6 == 0)
                {
                    if (instance.mybag.itemList[i].name == "2" || instance.mybag.itemList[i].name == "3" || instance.mybag.itemList[i].name == "4" || instance.mybag.itemList[i].name == "5" || instance.mybag.itemList[i].name == "6" || instance.mybag.itemList[i].name == "8")
                    {
                        instance.mybag.itemList[i].itemHeld -= 1;
                        eight.eight6 = instance.mybag.itemList[i].itemType;
                    }
                }
                else if (k == 8 && eight.eight8 == 0)
                {
                    if (instance.mybag.itemList[i].name == "2" || instance.mybag.itemList[i].name == "3" || instance.mybag.itemList[i].name == "4" || instance.mybag.itemList[i].name == "5" || instance.mybag.itemList[i].name == "6" || instance.mybag.itemList[i].name == "8")
                    {
                        instance.mybag.itemList[i].itemHeld -= 1;
                        eight.eight8 = instance.mybag.itemList[i].itemType;
                    }
                }
                else if (k == 9 && nine.nineA == 0)
                {
                    if (instance.mybag.itemList[i].name == "nine1" || instance.mybag.itemList[i].name == "nine2" || instance.mybag.itemList[i].name == "nine4" || instance.mybag.itemList[i].name == "nine7" || instance.mybag.itemList[i].name == "nine8")
                    {
                        instance.mybag.itemList[i].itemHeld -= 1;
                        nine.nineA = instance.mybag.itemList[i].itemType;
                    }
                }
                else if (k == 10 && nine.nineB == 0)
                {
                    if (instance.mybag.itemList[i].name == "nine1" || instance.mybag.itemList[i].name == "nine2" || instance.mybag.itemList[i].name == "nine4" || instance.mybag.itemList[i].name == "nine7" || instance.mybag.itemList[i].name == "nine8")
                    {
                        instance.mybag.itemList[i].itemHeld -= 1;
                        nine.nineB = instance.mybag.itemList[i].itemType;
                    }
                }
                else if (k == 11 && nine.nineC == 0)
                {
                    if (instance.mybag.itemList[i].name == "nine1" || instance.mybag.itemList[i].name == "nine2" || instance.mybag.itemList[i].name == "nine4" || instance.mybag.itemList[i].name == "nine7" || instance.mybag.itemList[i].name == "nine8")
                    {
                        instance.mybag.itemList[i].itemHeld -= 1;
                        nine.nineC = instance.mybag.itemList[i].itemType;
                    }
                }
                else if (k == 12 && nine.nineD == 0)
                {
                    if (instance.mybag.itemList[i].name == "nine1" || instance.mybag.itemList[i].name == "nine2" || instance.mybag.itemList[i].name == "nine4" || instance.mybag.itemList[i].name == "nine7" || instance.mybag.itemList[i].name == "nine8")
                    {
                        instance.mybag.itemList[i].itemHeld -= 1;
                        nine.nineD = instance.mybag.itemList[i].itemType;
                    }
                }
                else if (k == 13 && nine.nineE == 0)
                {
                    if (instance.mybag.itemList[i].name == "nine1" || instance.mybag.itemList[i].name == "nine2" || instance.mybag.itemList[i].name == "nine4" || instance.mybag.itemList[i].name == "nine7" || instance.mybag.itemList[i].name == "nine8")
                    {
                        instance.mybag.itemList[i].itemHeld -= 1;
                        nine.nineE = instance.mybag.itemList[i].itemType;
                    }
                }
                else if (k == 14)
                {
                    if (instance.mybag.itemList[i].name == "paper")
                    {
                        DontDestroyVariable.useBrazier = true;
                        instance.mybag.itemList[i].itemHeld -= 1;
                    }
                }
                else if (k == 15)
                {
                    if (instance.mybag.itemList[i].name == "key1")
                    {
                        DontDestroyVariable.useKey2 = true;
                        instance.mybag.itemList[i].itemHeld -= 1;
                    }
                }

                if (instance.mybag.itemList[i].itemHeld == 0)
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
        if (item.itemactive == 1)
        {
            if (item.name == "eight")
            {
                passwordshow.eightshow = true;
            }
            else if (item.name == "password")
            {
                passwordshow.passwordshow1 = true;
            }
            else if (item.name == "paper1")
            {
                passwordshow.problemshow = true;
            }
            else if (item.name == "nine")
            {
                passwordshow.stoneshow = true;
            }
        }
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

    public static void resetbag()
    {
        for (int i = 0; i < instance.slotGrid.transform.childCount; i++)
        {
            if (instance.slotGrid.transform.childCount == 0) break;
            Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < instance.mybag.itemList.Count; i++)
        {
            instance.mybag.itemList[i].itemHeld = 1;
            instance.mybag.itemList[i].itemactive = 0;
        }

        instance.mybag.itemList.Clear();
    }
    
}
