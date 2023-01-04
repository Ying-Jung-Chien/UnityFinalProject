using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalController : MonoBehaviour
{
    public GameObject ExplosionEffect;
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
        if (ExplosionEffect != null)
        {
            ExplosionEffect.SetActive(true);
            GameObject exp = GameObject.Instantiate(ExplosionEffect, Vector3.zero, Quaternion.identity) as GameObject;
            exp.transform.position = gameObject.transform.position + Vector3.left;
            // Destroy after 4 sec
            GameObject.Destroy(exp, 4);
            // Destroy Self
            GameObject.Destroy(gameObject);                   
        }
        Destroy(gameObject);
    }
}
