using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LightsControl : MonoBehaviour
{
    public GameObject torch;
    public GameObject torch2;
    public GameObject candle;
    public AudioSource audioSource;
    public AudioClip scream;
    public float volume=0.5f;
    public Canvas DarkCanvas;

    public bool StopLight;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ExampleCoroutine());
        DarkCanvas.enabled = false;
        StopLight = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void SetStopLight(){
        StopLight = true;
    }
    
     IEnumerator ExampleCoroutine()
    {

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(10);
        ParticleSystem ps = torch.GetComponent<ParticleSystem>();
        var em = ps.emission;
        em.enabled = false;

        ps = torch2.GetComponent<ParticleSystem>();
        em = ps.emission;
        em.enabled = false;

        for(int i=0;i<4;i++){
            yield return new WaitForSeconds(10f);
            if(!StopLight){
                GameObject candle_child = candle.transform.GetChild(i).GetChild(0).gameObject;
            
                Light lightComp = candle_child.transform.GetChild(0).GetComponent<Light>();
                lightComp.enabled = false;
                Renderer rend = candle_child.GetComponent<Renderer> ();
                candle_child.GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
            }
            
            
        }
        if(!StopLight){
             DarkCanvas.enabled = true;
            yield return new WaitForSeconds(2);
            audioSource.PlayOneShot(scream, volume);
        }
       
       
    }
}
