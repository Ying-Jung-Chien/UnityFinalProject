using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bluecontrol : MonoBehaviour
{
	public Image blue;
	public float nowblue;
    

    void Awake()
    {
        /*GameObject[] objs = GameObject.FindGameObjectsWithTag("blue");
				
        if (objs.Length > 1 && this.tag == "blue")
        {
            Destroy(this.gameObject);
        }
        if(this.tag == "blue") DontDestroyOnLoad(this.gameObject);*/
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        blue.fillAmount = nowblue / 100.0f;
    }
    


}