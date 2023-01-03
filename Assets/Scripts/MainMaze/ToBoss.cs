using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class ToBoss : MonoBehaviour
{
    public GameObject loadingPanel;
    public Slider loadingBar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && (DontDestroyVariable.passRoom1 && DontDestroyVariable.passRoom2 && DontDestroyVariable.passRoom3))
            StartCoroutine(LoadSceneAsync("Boss"));
        // if (other.gameObject.tag == "Player") StartCoroutine(LoadSceneAsync("Boss"));
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
