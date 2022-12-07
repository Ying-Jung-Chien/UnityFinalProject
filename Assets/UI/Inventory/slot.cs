using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class slot : MonoBehaviour
{
    public item slotitem;
    public Image slotImage;
    public TextMeshProUGUI slotNumber;
    public AudioClip over;
    public AudioSource audioPlayer;
    
    void Start()
    {

    }

    public void itemOnClicked()
    {
        audioPlayer.PlayOneShot(over);
        StartCoroutine(ExampleCoroutine(1));
    }

    IEnumerator ExampleCoroutine(int i)
    {
        yield return new WaitForSeconds(0.2f);
        if (i == 1) manager.UpdateItemInfo(slotitem.itemInfo, slotitem);
    }

    public void itemOnClose()
    {
        manager.UpdateItemInfo("", slotitem);
    }

    void Update()
    {

    }
    
}
