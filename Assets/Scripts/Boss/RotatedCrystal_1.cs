using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatedCrystal_1 : MonoBehaviour
{
    //public float roatateSpeed;
    public float floatingSpeed;
    public float floatingRange;
    //public GameObject destoryParticle;

    private float alpha;
    private float oriHeight;

    void Start()
    {
        alpha = 0.0f;
        oriHeight = transform.position.y;
    }

    void Update()
    {
        Float();
        //Rotate();
    }

    void Float()
    {
        float newHeight = Mathf.PingPong(alpha, floatingRange);
        alpha = (alpha + floatingSpeed * Time.deltaTime) % 10;
        //Debug.Log("oriHeight = " + oriHeight + ", newHeight = " + newHeight + ", sum = " + (oriHeight + newHeight));
        transform.position =
            new Vector3(transform.position.x, newHeight + oriHeight, transform.position.z);
    }

    //void Rotate()
    //{
    //    transform.Rotate(Vector3.down * roatateSpeed, Space.World);
    //}

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
