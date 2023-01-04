using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatedCrystal_3 : MonoBehaviour
{
    public float counterclockwiseRoatateSpeed;

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
        transform.Rotate(Vector3.up * counterclockwiseRoatateSpeed, Space.World);
    }

    /*
    void OnDestroy()
    {
        //if (
        //    !EditorApplication.isPlayingOrWillChangePlaymode &&
        //    EditorApplication.isPlaying
        //) return;

        GameObject gameObj =
            Instantiate(destoryParticle,
            transform.position,
            Quaternion.Euler(-90, 0, 0));
        ParticleSystem parSys = gameObj.GetComponent<ParticleSystem>();
        float duration =
            parSys.main.duration + parSys.main.startLifetime.constant;
        parSys.Play();
        Destroy(gameObj, duration);
    }
    */
}
