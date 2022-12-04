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

    // Start is called before the first frame update
    void Start()
    {
        dir_y = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>()._cinemachineTargetPitch * -1;
        dir_y = Mathf.Clamp(dir_y , min, max);
        normalizedFloat = (dir_y - min) / (max - min);
        normalizedFloat = Mathf.Clamp(normalizedFloat, 0, 0.7f);
        transform.position += new Vector3(0, normalizedFloat*2, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate((Vector3.forward + new Vector3(0, (normalizedFloat), 0)) * speed * Time.deltaTime, Space.Self);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
