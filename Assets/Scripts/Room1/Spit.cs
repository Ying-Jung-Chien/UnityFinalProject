using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spit : MonoBehaviour
{
    private Animation anim;
    public GameObject pearl;
    private bool spit;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();
        spit = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Enemy.enemydead && !spit){
            //anim.Play("OpenMouth");
            StartCoroutine(SetPearl());
            
            spit = true;
        }
    }

    IEnumerator SetPearl(){
		yield return new WaitForSeconds(2f);
		pearl.SetActive(true);
	}
    
}
