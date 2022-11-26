using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StarterAssets
{
    public class ImpactReceiver : MonoBehaviour
    {
        // Start is called before the first frame update

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
            if (impact.magnitude > 2F) character.Move(impact * Time.deltaTime);
            else GetComponent<ThirdPersonController>().enabled = true;
            // consumes the impact energy each cycle:
            impact = Vector3.Lerp(impact, Vector3.zero, 5 * Time.deltaTime);
        }
        // call this function to add an impact force:
        public void AddImpact(Vector3 dir, float force)
        {
            dir.Normalize();
            if (dir.y < 0) dir.y = -dir.y; // reflect down force on the ground
            impact += dir.normalized * force / mass;
            GetComponent<ThirdPersonController>().enabled = false;
        }

    }
}
