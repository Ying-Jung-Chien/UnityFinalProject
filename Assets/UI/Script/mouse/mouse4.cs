using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class mouse4 : MonoBehaviour, IPointerClickHandler
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
        DontDestroyVariable.PlayerHealth = 100.0f;
        DontDestroyVariable.PlayerBlue = 100.0f;
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("Start");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
