using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Button4Show : MonoBehaviour, IPointerExitHandler
{
    public GameObject button;
    public GameObject arrow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        button.gameObject.SetActive(true);
        arrow.gameObject.SetActive(false);
    }
}
