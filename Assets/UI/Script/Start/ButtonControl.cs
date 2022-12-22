using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControl : MonoBehaviour
{
    public GameObject button1;
    public GameObject button10;
    public GameObject button2;
    public GameObject button20;
    public GameObject button3;
    public GameObject button30;
    public GameObject button4;
    public GameObject button40;
    public GameObject button5;
    public GameObject button50;
    public GameObject rule;
    public GameObject exit;
    public GameObject arrow2;
    public GameObject arrow3;
    public GameObject blood;
    public AudioClip press;
    public AudioClip click;
    public AudioSource audioPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Startgame(){
        audioPlayer.PlayOneShot(press);
        StartCoroutine(Wait());
    }

    public void add(){
        story.i++;
        if(story.i < 16){
            audioPlayer.PlayOneShot(click);
        }else{
            audioPlayer.PlayOneShot(press);
        }
    }

    IEnumerator Wait() {
        yield return new WaitForSeconds(1.0f);
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("MainMaze");
        //blood.gameObject.SetActive(true);
    }

    public void Showrule(){
        button1.gameObject.SetActive(false);
        button10.gameObject.SetActive(false);
        button2.gameObject.SetActive(false);
        button20.gameObject.SetActive(false);
        button3.gameObject.SetActive(false);
        button30.gameObject.SetActive(false);
        button4.gameObject.SetActive(true);
        button40.gameObject.SetActive(true);
        rule.gameObject.SetActive(true);
        arrow2.gameObject.SetActive(false);
        audioPlayer.PlayOneShot(press);
    }

    public void Hiderule(){
        button1.gameObject.SetActive(true);
        button10.gameObject.SetActive(true);
        button2.gameObject.SetActive(true);
        button20.gameObject.SetActive(true);
        button3.gameObject.SetActive(true);
        button30.gameObject.SetActive(true);
        button4.gameObject.SetActive(false);
        button40.gameObject.SetActive(false);
        button5.gameObject.SetActive(false);
        button50.gameObject.SetActive(false);
        rule.gameObject.SetActive(false);
        exit.gameObject.SetActive(false);
        arrow3.gameObject.SetActive(false);
        audioPlayer.PlayOneShot(press);
    }

    public void Showexit(){
        button1.gameObject.SetActive(false);
        button10.gameObject.SetActive(false);
        button2.gameObject.SetActive(false);
        button20.gameObject.SetActive(false);
        button3.gameObject.SetActive(false);
        button30.gameObject.SetActive(false);
        button4.gameObject.SetActive(true);
        button40.gameObject.SetActive(true);
        button5.gameObject.SetActive(true);
        button50.gameObject.SetActive(true);
        arrow3.gameObject.SetActive(false);
        exit.gameObject.SetActive(true);
        audioPlayer.PlayOneShot(press);
    }
}
