using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nine : MonoBehaviour
{
    public static int nineA = 0;
    public static int nineB = 0;
    public static int nineC = 0;
    public static int nineD = 0;
    public static int nineE = 0;
    public static int wrong5 = 0;

    public GameObject pass;
    public GameObject reset;
    public GameObject pass1;
    public GameObject reset1;
    public GameObject fail;

    public item item1;
    public item item2;
    public item item4;
    public item item7;
    public item item8;
    public item item9;
    public inventory playerInventory;

    public GameObject nineA0;
    public GameObject nineA1;
    public GameObject nineA2;
    public GameObject nineA4;
    public GameObject nineA7;
    public GameObject nineA8;

    public GameObject nineB0;
    public GameObject nineB1;
    public GameObject nineB2;
    public GameObject nineB4;
    public GameObject nineB7;
    public GameObject nineB8;

    public GameObject nineC0;
    public GameObject nineC1;
    public GameObject nineC2;
    public GameObject nineC4;
    public GameObject nineC7;
    public GameObject nineC8;

    public GameObject nineD0;
    public GameObject nineD1;
    public GameObject nineD2;
    public GameObject nineD4;
    public GameObject nineD7;
    public GameObject nineD8;

    public GameObject nineE0;
    public GameObject nineE1;
    public GameObject nineE2;
    public GameObject nineE4;
    public GameObject nineE7;
    public GameObject nineE8;
    // Start is called before the first frame update
    void Start()
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

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(2);
        resetall();
        this.gameObject.SetActive(false);
        wrong5 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (wrong5 == 0)
        {
            pass.SetActive(true);
            reset.SetActive(true);
            fail.SetActive(false);
        }
        else if (wrong5 == 1)
        {
            pass.SetActive(false);
            reset.SetActive(false);
            pass1.SetActive(false);
            reset1.SetActive(false);
            fail.SetActive(true);
            StartCoroutine(ExampleCoroutine());
        }
        else if (wrong5 == 2)
        {
            item9.itemHeld = 0;
            item9.itemactive = 0;
            manager.ReflashItem();
            DontDestroyVariable.useDoor2 = true;
            this.gameObject.SetActive(false);
        }

        if (nineA == 0)
        {
            nineA0.SetActive(true);
            nineA1.SetActive(false);
            nineA2.SetActive(false);
            nineA4.SetActive(false);
            nineA7.SetActive(false);
            nineA8.SetActive(false);
        }
        else if (nineA == 1)
        {
            nineA0.SetActive(false);
            nineA1.SetActive(true);
            nineA2.SetActive(false);
            nineA4.SetActive(false);
            nineA7.SetActive(false);
            nineA8.SetActive(false);
        }
        else if (nineA == 2)
        {
            nineA0.SetActive(false);
            nineA1.SetActive(false);
            nineA2.SetActive(true);
            nineA4.SetActive(false);
            nineA7.SetActive(false);
            nineA8.SetActive(false);
        }
        else if (nineA == 4)
        {
            nineA0.SetActive(false);
            nineA1.SetActive(false);
            nineA2.SetActive(false);
            nineA4.SetActive(true);
            nineA7.SetActive(false);
            nineA8.SetActive(false);
        }
        else if (nineA == 7)
        {
            nineA0.SetActive(false);
            nineA1.SetActive(false);
            nineA2.SetActive(false);
            nineA4.SetActive(false);
            nineA7.SetActive(true);
            nineA8.SetActive(false);
        }
        else if (nineA == 8)
        {
            nineA0.SetActive(false);
            nineA1.SetActive(false);
            nineA2.SetActive(false);
            nineA4.SetActive(false);
            nineA7.SetActive(false);
            nineA8.SetActive(true);
        }

        if (nineB == 0)
        {
            nineB0.SetActive(true);
            nineB1.SetActive(false);
            nineB2.SetActive(false);
            nineB4.SetActive(false);
            nineB7.SetActive(false);
            nineB8.SetActive(false);
        }
        else if (nineB == 1)
        {
            nineB0.SetActive(false);
            nineB1.SetActive(true);
            nineB2.SetActive(false);
            nineB4.SetActive(false);
            nineB7.SetActive(false);
            nineB8.SetActive(false);
        }
        else if (nineB == 2)
        {
            nineB0.SetActive(false);
            nineB1.SetActive(false);
            nineB2.SetActive(true);
            nineB4.SetActive(false);
            nineB7.SetActive(false);
            nineB8.SetActive(false);
        }
        else if (nineB == 4)
        {
            nineB0.SetActive(false);
            nineB1.SetActive(false);
            nineB2.SetActive(false);
            nineB4.SetActive(true);
            nineB7.SetActive(false);
            nineB8.SetActive(false);
        }
        else if (nineB == 7)
        {
            nineB0.SetActive(false);
            nineB1.SetActive(false);
            nineB2.SetActive(false);
            nineB4.SetActive(false);
            nineB7.SetActive(true);
            nineB8.SetActive(false);
        }
        else if (nineB == 8)
        {
            nineB0.SetActive(false);
            nineB1.SetActive(false);
            nineB2.SetActive(false);
            nineB4.SetActive(false);
            nineB7.SetActive(false);
            nineB8.SetActive(true);
        }

        if (nineC == 0)
        {
            nineC0.SetActive(true);
            nineC1.SetActive(false);
            nineC2.SetActive(false);
            nineC4.SetActive(false);
            nineC7.SetActive(false);
            nineC8.SetActive(false);
        }
        else if (nineC == 1)
        {
            nineC0.SetActive(false);
            nineC1.SetActive(true);
            nineC2.SetActive(false);
            nineC4.SetActive(false);
            nineC7.SetActive(false);
            nineC8.SetActive(false);
        }
        else if (nineC == 2)
        {
            nineC0.SetActive(false);
            nineC1.SetActive(false);
            nineC2.SetActive(true);
            nineC4.SetActive(false);
            nineC7.SetActive(false);
            nineC8.SetActive(false);
        }
        else if (nineC == 4)
        {
            nineC0.SetActive(false);
            nineC1.SetActive(false);
            nineC2.SetActive(false);
            nineC4.SetActive(true);
            nineC7.SetActive(false);
            nineC8.SetActive(false);
        }
        else if (nineC == 7)
        {
            nineC0.SetActive(false);
            nineC1.SetActive(false);
            nineC2.SetActive(false);
            nineC4.SetActive(false);
            nineC7.SetActive(true);
            nineC8.SetActive(false);
        }
        else if (nineC == 8)
        {
            nineC0.SetActive(false);
            nineC1.SetActive(false);
            nineC2.SetActive(false);
            nineC4.SetActive(false);
            nineC7.SetActive(false);
            nineC8.SetActive(true);
        }

        if (nineD == 0)
        {
            nineD0.SetActive(true);
            nineD1.SetActive(false);
            nineD2.SetActive(false);
            nineD4.SetActive(false);
            nineD7.SetActive(false);
            nineD8.SetActive(false);
        }
        else if (nineD == 1)
        {
            nineD0.SetActive(false);
            nineD1.SetActive(true);
            nineD2.SetActive(false);
            nineD4.SetActive(false);
            nineD7.SetActive(false);
            nineD8.SetActive(false);
        }
        else if (nineD == 2)
        {
            nineD0.SetActive(false);
            nineD1.SetActive(false);
            nineD2.SetActive(true);
            nineD4.SetActive(false);
            nineD7.SetActive(false);
            nineD8.SetActive(false);
        }
        else if (nineD == 4)
        {
            nineD0.SetActive(false);
            nineD1.SetActive(false);
            nineD2.SetActive(false);
            nineD4.SetActive(true);
            nineD7.SetActive(false);
            nineD8.SetActive(false);
        }
        else if (nineD == 7)
        {
            nineD0.SetActive(false);
            nineD1.SetActive(false);
            nineD2.SetActive(false);
            nineD4.SetActive(false);
            nineD7.SetActive(true);
            nineD8.SetActive(false);
        }
        else if (nineD == 8)
        {
            nineD0.SetActive(false);
            nineD1.SetActive(false);
            nineD2.SetActive(false);
            nineD4.SetActive(false);
            nineD7.SetActive(false);
            nineD8.SetActive(true);
        }

        if (nineE == 0)
        {
            nineE0.SetActive(true);
            nineE1.SetActive(false);
            nineE2.SetActive(false);
            nineE4.SetActive(false);
            nineE7.SetActive(false);
            nineE8.SetActive(false);
        }
        else if (nineE == 1)
        {
            nineE0.SetActive(false);
            nineE1.SetActive(true);
            nineE2.SetActive(false);
            nineE4.SetActive(false);
            nineE7.SetActive(false);
            nineE8.SetActive(false);
        }
        else if (nineE == 2)
        {
            nineE0.SetActive(false);
            nineE1.SetActive(false);
            nineE2.SetActive(true);
            nineE4.SetActive(false);
            nineE7.SetActive(false);
            nineE8.SetActive(false);
        }
        else if (nineE == 4)
        {
            nineE0.SetActive(false);
            nineE1.SetActive(false);
            nineE2.SetActive(false);
            nineE4.SetActive(true);
            nineE7.SetActive(false);
            nineE8.SetActive(false);
        }
        else if (nineE == 7)
        {
            nineE0.SetActive(false);
            nineE1.SetActive(false);
            nineE2.SetActive(false);
            nineE4.SetActive(false);
            nineE7.SetActive(true);
            nineE8.SetActive(false);
        }
        else if (nineE == 8)
        {
            nineE0.SetActive(false);
            nineE1.SetActive(false);
            nineE2.SetActive(false);
            nineE4.SetActive(false);
            nineE7.SetActive(false);
            nineE8.SetActive(true);
        }
    }

    private void resetall()
    {
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
}
