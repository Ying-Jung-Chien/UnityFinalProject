using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class test : MonoBehaviour
{
    public string[] SkillList = { "normal", "fireball", "shield"};
    public Text showCurrent_skill;
    public int current_skill = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        current_skill += (int)Mouse.current.scroll.ReadValue().normalized.y;
        current_skill = (current_skill < 0 ? 2 : current_skill) % 3;
        //showCurrent_skill.text = "Current Skill:" + SkillList[current_skill];
        skillcomtrol.skill_choose = current_skill;

    }


    public void OnTest1(InputValue value)
    {
        Debug.Log('S');
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
            TimeController.pressT = true;
            Debug.Log("test.Ontest4.isPressed");
        }
    }
}

