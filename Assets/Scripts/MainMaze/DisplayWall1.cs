using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayWall1 : MonoBehaviour
{
    public GameObject wall1_0;
    public GameObject wall1_1;
    public GameObject wall1_2;

    private bool isThrough = false;
    // Start is called before the first frame update
    void Start()
    {
        if (!DontDestroyVariable.passRoom1) wall1_0.SetActive(true);
        else wall1_0.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (DontDestroyVariable.passRoom1 && !isThrough && wall1_0.active) wall1_0.SetActive(false);
        if (DontDestroyVariable.passRoom1 && !wall1_1.active) wall1_1.SetActive(true);
        if (DontDestroyVariable.passRoom1 && !wall1_2.active) wall1_2.SetActive(true);
        if (DontDestroyVariable.passRoom2 && !wall1_0.active) wall1_0.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && DontDestroyVariable.passRoom1) {
            wall1_0.SetActive(true);
            isThrough = true;
        }
    }
}
