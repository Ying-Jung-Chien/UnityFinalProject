using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace StarterAssets
{
    public class test : MonoBehaviour
    {

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        }

        public void OnTest1(InputValue value)
        {
            if(value.isPressed)
            {
                
                ImpactReceiver script = GetComponent<ImpactReceiver>();
                script.AddImpact(Quaternion.Euler(0, 0, 0) * transform.forward, 50);
            }
        }
        public void OnTest2(InputValue value)
        {
            if (value.isPressed)
            {
                ImpactReceiver script = GetComponent<ImpactReceiver>();
                script.AddImpact(Quaternion.Euler(0, 180f, 0) * transform.forward, 50);
            }
        }

        public void OnTest3(InputValue value)
        {
            if (value.isPressed)
            {
                if (Cursor.lockState == CursorLockMode.Locked)
                    Cursor.lockState = CursorLockMode.None;
                else
                    Cursor.lockState = CursorLockMode.Locked;
            }
        }

        public void OnTest4(InputValue value)
        {
            if(value.isPressed)
            {
                //Debug.Log("press T, clock: " + TimeController.isTurningBackTheClock);
                //if (TimeController.isTurningBackTheClock)
                //{
                //    Debug.Log("reset: " + Time.time);
                //    TimeController.startTime = Time.time;
                //    TimeController.endTime = TimeController.startTime + 5.0f;
                //    TimeController.isTurningBackTheClock = false;
                //}
                //else if (TimeController.curTime > TimeController.endTime + TimeController._cdTime && !TimeController.pressT)
                //{
                //    Debug.Log("start" + Time.time);
                //    TimeController.pressT = true;
                //}
                TimeController.pressT = true;
                Debug.Log("test.Ontest4.isPressed");
            }
        }
    }
}
