using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayWall2 : MonoBehaviour
{
    public GameObject wall2;

    private bool isThrough = false;
    // Start is called before the first frame update
    void Start()
    {
        if (!DontDestroyVariable.passRoom2) wall2.SetActive(true);
        else wall2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (DontDestroyVariable.passRoom2 && !isThrough && wall2.active) wall2.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && DontDestroyVariable.passRoom2) {
            wall2.SetActive(true);
            isThrough = true;
        }
    }
}
