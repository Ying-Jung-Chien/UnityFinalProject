using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatedCrystal_2 : MonoBehaviour
{
    public float clockwiseRoatateSpeed;

    private float oriHeight;

    void Start()
    {
        oriHeight = transform.position.y;
    }

    void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        transform.Rotate(Vector3.down * clockwiseRoatateSpeed, Space.World);
    }
}
