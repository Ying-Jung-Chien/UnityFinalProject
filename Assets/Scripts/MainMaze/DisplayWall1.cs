using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayWall1 : MonoBehaviour
{
    public GameObject wall1;

    private bool isThrough = false;
    // Start is called before the first frame update
    void Start()
    {
        if (!DontDestroyVariable.passRoom1) wall1.SetActive(true);
        else wall1.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (DontDestroyVariable.passRoom1 && !isThrough && wall1.active) wall1.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && DontDestroyVariable.passRoom1) {
            wall1.SetActive(true);
            isThrough = true;
        }
    }
}
