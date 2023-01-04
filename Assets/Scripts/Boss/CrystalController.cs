using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("collision.tag = " + collision.transform.tag);
        if (collision.transform.tag == "PlayerRepLight")
        {
            Destroy(gameObject);
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    //Debug.Log("trigger collider.tag = " + other.tag);
    //    if (other.tag == "PlayerRepLight")
    //    {
    //        Destroy(gameObject);
    //    }
    //}

    public void DestoryCrystal()
    {
        Destroy(gameObject);
    }
}
