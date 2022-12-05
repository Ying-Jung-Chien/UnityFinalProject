using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeui : MonoBehaviour
{
    public GameObject testui;
    public static int check = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(manager.status == 0 && check == 0)
        {
            testui.gameObject.SetActive(true);
            StartCoroutine(ExampleCoroutine());
            check = 1;
        }
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(3.0f);
        testui.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
    }
}
