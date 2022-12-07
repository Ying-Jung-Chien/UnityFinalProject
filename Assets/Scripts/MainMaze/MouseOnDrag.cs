using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOnDrag : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);  
            RaycastHit hit;  
            if (Physics.Raycast(ray, out hit)) {
                if (hit.transform.name == gameObject.name) {
                    // Debug.Log(hit.transform.name);
                    float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
                    Vector3 pos_move = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen ));
                    // transform.position = new Vector3( pos_move.x, transform.position.y, pos_move.z );
                    Vector3 diffDistance = new Vector3( pos_move.x - transform.position.x, 0, pos_move.z - transform.position.z );
                    // gameObject.GetComponent<Rigidbody>().velocity = diffDistance * 10;
                    gameObject.GetComponent<Rigidbody>().AddForce(diffDistance*1000);
                    }  
            }  
        }
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3( 0, 0, 0);
        gameObject.GetComponent<Rigidbody>().AddForce(new Vector3( 0, 0, 0)); 
    }
}
