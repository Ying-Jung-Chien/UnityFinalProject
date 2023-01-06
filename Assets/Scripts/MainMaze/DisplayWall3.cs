using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayWall3 : MonoBehaviour
{
    public GameObject wall3_1;
    public GameObject wall3_2;

    // Start is called before the first frame update
    void Start()
    {
        if (DontDestroyVariable.passRoom3) {
            wall3_1.SetActive(true);
            wall3_2.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (DontDestroyVariable.passRoom3 && !wall3_1.active) wall3_1.SetActive(true);
        if (DontDestroyVariable.passRoom3 && !wall3_2.active) wall3_2.SetActive(true);
    }
}
