using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour {

    public Object ExplosionEffect;
   

	// Use this for initialization
	void Start () {
		// Destroy after 5 sec
        GameObject.Destroy(gameObject, 5);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision col)
    {
        // Create Explosion Effect on collided position
        if(col.contacts.Length > 0){
            if (ExplosionEffect != null)
            {
                GameObject exp = GameObject.Instantiate(ExplosionEffect, Vector3.zero, Quaternion.identity) as GameObject;
               
                exp.transform.position = col.contacts[0].point + col.contacts[0].normal * 0.2f;
                // Destroy after 4 sec
                GameObject.Destroy(exp, 4);
                // Destroy Self
                GameObject.Destroy(gameObject);                   
            }                   
        }        
    }
}
