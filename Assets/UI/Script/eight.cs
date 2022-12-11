using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eight : MonoBehaviour
{
    public static int eight2 = 0;
    public static int eight3 = 0;
    public static int eight4 = 0;
    public static int eight5 = 0;
    public static int eight6 = 0;
    public static int eight8 = 0;
    public static int wrong1 = 0;

    public GameObject pass;
    public GameObject reset;
    public GameObject pass1;
    public GameObject reset1;
    public GameObject fail;

    public item item2;
    public item item3;
    public item item4;
    public item item5;
    public item item6;
    public item item8;
    public item item9;
    public inventory playerInventory;

    public GameObject eight20;
    public GameObject eight22;
    public GameObject eight23;
    public GameObject eight24;
    public GameObject eight25;
    public GameObject eight26;
    public GameObject eight28;

    public GameObject eight30;
    public GameObject eight32;
    public GameObject eight33;
    public GameObject eight34;
    public GameObject eight35;
    public GameObject eight36;
    public GameObject eight38;

    public GameObject eight40;
    public GameObject eight42;
    public GameObject eight43;
    public GameObject eight44;
    public GameObject eight45;
    public GameObject eight46;
    public GameObject eight48;

    public GameObject eight50;
    public GameObject eight52;
    public GameObject eight53;
    public GameObject eight54;
    public GameObject eight55;
    public GameObject eight56;
    public GameObject eight58;

    public GameObject eight60;
    public GameObject eight62;
    public GameObject eight63;
    public GameObject eight64;
    public GameObject eight65;
    public GameObject eight66;
    public GameObject eight68;

    public GameObject eight80;
    public GameObject eight82;
    public GameObject eight83;
    public GameObject eight84;
    public GameObject eight85;
    public GameObject eight86;
    public GameObject eight88;

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
        wrong1 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (wrong1 == 0)
        {
            pass.SetActive(true);
            reset.SetActive(true);
            fail.SetActive(false);
        }
        else if (wrong1 == 1)
        {
            pass.SetActive(false);
            reset.SetActive(false);
            pass1.SetActive(false);
            reset1.SetActive(false);
            fail.SetActive(true);
            StartCoroutine(ExampleCoroutine());
        }
        else if (wrong1 == 2)
        {
            item9.itemHeld = 0;
            item9.itemactive = 0;
            manager.ReflashItem();
            DontDestroyVariable.useDoor1 = true;
            this.gameObject.SetActive(false);
        }

        if (eight2 == 0)
        {
            eight20.SetActive(true);
            eight22.SetActive(false);
            eight23.SetActive(false);
            eight24.SetActive(false);
            eight25.SetActive(false);
            eight26.SetActive(false);
            eight28.SetActive(false);
        }
        else if (eight2 == 2)
        {
            eight20.SetActive(false);
            eight22.SetActive(true);
            eight23.SetActive(false);
            eight24.SetActive(false);
            eight25.SetActive(false);
            eight26.SetActive(false);
            eight28.SetActive(false);
        }
        else if (eight2 == 3)
        {
            eight20.SetActive(false);
            eight22.SetActive(false);
            eight23.SetActive(true);
            eight24.SetActive(false);
            eight25.SetActive(false);
            eight26.SetActive(false);
            eight28.SetActive(false);
        }
        else if (eight2 == 4)
        {
            eight20.SetActive(false);
            eight22.SetActive(false);
            eight23.SetActive(false);
            eight24.SetActive(true);
            eight25.SetActive(false);
            eight26.SetActive(false);
            eight28.SetActive(false);
        }
        else if (eight2 == 5)
        {
            eight20.SetActive(false);
            eight22.SetActive(false);
            eight23.SetActive(false);
            eight24.SetActive(false);
            eight25.SetActive(true);
            eight26.SetActive(false);
            eight28.SetActive(false);
        }
        else if (eight2 == 6)
        {
            eight20.SetActive(false);
            eight22.SetActive(false);
            eight23.SetActive(false);
            eight24.SetActive(false);
            eight25.SetActive(false);
            eight26.SetActive(true);
            eight28.SetActive(false);
        }
        else if (eight2 == 8)
        {
            eight20.SetActive(false);
            eight22.SetActive(false);
            eight23.SetActive(false);
            eight24.SetActive(false);
            eight25.SetActive(false);
            eight26.SetActive(false);
            eight28.SetActive(true);
        }

        if (eight3 == 0)
        {
            eight30.SetActive(true);
            eight32.SetActive(false);
            eight33.SetActive(false);
            eight34.SetActive(false);
            eight35.SetActive(false);
            eight36.SetActive(false);
            eight38.SetActive(false);
        }
        else if (eight3 == 2)
        {
            eight30.SetActive(false);
            eight32.SetActive(true);
            eight33.SetActive(false);
            eight34.SetActive(false);
            eight35.SetActive(false);
            eight36.SetActive(false);
            eight38.SetActive(false);
        }
        else if (eight3 == 3)
        {
            eight30.SetActive(false);
            eight32.SetActive(false);
            eight33.SetActive(true);
            eight34.SetActive(false);
            eight35.SetActive(false);
            eight36.SetActive(false);
            eight38.SetActive(false);
        }
        else if (eight3 == 4)
        {
            eight30.SetActive(false);
            eight32.SetActive(false);
            eight33.SetActive(false);
            eight34.SetActive(true);
            eight35.SetActive(false);
            eight36.SetActive(false);
            eight38.SetActive(false);
        }
        else if (eight3 == 5)
        {
            eight30.SetActive(false);
            eight32.SetActive(false);
            eight33.SetActive(false);
            eight34.SetActive(false);
            eight35.SetActive(true);
            eight36.SetActive(false);
            eight38.SetActive(false);
        }
        else if (eight3 == 6)
        {
            eight30.SetActive(false);
            eight32.SetActive(false);
            eight33.SetActive(false);
            eight34.SetActive(false);
            eight35.SetActive(false);
            eight36.SetActive(true);
            eight38.SetActive(false);
        }
        else if (eight3 == 8)
        {
            eight30.SetActive(false);
            eight32.SetActive(false);
            eight33.SetActive(false);
            eight34.SetActive(false);
            eight35.SetActive(false);
            eight36.SetActive(false);
            eight38.SetActive(true);
        }

        if (eight4 == 0)
        {
            eight40.SetActive(true);
            eight42.SetActive(false);
            eight43.SetActive(false);
            eight44.SetActive(false);
            eight45.SetActive(false);
            eight46.SetActive(false);
            eight48.SetActive(false);
        }
        else if (eight4 == 2)
        {
            eight40.SetActive(false);
            eight42.SetActive(true);
            eight43.SetActive(false);
            eight44.SetActive(false);
            eight45.SetActive(false);
            eight46.SetActive(false);
            eight48.SetActive(false);
        }
        else if (eight4 == 3)
        {
            eight40.SetActive(false);
            eight42.SetActive(false);
            eight43.SetActive(true);
            eight44.SetActive(false);
            eight45.SetActive(false);
            eight46.SetActive(false);
            eight48.SetActive(false);
        }
        else if (eight4 == 4)
        {
            eight40.SetActive(false);
            eight42.SetActive(false);
            eight43.SetActive(false);
            eight44.SetActive(true);
            eight45.SetActive(false);
            eight46.SetActive(false);
            eight48.SetActive(false);
        }
        else if (eight4 == 5)
        {
            eight40.SetActive(false);
            eight42.SetActive(false);
            eight43.SetActive(false);
            eight44.SetActive(false);
            eight45.SetActive(true);
            eight46.SetActive(false);
            eight48.SetActive(false);
        }
        else if (eight4 == 6)
        {
            eight40.SetActive(false);
            eight42.SetActive(false);
            eight43.SetActive(false);
            eight44.SetActive(false);
            eight45.SetActive(false);
            eight46.SetActive(true);
            eight48.SetActive(false);
        }
        else if (eight4 == 8)
        {
            eight40.SetActive(false);
            eight42.SetActive(false);
            eight43.SetActive(false);
            eight44.SetActive(false);
            eight45.SetActive(false);
            eight46.SetActive(false);
            eight48.SetActive(true);
        }

        if (eight5 == 0)
        {
            eight50.SetActive(true);
            eight52.SetActive(false);
            eight53.SetActive(false);
            eight54.SetActive(false);
            eight55.SetActive(false);
            eight56.SetActive(false);
            eight58.SetActive(false);
        }
        else if (eight5 == 2)
        {
            eight50.SetActive(false);
            eight52.SetActive(true);
            eight53.SetActive(false);
            eight54.SetActive(false);
            eight55.SetActive(false);
            eight56.SetActive(false);
            eight58.SetActive(false);
        }
        else if (eight5 == 3)
        {
            eight50.SetActive(false);
            eight52.SetActive(false);
            eight53.SetActive(true);
            eight54.SetActive(false);
            eight55.SetActive(false);
            eight56.SetActive(false);
            eight58.SetActive(false);
        }
        else if (eight5 == 4)
        {
            eight50.SetActive(false);
            eight52.SetActive(false);
            eight53.SetActive(false);
            eight54.SetActive(true);
            eight55.SetActive(false);
            eight56.SetActive(false);
            eight58.SetActive(false);
        }
        else if (eight5 == 5)
        {
            eight50.SetActive(false);
            eight52.SetActive(false);
            eight53.SetActive(false);
            eight54.SetActive(false);
            eight55.SetActive(true);
            eight56.SetActive(false);
            eight58.SetActive(false);
        }
        else if (eight5 == 6)
        {
            eight50.SetActive(false);
            eight52.SetActive(false);
            eight53.SetActive(false);
            eight54.SetActive(false);
            eight55.SetActive(false);
            eight56.SetActive(true);
            eight58.SetActive(false);
        }
        else if (eight5 == 8)
        {
            eight50.SetActive(false);
            eight52.SetActive(false);
            eight53.SetActive(false);
            eight54.SetActive(false);
            eight55.SetActive(false);
            eight56.SetActive(false);
            eight58.SetActive(true);
        }

        if (eight6 == 0)
        {
            eight60.SetActive(true);
            eight62.SetActive(false);
            eight63.SetActive(false);
            eight64.SetActive(false);
            eight65.SetActive(false);
            eight66.SetActive(false);
            eight68.SetActive(false);
        }
        else if (eight6 == 2)
        {
            eight60.SetActive(false);
            eight62.SetActive(true);
            eight63.SetActive(false);
            eight64.SetActive(false);
            eight65.SetActive(false);
            eight66.SetActive(false);
            eight68.SetActive(false);
        }
        else if (eight6 == 3)
        {
            eight60.SetActive(false);
            eight62.SetActive(false);
            eight63.SetActive(true);
            eight64.SetActive(false);
            eight65.SetActive(false);
            eight66.SetActive(false);
            eight68.SetActive(false);
        }
        else if (eight6 == 4)
        {
            eight60.SetActive(false);
            eight62.SetActive(false);
            eight63.SetActive(false);
            eight64.SetActive(true);
            eight65.SetActive(false);
            eight66.SetActive(false);
            eight68.SetActive(false);
        }
        else if (eight6 == 5)
        {
            eight60.SetActive(false);
            eight62.SetActive(false);
            eight63.SetActive(false);
            eight64.SetActive(false);
            eight65.SetActive(true);
            eight66.SetActive(false);
            eight68.SetActive(false);
        }
        else if (eight6 == 6)
        {
            eight60.SetActive(false);
            eight62.SetActive(false);
            eight63.SetActive(false);
            eight64.SetActive(false);
            eight65.SetActive(false);
            eight66.SetActive(true);
            eight68.SetActive(false);
        }
        else if (eight6 == 8)
        {
            eight60.SetActive(false);
            eight62.SetActive(false);
            eight63.SetActive(false);
            eight64.SetActive(false);
            eight65.SetActive(false);
            eight66.SetActive(false);
            eight68.SetActive(true);
        }

        if (eight8 == 0)
        {
            eight80.SetActive(true);
            eight82.SetActive(false);
            eight83.SetActive(false);
            eight84.SetActive(false);
            eight85.SetActive(false);
            eight86.SetActive(false);
            eight88.SetActive(false);
        }
        else if (eight8 == 2)
        {
            eight80.SetActive(false);
            eight82.SetActive(true);
            eight83.SetActive(false);
            eight84.SetActive(false);
            eight85.SetActive(false);
            eight86.SetActive(false);
            eight88.SetActive(false);
        }
        else if (eight8 == 3)
        {
            eight80.SetActive(false);
            eight82.SetActive(false);
            eight83.SetActive(true);
            eight84.SetActive(false);
            eight85.SetActive(false);
            eight86.SetActive(false);
            eight88.SetActive(false);
        }
        else if (eight8 == 4)
        {
            eight80.SetActive(false);
            eight82.SetActive(false);
            eight83.SetActive(false);
            eight84.SetActive(true);
            eight85.SetActive(false);
            eight86.SetActive(false);
            eight88.SetActive(false);
        }
        else if (eight8 == 5)
        {
            eight80.SetActive(false);
            eight82.SetActive(false);
            eight83.SetActive(false);
            eight84.SetActive(false);
            eight85.SetActive(true);
            eight86.SetActive(false);
            eight88.SetActive(false);
        }
        else if (eight8 == 6)
        {
            eight80.SetActive(false);
            eight82.SetActive(false);
            eight83.SetActive(false);
            eight84.SetActive(false);
            eight85.SetActive(false);
            eight86.SetActive(true);
            eight88.SetActive(false);
        }
        else if (eight8 == 8)
        {
            eight80.SetActive(false);
            eight82.SetActive(false);
            eight83.SetActive(false);
            eight84.SetActive(false);
            eight85.SetActive(false);
            eight86.SetActive(false);
            eight88.SetActive(true);
        }
    }

    private void resetall()
    {
        if (eight.eight2 == 2)
        {
            AddNewItem(item2);
        }
        else if (eight.eight2 == 3)
        {
            AddNewItem(item3);
        }
        else if (eight.eight2 == 4)
        {
            AddNewItem(item4);
        }
        else if (eight.eight2 == 5)
        {
            AddNewItem(item5);
        }
        else if (eight.eight2 == 6)
        {
            AddNewItem(item6);
        }
        else if (eight.eight2 == 8)
        {
            AddNewItem(item8);
        }

        if (eight.eight3 == 2)
        {
            AddNewItem(item2);
        }
        else if (eight.eight3 == 3)
        {
            AddNewItem(item3);
        }
        else if (eight.eight3 == 4)
        {
            AddNewItem(item4);
        }
        else if (eight.eight3 == 5)
        {
            AddNewItem(item5);
        }
        else if (eight.eight3 == 6)
        {
            AddNewItem(item6);
        }
        else if (eight.eight3 == 8)
        {
            AddNewItem(item8);
        }

        if (eight.eight4 == 2)
        {
            AddNewItem(item2);
        }
        else if (eight.eight4 == 3)
        {
            AddNewItem(item3);
        }
        else if (eight.eight4 == 4)
        {
            AddNewItem(item4);
        }
        else if (eight.eight4 == 5)
        {
            AddNewItem(item5);
        }
        else if (eight.eight4 == 6)
        {
            AddNewItem(item6);
        }
        else if (eight.eight4 == 8)
        {
            AddNewItem(item8);
        }

        if (eight.eight5 == 2)
        {
            AddNewItem(item2);
        }
        else if (eight.eight5 == 3)
        {
            AddNewItem(item3);
        }
        else if (eight.eight5 == 4)
        {
            AddNewItem(item4);
        }
        else if (eight.eight5 == 5)
        {
            AddNewItem(item5);
        }
        else if (eight.eight5 == 6)
        {
            AddNewItem(item6);
        }
        else if (eight.eight5 == 8)
        {
            AddNewItem(item8);
        }

        if (eight.eight6 == 2)
        {
            AddNewItem(item2);
        }
        else if (eight.eight6 == 3)
        {
            AddNewItem(item3);
        }
        else if (eight.eight6 == 4)
        {
            AddNewItem(item4);
        }
        else if (eight.eight6 == 5)
        {
            AddNewItem(item5);
        }
        else if (eight.eight6 == 6)
        {
            AddNewItem(item6);
        }
        else if (eight.eight6 == 8)
        {
            AddNewItem(item8);
        }

        if (eight.eight8 == 2)
        {
            AddNewItem(item2);
        }
        else if (eight.eight8 == 3)
        {
            AddNewItem(item3);
        }
        else if (eight.eight8 == 4)
        {
            AddNewItem(item4);
        }
        else if (eight.eight8 == 5)
        {
            AddNewItem(item5);
        }
        else if (eight.eight8 == 6)
        {
            AddNewItem(item6);
        }
        else if (eight.eight8 == 8)
        {
            AddNewItem(item8);
        }
        eight.eight2 = 0;
        eight.eight3 = 0;
        eight.eight4 = 0;
        eight.eight5 = 0;
        eight.eight6 = 0;
        eight.eight8 = 0;
    }
}
