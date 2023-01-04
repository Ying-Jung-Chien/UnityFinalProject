using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnrichBossBlood : MonoBehaviour
{
    private GameObject target;
    private float dampTime = 0.5f;
    private Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;
        transform.position = Vector3.SmoothDamp(transform.position, target.transform.position, ref velocity, dampTime);
        if(Vector3.Distance(transform.position, target.transform.position) <= 2f)
        {
            Boss.Health = (Boss.Health + 1f > Boss._maxHealth) ? Boss._maxHealth : Boss.Health + 1f;
            Destroy(gameObject);
        }
    }

    public void SetTarget(GameObject t)
    {
        Debug.Log("target = " + t.tag);
        target = t;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Boss")
        {
            Debug.Log("destory");
            Boss.Health = (Boss.Health + 1f > Boss._maxHealth) ? Boss._maxHealth : Boss.Health + 1f;
            Destroy(gameObject);
        }
    }
}
