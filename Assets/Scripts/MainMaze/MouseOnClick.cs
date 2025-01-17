using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOnClick : MonoBehaviour
{
    public GameObject chest_open;
    public GameObject horse_eye;

    public item thisitem;
    public inventory playerInventory;

    public GameObject alertui;
    public GameObject alertui1;

    public AudioClip getevent;
    public AudioSource audioPlayer;

    // Start is called before the first frame update
    void Start()
    {
        if(chest_open != null) chest_open.SetActive(false);
        if(horse_eye != null) horse_eye.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) {  
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);  
            RaycastHit hit;  
            if (Physics.Raycast(ray, out hit)) {
                // Debug.Log(hit.transform.name);
                if (hit.transform.name == gameObject.name) {
                    if (gameObject.name == "OldGoldKey") {
                        audioPlayer.PlayOneShot(getevent);
                        DontDestroyVariable.getKey = true;
                        Destroy(gameObject);
                        AddNewItem(thisitem);
                        alertui.SetActive(true);
                    } else if (gameObject.name == "Key2") {
                        DontDestroyVariable.getKey2 = true;
                        Destroy(gameObject);
                        AddNewItem(thisitem);
                        alertui.SetActive(true);
                        audioPlayer.PlayOneShot(getevent);
                    } else if (gameObject.name == "chest_close") {
                        audioPlayer.PlayOneShot(getevent);
                        alertui.SetActive(true);
                        //Destroy(gameObject);
                        //if(chest_open != null) chest_open.SetActive(true);
                        //if(horse_eye != null) horse_eye.SetActive(true);
                    } else if (gameObject.name == "Horse Right Eye") {
                        audioPlayer.PlayOneShot(getevent);
                        DontDestroyVariable.getHorseEye = true;
                        Destroy(gameObject);
                        AddNewItem(thisitem);
                        alertui.SetActive(true);
                    } else if ((gameObject.name == "ChestLid02_LOD0" || gameObject.name == "Chest02_LOD0") && DontDestroyVariable.usePassword == false) {
                        audioPlayer.PlayOneShot(getevent);
                        alertui.SetActive(true);
                    } else if (gameObject.name == "Horse" && DontDestroyVariable.useHorseEye == false) {
                        audioPlayer.PlayOneShot(getevent);
                        alertui.SetActive(true);
                    } else if (gameObject.name == "Door1" && DontDestroyVariable.useDoor1 == false) {
                        audioPlayer.PlayOneShot(getevent);
                        alertui.SetActive(true);
                    } else if (gameObject.name == "Door2" && DontDestroyVariable.useDoor2 == false) {
                        audioPlayer.PlayOneShot(getevent);
                        alertui.SetActive(true);
                    } else if (gameObject.name == "Door3" && DontDestroyVariable.useDoor3 == false) {
                        audioPlayer.PlayOneShot(getevent);
                        alertui.SetActive(true);
                    }
                    else if (gameObject.name == "brazier" && DontDestroyVariable.useBrazier == false) {
                        manager.UpdateItemUse(14);
                        if(DontDestroyVariable.useBrazier == true)
                        {
                            audioPlayer.PlayOneShot(getevent);
                            alertui.SetActive(true);
                            AddNewItem(thisitem);
                        }
                    }
                    else if (gameObject.name == "Box2" && DontDestroyVariable.useBox2 == false) {
                        audioPlayer.PlayOneShot(getevent);
                        alertui.SetActive(true);
                    } else if (gameObject.name == "Box3" && DontDestroyVariable.useKey2 == false) {
                        audioPlayer.PlayOneShot(getevent);
                        alertui.SetActive(true);
                    } else if (gameObject.name == "Box1" && DontDestroyVariable.useBox1 == false) {
                        audioPlayer.PlayOneShot(getevent);
                        alertui.SetActive(true);
                    } else if (gameObject.name == "HiddenPiece") {
                        audioPlayer.PlayOneShot(getevent);
                        alertui.SetActive(true);
                        AddNewItem(thisitem);
                        DontDestroyVariable.getPiece = true;
                        Destroy(gameObject);
                    } else if (gameObject.name == "LP_Up_Stand") {
                        audioPlayer.PlayOneShot(getevent);
                        alertui.SetActive(true);
                        AddNewItem(thisitem);
                        Destroy(GameObject.Find("LP_Brush"));
                        Destroy(GameObject.Find("LP_Handle"));
                        Destroy(GameObject.Find("LP_Head"));
                        Destroy(GameObject.Find("LP_Ring"));
                        Destroy(GameObject.Find("LP_Threat"));
                    } else if (gameObject.name == "Cube_2" && DontDestroyVariable.useInk == false) {
                        audioPlayer.PlayOneShot(getevent);
                        if (DontDestroyVariable.useWater == true)
                        {
                            alertui1.SetActive(true);
                        }
                        else
                        {
                            alertui.SetActive(true);
                        }
                    } else if (gameObject.name == "GoBoard" && DontDestroyVariable.useBoard == false) {
                        audioPlayer.PlayOneShot(getevent);
                        alertui.SetActive(true);
                    }
                    else
                    {
                        for (int i = 0; i < 4; i++) {
                            if (gameObject.name == $"Puzzle{i}")
                            {
                                audioPlayer.PlayOneShot(getevent);
                                DontDestroyVariable.getPuzzle[i] = 1;
                                Destroy(gameObject);
                                AddNewItem(thisitem);
                                alertui.SetActive(true);
                            }
                        }

                        for (int i = 0; i < 5; i++) {
                            if (gameObject.name == $"NinePuzzle{i}")
                            {
                                DontDestroyVariable.getNinePuzzle[i] = 1;
                                Destroy(gameObject);
                                AddNewItem(thisitem);
                                alertui.SetActive(true);
                                audioPlayer.PlayOneShot(getevent);
                            }
                        }
                    }
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
