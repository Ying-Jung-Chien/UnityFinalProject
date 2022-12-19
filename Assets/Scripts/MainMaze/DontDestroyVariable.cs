using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyVariable : MonoBehaviour
{
    public static int[] getPuzzle = new int[] {0, 0, 0, 0, 0, 0, 0, 0};
    public static int[] getNinePuzzle = new int[] {0, 0, 0, 0, 0};
    public static int lastRoom = 0;
    public static float PlayerHealth = 100.0f;
    public static bool isMonsterADead = false;
    public static bool isMonsterBDead = false;
    public static bool getKey = false;
    public static bool getKey2 = false;
    public static bool useKey = false;
    public static bool useKey2 = false;
    public static bool getPiece = false;
    public static bool getHorseEye = false;
    public static bool useHorseEye = false;
    public static bool usePassword = false;
    public static bool useBrazier = false;
    public static bool useDoor1 = false;
    public static bool useDoor2 = false;
    public static bool useDoor3 = false;
    public static bool useBox1 = false;
    public static bool useBox2 = false;
    public static bool useWater = false;
    public static bool useInk = false;
    public static bool useBrush = false;
    public static bool useChess = false;
    public static bool useBoard = false;
    public static bool firstComingIn = true;

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("DontDestroy");
				
        if (objs.Length > 1 && this.tag == "DontDestroy")
        {
            Debug.Log("Destroy(this.gameObject);");
            Destroy(this.gameObject);
        }
        if(this.tag == "DontDestroy") DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        if(firstComingIn){
            Debug.Log("firstComingIn");
            manager.resetbag();
            firstComingIn = false;
        }
        // Debug.Log("firstComingIn");
        // manager.resetbag();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
