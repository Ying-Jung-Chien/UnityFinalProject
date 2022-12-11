using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class passwordshow : MonoBehaviour
{
    public static bool passwordshow1 = false;
    public static bool eightshow = false;

    public GameObject password;
    public GameObject eight;
    //public static bool passwordshow1 = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (passwordshow1 == true)
        {
            password.SetActive(true);
        }

        if (eightshow == true)
        {
            eight.SetActive(true);
        }
    }
}
