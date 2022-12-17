using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class board : MonoBehaviour
{
    public static int boardA = 0;
    public static int wrong6 = 0;

    public GameObject pass;
    public GameObject pass1;
    public GameObject fail;
    public GameObject alertui;

    public item item1;
    public item item2;
    public inventory playerInventory;

    public GameObject boardA0;
    public GameObject boardA1;
    public GameObject boardA2;
    public GameObject boardA3;
    public GameObject boardA4;
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
        item1.itemHeld = 1;
        manager.ReflashItem();
        wrong6 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (wrong6 == 0)
        {
            pass.SetActive(true);
            fail.SetActive(false);
        }
        else if (wrong6 == 1)
        {
            pass.SetActive(false);
            pass1.SetActive(false);
            fail.SetActive(true);
            StartCoroutine(ExampleCoroutine());
        }
        else if (wrong6 == 2)
        {
            alertui.SetActive(true);
            AddNewItem(item2);
            manager.ReflashItem();
            DontDestroyVariable.useBoard = true;
            this.gameObject.SetActive(false);
        }

        if (boardA == 0)
        {
            boardA0.SetActive(false);
            boardA1.SetActive(false);
            boardA2.SetActive(false);
            boardA3.SetActive(false);
            boardA4.SetActive(false);
        }
        else if (boardA == 1)
        {
            boardA0.SetActive(true);
            boardA1.SetActive(false);
            boardA2.SetActive(false);
            boardA3.SetActive(false);
            boardA4.SetActive(false);
        }
        else if (boardA == 2)
        {
            boardA0.SetActive(false);
            boardA1.SetActive(true);
            boardA2.SetActive(false);
            boardA3.SetActive(false);
            boardA4.SetActive(false);
        }
        else if (boardA == 3)
        {
            boardA0.SetActive(false);
            boardA1.SetActive(false);
            boardA2.SetActive(true);
            boardA3.SetActive(false);
            boardA4.SetActive(false);
        }
        else if (boardA == 4)
        {
            boardA0.SetActive(false);
            boardA1.SetActive(false);
            boardA2.SetActive(false);
            boardA3.SetActive(true);
            boardA4.SetActive(false);
        }
        else if (boardA == 5)
        {
            boardA0.SetActive(false);
            boardA1.SetActive(false);
            boardA2.SetActive(false);
            boardA3.SetActive(false);
            boardA4.SetActive(true);
        }
    }
}
