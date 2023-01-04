using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class bloodcontrol : MonoBehaviour
{
	public Image blood;
    public GameObject lose;
    public AudioSource audioPlayer;
    public AudioClip fail;

    public bool isRoom1Win;
    public bool isRoom2Win;
    public bool isRoom3Win;

    public GameObject loadingPanel;
    public Slider loadingBar;
    private int check = 0;

    void Awake()
    {
        /*GameObject[] objs = GameObject.FindGameObjectsWithTag("blood");
				
        if (objs.Length > 1 && this.tag == "blood")
        {
            Destroy(this.gameObject);
        }
        if(this.tag == "blood") DontDestroyOnLoad(this.gameObject);*/
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        blood.fillAmount = DontDestroyVariable.PlayerHealth / 100.0f;
        if(DontDestroyVariable.PlayerHealth < 100.0f && DontDestroyVariable.getball1 == true){
            DontDestroyVariable.PlayerHealth += 0.05f;
        }
        /*if(check == 0){
        	if(DontDestroyVariable.PlayerHealth <= 0)
	        {
	        	if(this.tag == "blood"){
	        		check = 1;
		            lose.gameObject.SetActive(true);
                    audioPlayer.PlayOneShot(fail);
		            StartCoroutine(Wait());
		        }else{
		        	Destroy(gameObject);
		        }
	        }
        }*/
        if (DontDestroyVariable.PlayerHealth <= 0)
        {
            if (this.tag == "blood" && check == 0)
            {
                check = 1;
                lose.gameObject.SetActive(true);
                audioPlayer.PlayOneShot(fail);
                StartCoroutine(LoadSceneAsync(DontDestroyVariable.nowplace));
            }

        }
    }

    IEnumerator LoadSceneAsync ( int no )
    {
        yield return new WaitForSeconds(3.0f);
        DontDestroyVariable.PlayerHealth = 100.0f;
        DontDestroyVariable.PlayerBlue = 100.0f;
        loadingPanel.SetActive(true);
        string levelName = "";

        if(no == 0){
            levelName = "MainMaze";
        }else if(no == 1){
            levelName = "Room1";
        }else if(no == 2){
            levelName = "Room2";
        }else if(no == 3){
            levelName = "Room3";
        }else if(no == 4){
            levelName = "Boss";
        }
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

    /*IEnumerator Wait()
    {
        yield return new WaitForSeconds(2.0f);
        check = 0;
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("Mainmaze");
        DontDestroyVariable.PlayerHealth = 100;
		lose.gameObject.SetActive(false);
    }*/


}
