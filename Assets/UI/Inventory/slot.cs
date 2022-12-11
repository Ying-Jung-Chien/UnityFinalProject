using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;

public class slot : MonoBehaviour, IPointerClickHandler
{
    public item slotitem;
    public Image slotImage;
    public TextMeshProUGUI slotNumber;
    public AudioClip over;
    public AudioSource audioPlayer;
    public UnityEvent rightClick;

    void Start()
    {
        rightClick.AddListener(new UnityAction(ButtonRightClick));
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            rightClick.Invoke();
        }
    }

    private void ButtonRightClick()
    {
        itemOnClicked();
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
