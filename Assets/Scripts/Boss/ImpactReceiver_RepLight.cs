using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactReceiver_RepLight : MonoBehaviour
{
    float mass = 3.0F; // defines the character mass
    Vector3 impact = Vector3.zero;
    private CharacterController character;

    // Use this for initialization
    void Start()
    {
        character = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // apply the impact force:
        if (impact.magnitude > 0.1F) character.Move(impact * Time.deltaTime);
        // consumes the impact energy each cycle:
        impact = Vector3.Lerp(impact, Vector3.zero, 5 * Time.deltaTime);
    }
    // call this function to add an impact force:
    public void AddImpact(Vector3 dir, float force)
    {
        dir.Normalize();
        //if (dir.y < 0) dir.y = -dir.y; // reflect down force on the ground
        impact = Vector3.zero;
        impact += dir.normalized * force / mass;
        //Debug.Log("impact dir = " + dir + ", dir.normalized = " + dir.normalized + ", force = " + force + ", mass = " + mass + ", impact = " + impact);
    }
}
