using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyVariable : MonoBehaviour
{
    public static int[] getPuzzle = new int[] {0, 0, 0, 0, 0, 0, 0, 0};
    public static int[] getNinePuzzle = new int[] {0, 0, 0, 0, 0};
    public static float PlayerHealth = 100.0f;
    public static bool isMonsterADead = false;
    public static bool isMonsterBDead = false;
    public static bool getKey = false;
    public static bool getKey2 = false;
    public static bool useKey = false;
    public static bool getHorseEye = false;
    public static bool useHorseEye = false;
    public static bool usePassword = false;
    public static bool useDoor1 = false;
    public static bool useDoor2 = false;
    public static bool useDoor3 = false;
    
    // Start is called before the first frame update
    void Start()
    {
        manager.resetbag();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
