using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) {  
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);  
            RaycastHit hit;  
            if (Physics.Raycast(ray, out hit)) {
                // Debug.Log(hit.transform.name);
                if (hit.transform.name == gameObject.name) {
                    gameObject.GetComponent<Rigidbody>().AddForce(new Vector3 (0, 0, -1) * 300);
                }
            }
        }
    }
}
