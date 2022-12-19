using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bloodcontrol : MonoBehaviour
{
	public Image blood;
    public GameObject lose;
    public AudioSource audioPlayer;
    public AudioClip fail;

    public bool isRoom1Win;
    public bool isRoom2Win;
    public bool isRoom3Win;

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
            if (this.tag == "blood")
            {
                check = 1;
                lose.gameObject.SetActive(true);
                audioPlayer.PlayOneShot(fail);

            }

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
