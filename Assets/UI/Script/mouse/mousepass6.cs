using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class mousepass6 : MonoBehaviour, IPointerClickHandler
{
    public UnityEvent rightClick;

    public AudioClip good;
    public AudioClip bad;
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
        if (BossTest.bossA == 2 && BossTest.bossB == 0 && BossTest.bossC == 1)
        {
            audioPlayer.PlayOneShot(good);
            BossTest.wrong100 = 2;
        }
        else
        {
            audioPlayer.PlayOneShot(bad);
            BossTest.wrong100 = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
