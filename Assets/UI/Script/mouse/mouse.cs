using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse : MonoBehaviour
{
    public GameObject alertui;

    public AudioClip click;
    public AudioSource audioPlayer;

    public item item1;
    public inventory playerInventory;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject obj = hit.collider.gameObject;
                if (obj.name == "ball1")
                {
                    DontDestroyVariable.getball1 = true;
                    AddNewItem(item1);
                    audioPlayer.PlayOneShot(click);
                    alertui.gameObject.SetActive(true);
                    Destroy(obj);
                }else if (obj.name == "ball3")
                {
                    DontDestroyVariable.nowskillnum = 3;
                    DontDestroyVariable.getball3 = true;
                    AddNewItem(item1);
                    audioPlayer.PlayOneShot(click);
                    alertui.gameObject.SetActive(true);
                    Destroy(obj);
                }
            }
        }
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
}
