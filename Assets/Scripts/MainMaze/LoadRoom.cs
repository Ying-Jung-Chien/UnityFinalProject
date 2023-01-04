using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadRoom : MonoBehaviour
{
    public GameObject loadingPanel;
    public Slider loadingBar;

    private AsyncOperation asyncOperation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(DontDestroyVariable.useDoor1) {
            DontDestroyVariable.useDoor1 = false;
            DontDestroyVariable.lastRoom = 1;
            DontDestroyVariable.nowplace = 1;
            StartCoroutine(LoadSceneAsync("Room1"));
            // DontDestroyVariable.passRoom1 = true;
        } else if(DontDestroyVariable.useDoor2) {
            DontDestroyVariable.useDoor2 = false;
            DontDestroyVariable.lastRoom = 2;
            DontDestroyVariable.nowplace = 2;
            StartCoroutine(LoadSceneAsync("Room2"));
        } else if(DontDestroyVariable.useDoor3) {
            DontDestroyVariable.useDoor3 = false;
            DontDestroyVariable.lastRoom = 3;
            DontDestroyVariable.nowplace = 3;
            StartCoroutine(LoadSceneAsync("Room3"));
            // DontDestroyVariable.passRoom3 = true;
        }
    }

    IEnumerator LoadSceneAsync ( string levelName )
    {
        loadingPanel.SetActive(true);

        AsyncOperation op = SceneManager.LoadSceneAsync(levelName);
        op.allowSceneActivation = false;

        while ( !op.isDone )
        {
            // float progress = Mathf.Clamp01(op.progress / 0.9f);
            loadingBar.value = op.progress;

            if (op.progress >= 0.9f) op.allowSceneActivation = true;

            yield return null;
        }
    }
}
