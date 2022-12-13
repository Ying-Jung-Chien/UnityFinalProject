using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flower : MonoBehaviour
{
    public static int flowerA = 2;
    public static int flowerB = 0;
    public static int flowerC = 1;
    public static int flowerD = 3;
    public static int wrong4 = 0;

    public GameObject pass;
    public GameObject pass1;
    public GameObject fail;
    public GameObject alertui;

    public item item1;
    public item item2;
    public item item3;
    public inventory playerInventory;

    public GameObject flowerA1;
    public GameObject flowerA2;
    public GameObject flowerA3;
    public GameObject flowerA4;

    public GameObject flowerB1;
    public GameObject flowerB2;
    public GameObject flowerB3;
    public GameObject flowerB4;

    public GameObject flowerC1;
    public GameObject flowerC2;
    public GameObject flowerC3;
    public GameObject flowerC4;

    public GameObject flowerD1;
    public GameObject flowerD2;
    public GameObject flowerD3;
    public GameObject flowerD4;
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
        this.gameObject.SetActive(false);
        wrong4 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (wrong4 == 0)
        {
            pass.SetActive(true);
            fail.SetActive(false);
        }
        else if (wrong4 == 1)
        {
            pass.SetActive(false);
            pass1.SetActive(false);
            fail.SetActive(true);
            StartCoroutine(ExampleCoroutine());
        }
        else if (wrong4 == 2)
        {
            item3.itemHeld = 0;
            item3.itemactive = 0;
            AddNewItem(item1);
            AddNewItem(item2);
            manager.ReflashItem();
            alertui.SetActive(true);
            DontDestroyVariable.useBox1 = true;
            this.gameObject.SetActive(false);
        }

        if (flowerA == 0)
        {
            flowerA1.SetActive(true);
            flowerA2.SetActive(false);
            flowerA3.SetActive(false);
            flowerA4.SetActive(false);
        }
        else if (flowerA == 1)
        {
            flowerA1.SetActive(false);
            flowerA2.SetActive(true);
            flowerA3.SetActive(false);
            flowerA4.SetActive(false);
        }
        else if (flowerA == 2)
        {
            flowerA1.SetActive(false);
            flowerA2.SetActive(false);
            flowerA3.SetActive(true);
            flowerA4.SetActive(false);
        }
        else if (flowerA == 3)
        {
            flowerA1.SetActive(false);
            flowerA2.SetActive(false);
            flowerA3.SetActive(false);
            flowerA4.SetActive(true);
        }

        if (flowerB == 0)
        {
            flowerB1.SetActive(true);
            flowerB2.SetActive(false);
            flowerB3.SetActive(false);
            flowerB4.SetActive(false);
        }
        else if (flowerB == 1)
        {
            flowerB1.SetActive(false);
            flowerB2.SetActive(true);
            flowerB3.SetActive(false);
            flowerB4.SetActive(false);
        }
        else if (flowerB == 2)
        {
            flowerB1.SetActive(false);
            flowerB2.SetActive(false);
            flowerB3.SetActive(true);
            flowerB4.SetActive(false);
        }
        else if (flowerB == 3)
        {
            flowerB1.SetActive(false);
            flowerB2.SetActive(false);
            flowerB3.SetActive(false);
            flowerB4.SetActive(true);
        }

        if (flowerC == 0)
        {
            flowerC1.SetActive(true);
            flowerC2.SetActive(false);
            flowerC3.SetActive(false);
            flowerC4.SetActive(false);
        }
        else if (flowerC == 1)
        {
            flowerC1.SetActive(false);
            flowerC2.SetActive(true);
            flowerC3.SetActive(false);
            flowerC4.SetActive(false);
        }
        else if (flowerC == 2)
        {
            flowerC1.SetActive(false);
            flowerC2.SetActive(false);
            flowerC3.SetActive(true);
            flowerC4.SetActive(false);
        }
        else if (flowerC == 3)
        {
            flowerC1.SetActive(false);
            flowerC2.SetActive(false);
            flowerC3.SetActive(false);
            flowerC4.SetActive(true);
        }

        if (flowerD == 0)
        {
            flowerD1.SetActive(true);
            flowerD2.SetActive(false);
            flowerD3.SetActive(false);
            flowerD4.SetActive(false);
        }
        else if (flowerD == 1)
        {
            flowerD1.SetActive(false);
            flowerD2.SetActive(true);
            flowerD3.SetActive(false);
            flowerD4.SetActive(false);
        }
        else if (flowerD == 2)
        {
            flowerD1.SetActive(false);
            flowerD2.SetActive(false);
            flowerD3.SetActive(true);
            flowerD4.SetActive(false);
        }
        else if (flowerD == 3)
        {
            flowerD1.SetActive(false);
            flowerD2.SetActive(false);
            flowerD3.SetActive(false);
            flowerD4.SetActive(true);
        }
    }
}
