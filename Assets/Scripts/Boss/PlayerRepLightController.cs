using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DigitalRuby.LightningBolt;

public class PlayerRepLightController : MonoBehaviour
{
    public float lightAttack = 300f;
    public GameObject SimpleLightningBoltAnimatedPrefab;
    public Light spotlight;

    private float curTime;
    private float nextGetRepLightAttackTime;
    private bool lighten;
    private Vector3 LightPos;

    // Start is called before the first frame update
    void Start()
    {
        lighten = false;
        SimpleLightningBoltAnimatedPrefab.SetActive(false);
        spotlight.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        curTime = Time.time;

        if(lighten)
        {
            Debug.Log("ligtening");
            SimpleLightningBoltAnimatedPrefab.SetActive(true);
            SimpleLightningBoltAnimatedPrefab.GetComponent<LightningBoltScript>().SetPosition(transform.position, LightPos);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision.tag = " + collision.transform.tag);
        if (collision.transform.tag == "Boss")
        {
            if (curTime >= nextGetRepLightAttackTime)
            {
                nextGetRepLightAttackTime = Time.time + 5f;
                Debug.Log("lightattack");
                Boss.Health = Boss.Health - lightAttack;
                //spotlight.enabled = true;
                //spotlight.transform.position = collision.transform.position;
                //Invoke("TurnOffLignt", 0.2f);
                LightPos = collision.transform.position;
                lighten = true;
                Invoke("TurnOffLightening", 2f);
            }
        }
    }

    private void TurnOffLightening()
    {
        lighten = false;
        SimpleLightningBoltAnimatedPrefab.SetActive(false);
    }

    private void TurnOffLight()
    {
        spotlight.enabled = false;
    }
}
