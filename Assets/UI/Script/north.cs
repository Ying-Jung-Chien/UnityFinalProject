using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class north : MonoBehaviour
{
    public static int northA = 1;
    public static int northB = 3;
    public static int northC = 0;
    public static int northD = 2;
    public static int northE = 4;
    public static int wrong3 = 0;

    public GameObject pass;
    public GameObject pass1;
    public GameObject fail;
    public GameObject alertui;

    public item item1;
    public item item2;
    public inventory playerInventory;

    public GameObject northA1;
    public GameObject northA2;
    public GameObject northA3;
    public GameObject northA4;
    public GameObject northA5;

    public GameObject northB1;
    public GameObject northB2;
    public GameObject northB3;
    public GameObject northB4;
    public GameObject northB5;

    public GameObject northC1;
    public GameObject northC2;
    public GameObject northC3;
    public GameObject northC4;
    public GameObject northC5;

    public GameObject northD1;
    public GameObject northD2;
    public GameObject northD3;
    public GameObject northD4;
    public GameObject northD5;

    public GameObject northE1;
    public GameObject northE2;
    public GameObject northE3;
    public GameObject northE4;
    public GameObject northE5;
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
        wrong3 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (wrong3 == 0)
        {
            pass.SetActive(true);
            fail.SetActive(false);
        }
        else if (wrong3 == 1)
        {
            pass.SetActive(false);
            pass1.SetActive(false);
            fail.SetActive(true);
            StartCoroutine(ExampleCoroutine());
        }
        else if (wrong3 == 2)
        {
            AddNewItem(item1);
            AddNewItem(item2);
            manager.ReflashItem();
            alertui.SetActive(true);
            DontDestroyVariable.useBox2 = true;
            this.gameObject.SetActive(false);
        }

        if (northA == 0)
        {
            northA1.SetActive(true);
            northA2.SetActive(false);
            northA3.SetActive(false);
            northA4.SetActive(false);
            northA5.SetActive(false);
        }
        else if (northA == 1)
        {
            northA1.SetActive(false);
            northA2.SetActive(true);
            northA3.SetActive(false);
            northA4.SetActive(false);
            northA5.SetActive(false);
        }
        else if (northA == 2)
        {
            northA1.SetActive(false);
            northA2.SetActive(false);
            northA3.SetActive(true);
            northA4.SetActive(false);
            northA5.SetActive(false);
        }
        else if (northA == 3)
        {
            northA1.SetActive(false);
            northA2.SetActive(false);
            northA3.SetActive(false);
            northA4.SetActive(true);
            northA5.SetActive(false);
        }
        else if (northA == 4)
        {
            northA1.SetActive(false);
            northA2.SetActive(false);
            northA3.SetActive(false);
            northA4.SetActive(false);
            northA5.SetActive(true);
        }

        if (northB == 0)
        {
            northB1.SetActive(true);
            northB2.SetActive(false);
            northB3.SetActive(false);
            northB4.SetActive(false);
            northB5.SetActive(false);
        }
        else if (northB == 1)
        {
            northB1.SetActive(false);
            northB2.SetActive(true);
            northB3.SetActive(false);
            northB4.SetActive(false);
            northB5.SetActive(false);
        }
        else if (northB == 2)
        {
            northB1.SetActive(false);
            northB2.SetActive(false);
            northB3.SetActive(true);
            northB4.SetActive(false);
            northB5.SetActive(false);
        }
        else if (northB == 3)
        {
            northB1.SetActive(false);
            northB2.SetActive(false);
            northB3.SetActive(false);
            northB4.SetActive(true);
            northB5.SetActive(false);
        }
        else if (northB == 4)
        {
            northB1.SetActive(false);
            northB2.SetActive(false);
            northB3.SetActive(false);
            northB4.SetActive(false);
            northB5.SetActive(true);
        }

        if (northC == 0)
        {
            northC1.SetActive(true);
            northC2.SetActive(false);
            northC3.SetActive(false);
            northC4.SetActive(false);
            northC5.SetActive(false);
        }
        else if (northC == 1)
        {
            northC1.SetActive(false);
            northC2.SetActive(true);
            northC3.SetActive(false);
            northC4.SetActive(false);
            northC5.SetActive(false);
        }
        else if (northC == 2)
        {
            northC1.SetActive(false);
            northC2.SetActive(false);
            northC3.SetActive(true);
            northC4.SetActive(false);
            northC5.SetActive(false);
        }
        else if (northC == 3)
        {
            northC1.SetActive(false);
            northC2.SetActive(false);
            northC3.SetActive(false);
            northC4.SetActive(true);
            northC5.SetActive(false);
        }
        else if (northC == 4)
        {
            northC1.SetActive(false);
            northC2.SetActive(false);
            northC3.SetActive(false);
            northC4.SetActive(false);
            northC5.SetActive(true);
        }

        if (northD == 0)
        {
            northD1.SetActive(true);
            northD2.SetActive(false);
            northD3.SetActive(false);
            northD4.SetActive(false);
            northD5.SetActive(false);
        }
        else if (northD == 1)
        {
            northD1.SetActive(false);
            northD2.SetActive(true);
            northD3.SetActive(false);
            northD4.SetActive(false);
            northD5.SetActive(false);
        }
        else if (northD == 2)
        {
            northD1.SetActive(false);
            northD2.SetActive(false);
            northD3.SetActive(true);
            northD4.SetActive(false);
            northD5.SetActive(false);
        }
        else if (northD == 3)
        {
            northD1.SetActive(false);
            northD2.SetActive(false);
            northD3.SetActive(false);
            northD4.SetActive(true);
            northD5.SetActive(false);
        }
        else if (northD == 4)
        {
            northD1.SetActive(false);
            northD2.SetActive(false);
            northD3.SetActive(false);
            northD4.SetActive(false);
            northD5.SetActive(true);
        }

        if (northE == 0)
        {
            northE1.SetActive(true);
            northE2.SetActive(false);
            northE3.SetActive(false);
            northE4.SetActive(false);
            northE5.SetActive(false);
        }
        else if (northE == 1)
        {
            northE1.SetActive(false);
            northE2.SetActive(true);
            northE3.SetActive(false);
            northE4.SetActive(false);
            northE5.SetActive(false);
        }
        else if (northE == 2)
        {
            northE1.SetActive(false);
            northE2.SetActive(false);
            northE3.SetActive(true);
            northE4.SetActive(false);
            northE5.SetActive(false);
        }
        else if (northE == 3)
        {
            northE1.SetActive(false);
            northE2.SetActive(false);
            northE3.SetActive(false);
            northE4.SetActive(true);
            northE5.SetActive(false);
        }
        else if (northE == 4)
        {
            northE1.SetActive(false);
            northE2.SetActive(false);
            northE3.SetActive(false);
            northE4.SetActive(false);
            northE5.SetActive(true);
        }
    }
}
