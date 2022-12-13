using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class mouse1 : MonoBehaviour, IPointerClickHandler
{
    public UnityEvent rightClick;
    public GameObject show1;
    public GameObject show2;
    public GameObject close1;
    public GameObject close2;

    public item item1;
    public item item2;
    public inventory playerInventory;

    public AudioClip click;
    public AudioSource audioPlayer;
    // Start is called before the first frame update
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
        audioPlayer.PlayOneShot(click);
        passwordshow.passwordshow1 = false;
        passwordshow.eightshow = false;
        passwordshow.problemshow = false;
        passwordshow.stoneshow = false;
        if (show1 != null) show1.SetActive(true);
        if (show2 != null) show2.SetActive(true);
        if (close1 != null) close1.SetActive(false);
        if (close2 != null) close2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
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
}
