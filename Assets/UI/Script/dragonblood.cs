using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dragonblood : MonoBehaviour
{
    public Image blood;
    public GameObject win;
    public AudioSource audioPlayer;
    public AudioClip success;
    
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
        //Boss.Health = 0.0f;
        blood.fillAmount = Boss.Health / 1000.0f;
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
        if (Boss.Health <= 0)
        {
            Boss.Health = 1000.0f;
            win.SetActive(true);
            audioPlayer.PlayOneShot(success);
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
