using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour
{
    public float speed = 5.0f;
    private float dir_y;
    private float min = 0;
    private float max = 30;
    private float normalizedFloat;

    public Object ExplosionEffect;

    // Start is called before the first frame update
    void Start()
    {
        dir_y = GameObject.FindGameObjectWithTag("Player").GetComponent<ThirdPersonController>()._cinemachineTargetPitch * -1;
        dir_y = Mathf.Clamp(dir_y , min, max);
        normalizedFloat = (dir_y - min) / (max - min);
        normalizedFloat = Mathf.Clamp(normalizedFloat, 0, 0.5f);
        transform.position += new Vector3(0, normalizedFloat*2, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate((Vector3.forward + new Vector3(0, (normalizedFloat), 0)) * speed * Time.deltaTime, Space.Self);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.contacts.Length > 0){
            if (collision.gameObject.tag == "Boss")
            {
                gameObject.GetComponent<Collider>().enabled = false;
                Boss.Health = Boss.Health - 70f;
            }
            if (ExplosionEffect != null)
            {
                GameObject exp = GameObject.Instantiate(ExplosionEffect, Vector3.zero, Quaternion.identity) as GameObject;
               
                exp.transform.position = collision.contacts[0].point + collision.contacts[0].normal * 0.2f;
                // Destroy after 4 sec
                GameObject.Destroy(exp, 4);
                // Destroy Self
                GameObject.Destroy(gameObject);                   
            }                   
        }  
        Destroy(gameObject);
    }
}
