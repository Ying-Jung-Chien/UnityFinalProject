using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOnClick : MonoBehaviour
{
    public GameObject chest_open;
    public GameObject horse_eye;

    // Start is called before the first frame update
    void Start()
    {
        if(chest_open != null) chest_open.SetActive(false);
        if(horse_eye != null) horse_eye.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) {  
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);  
            RaycastHit hit;  
            if (Physics.Raycast(ray, out hit)) {
                Debug.Log(hit.transform.name);
                if (hit.transform.name == gameObject.name) {
                    if (gameObject.name == "OldGoldKey") {
                        DontDestroyVariable.getKey = true;
                        Destroy(gameObject);
                    } else if (gameObject.name == "chest_close" && DontDestroyVariable.getKey) {
                        Destroy(gameObject);
                        if(chest_open != null) chest_open.SetActive(true);
                        if(horse_eye != null) horse_eye.SetActive(true);
                    } else if (gameObject.name == "Horse Right Eye") {
                        DontDestroyVariable.getHorseEye = true;
                        Destroy(gameObject);
                    } else {
                        for (int i = 0; i < 4; i++) {
                            if (gameObject.name == $"Puzzle{i}") {
                                DontDestroyVariable.getPuzzle[i] = 1;
                                Destroy(gameObject);
                            }
                        }
                    }
                }  
            }  
        }
    }
}
