using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTest : MonoBehaviour
{
    public static int bossA = -1;
    public static int bossB = -1;
    public static int bossC = -1;
    public static int wrong100 = 0;

    public GameObject pass;
    public GameObject reset;
    public GameObject pass1;
    public GameObject reset1;
    public GameObject fail;

    public item item1;
    public item item2;
    public item item3;
    public inventory playerInventory;

    public GameObject bossA0;
    public GameObject bossA1;
    public GameObject bossA2;

    public GameObject bossB0;
    public GameObject bossB1;
    public GameObject bossB2;

    public GameObject bossC0;
    public GameObject bossC1;
    public GameObject bossC2;
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
        wrong100 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (wrong100 == 0)
        {
            pass.SetActive(true);
            reset.SetActive(true);
            fail.SetActive(false);
        }
        else if (wrong100 == 1)
        {
            pass.SetActive(false);
            reset.SetActive(false);
            pass1.SetActive(false);
            reset1.SetActive(false);
            fail.SetActive(true);
            StartCoroutine(ExampleCoroutine());
        }
        else if (wrong100 == 2)
        {
            manager.ReflashItem();
            DontDestroyVariable.goBoss = true;
            this.gameObject.SetActive(false);
        }

        if (bossA == -1)
        {
            bossA0.SetActive(false);
            bossA1.SetActive(false);
            bossA2.SetActive(false);
        }
        else if (bossA == 0)
        {
            bossA0.SetActive(true);
            bossA1.SetActive(false);
            bossA2.SetActive(false);
        }
        else if (bossA == 1)
        {
            bossA0.SetActive(false);
            bossA1.SetActive(true);
            bossA2.SetActive(false);
        }
        else if (bossA == 2)
        {
            bossA0.SetActive(false);
            bossA1.SetActive(false);
            bossA2.SetActive(true);
        }

        if (bossB == -1)
        {
            bossB0.SetActive(false);
            bossB1.SetActive(false);
            bossB2.SetActive(false);
        }
        else if (bossB == 0)
        {
            bossB0.SetActive(true);
            bossB1.SetActive(false);
            bossB2.SetActive(false);
        }
        else if (bossB == 1)
        {
            bossB0.SetActive(false);
            bossB1.SetActive(true);
            bossB2.SetActive(false);
        }
        else if (bossB == 2)
        {
            bossB0.SetActive(false);
            bossB1.SetActive(false);
            bossB2.SetActive(true);
        }

        if (bossC == -1)
        {
            bossC0.SetActive(false);
            bossC1.SetActive(false);
            bossC2.SetActive(false);
        }
        else if (bossC == 0)
        {
            bossC0.SetActive(true);
            bossC1.SetActive(false);
            bossC2.SetActive(false);
        }
        else if (bossC == 1)
        {
            bossC0.SetActive(false);
            bossC1.SetActive(true);
            bossC2.SetActive(false);
        }
        else if (bossC == 2)
        {
            bossC0.SetActive(false);
            bossC1.SetActive(false);
            bossC2.SetActive(true);
        }
    }

    private void resetall()
    {
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
}
