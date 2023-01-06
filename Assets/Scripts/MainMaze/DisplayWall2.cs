using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayWall2 : MonoBehaviour
{
    public GameObject wall2_0;
    public GameObject wall2_1;
    public GameObject wall2_2;
    public GameObject wall2_3;
    public GameObject wall2_4;
    public GameObject wall2_5;

    private bool isThrough = false;
    // Start is called before the first frame update
    void Start()
    {
        if (!DontDestroyVariable.passRoom2) wall2_0.SetActive(true);
        else wall2_0.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (DontDestroyVariable.passRoom2 && !isThrough && wall2_0.active) wall2_0.SetActive(false);
        if (DontDestroyVariable.passRoom2 && !wall2_1.active) wall2_1.SetActive(true);
        if (DontDestroyVariable.passRoom2 && !wall2_2.active) wall2_2.SetActive(true);
        if (DontDestroyVariable.passRoom2 && !wall2_3.active) wall2_3.SetActive(true);
        if (DontDestroyVariable.passRoom2 && !wall2_4.active) wall2_4.SetActive(true);
        if (DontDestroyVariable.passRoom2 && !wall2_5.active) wall2_5.SetActive(true);
        if (DontDestroyVariable.passRoom3 && !wall2_0.active) wall2_0.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && DontDestroyVariable.passRoom2) {
            wall2_0.SetActive(true);
            isThrough = true;
        }
    }
}
