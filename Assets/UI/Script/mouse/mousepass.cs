using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class mousepass : MonoBehaviour, IPointerClickHandler
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
        if (password.passwordA == 2 && password.passwordB == 0 && password.passwordC == 1)
        {
            audioPlayer.PlayOneShot(good);
            password.wrong = 2;
        }
        else
        {
            audioPlayer.PlayOneShot(bad);
            password.wrong = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
