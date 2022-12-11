using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class password : MonoBehaviour
{
    public static int passwordA = 3;
    public static int passwordB = 1;
    public static int passwordC = 0;
    public static int wrong = 0;
    
    public GameObject pass;
    public GameObject pass1;
    public GameObject fail;
    public GameObject alertui;

    public item item1;
    public item item2;
    public item item3;
    public inventory playerInventory;

    public GameObject passwordA1;
    public GameObject passwordA2;
    public GameObject passwordA3;
    public GameObject passwordA4;
    public GameObject passwordA5;

    public GameObject passwordB1;
    public GameObject passwordB2;
    public GameObject passwordB3;
    public GameObject passwordB4;
    public GameObject passwordB5;

    public GameObject passwordC1;
    public GameObject passwordC2;
    public GameObject passwordC3;
    public GameObject passwordC4;
    public GameObject passwordC5;
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
        wrong = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (wrong == 0)
        {
            pass.SetActive(true);
            fail.SetActive(false);
        }
        else if (wrong == 1)
        {
            pass.SetActive(false);
            pass1.SetActive(false);
            fail.SetActive(true);
            StartCoroutine(ExampleCoroutine());
        }
        else if (wrong == 2)
        {
            AddNewItem(item1);
            AddNewItem(item2);
            item3.itemHeld = 0;
            item3.itemactive = 0;
            manager.ReflashItem();
            alertui.SetActive(true);
            DontDestroyVariable.usePassword = true;
            this.gameObject.SetActive(false);
        }

        if (passwordA == 0)
        {
            passwordA1.SetActive(true);
            passwordA2.SetActive(false);
            passwordA3.SetActive(false);
            passwordA4.SetActive(false);
            passwordA5.SetActive(false);
        }
        else if (passwordA == 1)
        {
            passwordA1.SetActive(false);
            passwordA2.SetActive(true);
            passwordA3.SetActive(false);
            passwordA4.SetActive(false);
            passwordA5.SetActive(false);
        }
        else if (passwordA == 2)
        {
            passwordA1.SetActive(false);
            passwordA2.SetActive(false);
            passwordA3.SetActive(true);
            passwordA4.SetActive(false);
            passwordA5.SetActive(false);
        }
        else if (passwordA == 3)
        {
            passwordA1.SetActive(false);
            passwordA2.SetActive(false);
            passwordA3.SetActive(false);
            passwordA4.SetActive(true);
            passwordA5.SetActive(false);
        }
        else if (passwordA == 4)
        {
            passwordA1.SetActive(false);
            passwordA2.SetActive(false);
            passwordA3.SetActive(false);
            passwordA4.SetActive(false);
            passwordA5.SetActive(true);
        }

        if (passwordB == 0)
        {
            passwordB1.SetActive(true);
            passwordB2.SetActive(false);
            passwordB3.SetActive(false);
            passwordB4.SetActive(false);
            passwordB5.SetActive(false);
        }
        else if (passwordB == 1)
        {
            passwordB1.SetActive(false);
            passwordB2.SetActive(true);
            passwordB3.SetActive(false);
            passwordB4.SetActive(false);
            passwordB5.SetActive(false);
        }
        else if (passwordB == 2)
        {
            passwordB1.SetActive(false);
            passwordB2.SetActive(false);
            passwordB3.SetActive(true);
            passwordB4.SetActive(false);
            passwordB5.SetActive(false);
        }
        else if (passwordB == 3)
        {
            passwordB1.SetActive(false);
            passwordB2.SetActive(false);
            passwordB3.SetActive(false);
            passwordB4.SetActive(true);
            passwordB5.SetActive(false);
        }
        else if (passwordB == 4)
        {
            passwordB1.SetActive(false);
            passwordB2.SetActive(false);
            passwordB3.SetActive(false);
            passwordB4.SetActive(false);
            passwordB5.SetActive(true);
        }

        if (passwordC == 0)
        {
            passwordC1.SetActive(true);
            passwordC2.SetActive(false);
            passwordC3.SetActive(false);
            passwordC4.SetActive(false);
            passwordC5.SetActive(false);
        }
        else if (passwordC == 1)
        {
            passwordC1.SetActive(false);
            passwordC2.SetActive(true);
            passwordC3.SetActive(false);
            passwordC4.SetActive(false);
            passwordC5.SetActive(false);
        }
        else if (passwordC == 2)
        {
            passwordC1.SetActive(false);
            passwordC2.SetActive(false);
            passwordC3.SetActive(true);
            passwordC4.SetActive(false);
            passwordC5.SetActive(false);
        }
        else if (passwordC == 3)
        {
            passwordC1.SetActive(false);
            passwordC2.SetActive(false);
            passwordC3.SetActive(false);
            passwordC4.SetActive(true);
            passwordC5.SetActive(false);
        }
        else if (passwordC == 4)
        {
            passwordC1.SetActive(false);
            passwordC2.SetActive(false);
            passwordC3.SetActive(false);
            passwordC4.SetActive(false);
            passwordC5.SetActive(true);
        }
    }
}
