using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    public Camera camera_m;
    public Transform emptyspace;
    public Transform emptyspace1;
    private Transform currentTile = null;
    public GameObject button;
    private float square_size; 
    public GameObject master;
    public GameObject wallsquish;
    public GameObject Door;

    public AudioClip click;
    public AudioSource audioPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
        square_size = 1.22f;
        
    }

    public void ButtonUp(){
        Transform empty;

        audioPlayer.PlayOneShot(click);
        if (emptyspace.localPosition.y > emptyspace1.localPosition.y)empty = emptyspace;
        else empty = emptyspace1;
        Vector3 lastemptyspace = empty.localPosition;
        empty.localPosition = currentTile.localPosition;
        currentTile.localPosition = lastemptyspace;
        ClearButton();
    }

    public void ButtonDown(){

        audioPlayer.PlayOneShot(click);
        Transform empty;
        if(emptyspace.localPosition.y < emptyspace1.localPosition.y) empty = emptyspace;
        else empty = emptyspace1;
        Vector3 lastemptyspace = empty.localPosition;
        empty.localPosition = currentTile.localPosition;
        currentTile.localPosition = lastemptyspace;
        ClearButton();
    }

    public void ButtonLeft(){

        audioPlayer.PlayOneShot(click);
        Transform empty;
        if(emptyspace.localPosition.x < emptyspace1.localPosition.x) empty = emptyspace;
        else empty = emptyspace1;
        Vector3 lastemptyspace = empty.localPosition;
        empty.localPosition = currentTile.localPosition;
        currentTile.localPosition = lastemptyspace;
        ClearButton();
    }

    public void ButtonRight(){

        audioPlayer.PlayOneShot(click);
        Transform empty;
        if(emptyspace.localPosition.x > emptyspace1.localPosition.x) empty = emptyspace;
        else empty = emptyspace1;
        Vector3 lastemptyspace = empty.localPosition;
        empty.localPosition = currentTile.localPosition;
        currentTile.localPosition = lastemptyspace;
        ClearButton();
    }

     public void RectUp()
    {
        audioPlayer.PlayOneShot(click);
        Transform avil = null;
        if(Vector2.Distance(emptyspace.localPosition, currentTile.localPosition) < 2 && Mathf.Abs(emptyspace.localPosition.y - currentTile.localPosition.y )> 1.5f) avil = emptyspace;
        else if(Vector2.Distance(emptyspace1.localPosition, currentTile.localPosition) < 2 && Mathf.Abs(emptyspace1.localPosition.y - currentTile.localPosition.y )> 1.5f)avil = emptyspace1;
        avil.localPosition = new Vector3( avil.localPosition.x, avil.localPosition.y  - square_size*2f, avil.localPosition.z );
        currentTile.localPosition = new Vector3( currentTile.localPosition.x, currentTile.localPosition.y + square_size, currentTile.localPosition.z );
               
        ClearButton();
    }

    public void RectDown()
    {
        audioPlayer.PlayOneShot(click);
        Transform avil = null;
        if(Vector2.Distance(emptyspace.localPosition, currentTile.localPosition) < 2 && Mathf.Abs(emptyspace.localPosition.y - currentTile.localPosition.y )> 1.5f) avil = emptyspace;
        else if(Vector2.Distance(emptyspace1.localPosition, currentTile.localPosition) < 2 && Mathf.Abs(emptyspace1.localPosition.y - currentTile.localPosition.y )> 1.5f)avil = emptyspace1;
        avil.localPosition = new Vector3( avil.localPosition.x, avil.localPosition.y + square_size*2f, avil.localPosition.z );
        currentTile.localPosition = new Vector3( currentTile.localPosition.x, currentTile.localPosition.y - square_size, currentTile.localPosition.z );
         
        ClearButton();
    }

    public void RectLeft()
    {
        audioPlayer.PlayOneShot(click);
        Transform avil = null;
        if(Vector2.Distance(emptyspace.localPosition, currentTile.localPosition) < 2 &&  currentTile.localPosition.x - emptyspace.localPosition.x > 1.5f) avil = emptyspace;
        else if(Vector2.Distance(emptyspace1.localPosition, currentTile.localPosition) < 2 && currentTile.localPosition.x - emptyspace1.localPosition.x > 1.5f)avil = emptyspace1;
        avil.localPosition = new Vector3( avil.localPosition.x + square_size*2f, avil.localPosition.y, avil.localPosition.z );
        currentTile.localPosition = new Vector3( currentTile.localPosition.x - square_size, currentTile.localPosition.y, currentTile.localPosition.z );
                
        ClearButton();
    }


    public void RectRight()
    {
        audioPlayer.PlayOneShot(click);
        Transform avil = null;
        if(Vector2.Distance(emptyspace.localPosition, currentTile.localPosition) < 2 && emptyspace.localPosition.x - currentTile.localPosition.x > 1.5f) avil = emptyspace;
        else if(Vector2.Distance(emptyspace1.localPosition, currentTile.localPosition) < 2 && emptyspace1.localPosition.x - currentTile.localPosition.x> 1.5f)avil = emptyspace1;
        avil.localPosition = new Vector3( avil.localPosition.x - square_size*2f, avil.localPosition.y, avil.localPosition.z );
        currentTile.localPosition = new Vector3( currentTile.localPosition.x + square_size, currentTile.localPosition.y, currentTile.localPosition.z );
               
        ClearButton();
    }
    void ClearButton(){
        if(currentTile != null){
            for(int i=0;i<currentTile.transform.GetChild(0).childCount;i++){
                currentTile.GetChild(0).GetChild(i).gameObject.SetActive(false);
            
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (master.transform.localPosition.y < 0.78f && master.transform.localPosition.x > -0.61f && master.transform.localPosition.x < 0.61f){
            wallsquish.GetComponent<WallSquish>().SetSolved();
            Door.GetComponent<DoorAOpen>().SetCanOpen();
            this.gameObject.transform.parent.gameObject.SetActive(false);
        }
        if(Input.GetMouseButtonDown(1)){
            audioPlayer.PlayOneShot(click);
            Ray ray = camera_m.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if(hit){
                ClearButton();
                if(hit.transform.tag == "square"){
                    if(Vector2.Distance(emptyspace.localPosition, hit.transform.localPosition) < 1.5 && Vector2.Distance(emptyspace1.localPosition, hit.transform.localPosition) < 1.5){
                        currentTile = hit.transform;
                        float X_dis = emptyspace.localPosition.x - hit.transform.localPosition.x;
                        float X_dis1 = emptyspace1.localPosition.x - hit.transform.localPosition.x;
                        float Y_dis = emptyspace.localPosition.y - hit.transform.localPosition.y;
                        float Y_dis1 = emptyspace1.localPosition.y - hit.transform.localPosition.y;
                        
                        if(Y_dis > 0.9f || Y_dis1 > 0.9f) hit.transform.GetChild(0).GetChild(2).gameObject.SetActive(true);
                        if(Y_dis < -0.9f || Y_dis1 < -0.9f) hit.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
                        if(X_dis > 0.9f || X_dis1 > 0.9f) hit.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
                        if(X_dis < -0.9f || X_dis1 < -0.9f) hit.transform.GetChild(0).GetChild(3).gameObject.SetActive(true);
                        
                    }
                    else if(Vector2.Distance(emptyspace.localPosition, hit.transform.localPosition) < 1.5){
                        Vector3 lastemptyspace = emptyspace.localPosition;
                        emptyspace.localPosition = hit.transform.localPosition;
                        hit.transform.localPosition = lastemptyspace;
                    }
                    else if(Vector2.Distance(emptyspace1.localPosition, hit.transform.localPosition) < 1.5){
                        Vector3 lastemptyspace = emptyspace1.localPosition;
                        emptyspace1.localPosition = hit.transform.localPosition;
                        hit.transform.localPosition = lastemptyspace;
                    }
                }
                if(hit.transform.tag == "rect"){
                    if((Vector2.Distance(emptyspace.localPosition, hit.transform.localPosition) < 1.5f*square_size + 0.1f || Vector2.Distance(emptyspace1.localPosition, hit.transform.localPosition) < 1.5f*square_size + 0.1f)
                     && Vector2.Distance(emptyspace.localPosition, emptyspace1.localPosition) < square_size+0.2f 
                     && ((Mathf.Abs(emptyspace.localPosition.x - emptyspace1.localPosition.x) <0.2f && hit.transform.rotation.z == 0)|| 
                     (hit.transform.rotation.z != 0 &&(Mathf.Abs(emptyspace.localPosition.y - emptyspace1.localPosition.y) <0.2f)))){
                        
                        Vector3 lastemptyspace = (emptyspace.localPosition + emptyspace1.localPosition)/2f;
                        if(hit.transform.rotation.z == 0){
                            if(Mathf.Abs(emptyspace.localPosition.x - emptyspace1.localPosition.x) <0.2f){
                                if(Mathf.Abs(emptyspace.localPosition.y - hit.transform.localPosition.y) > square_size && Mathf.Abs(emptyspace1.localPosition.y - hit.transform.localPosition.y) > square_size){
                                    emptyspace.localPosition = new Vector3(emptyspace.localPosition.x, hit.transform.localPosition.y + 0.5f* square_size, emptyspace.localPosition.z);
                                    emptyspace1.localPosition = new Vector3(emptyspace1.localPosition.x, hit.transform.localPosition.y - 0.5f* square_size, emptyspace1.localPosition.z);
                                }
                                else {
                                    emptyspace.localPosition = new Vector3(hit.transform.localPosition.x, emptyspace.localPosition.y, emptyspace.localPosition.z);
                                    emptyspace1.localPosition = new Vector3(hit.transform.localPosition.x, emptyspace1.localPosition.y, emptyspace1.localPosition.z);
                                }
                                hit.transform.localPosition = lastemptyspace;
                            }
                        }
                        else{
                            if(Mathf.Abs(emptyspace.localPosition.y - emptyspace1.localPosition.y) <0.2f){
                                 if(Mathf.Abs(emptyspace.localPosition.y - hit.transform.localPosition.y) > square_size - 0.2f && Mathf.Abs(emptyspace1.localPosition.y - hit.transform.localPosition.y) > square_size - 0.2f){
                                    emptyspace.localPosition = new Vector3(emptyspace.localPosition.x, hit.transform.localPosition.y, emptyspace.localPosition.z);
                                    emptyspace1.localPosition = new Vector3(emptyspace1.localPosition.x, hit.transform.localPosition.y, emptyspace1.localPosition.z);
                                }
                                else {
                                    emptyspace.localPosition = new Vector3(hit.transform.localPosition.x- 0.5f* square_size, emptyspace.localPosition.y, emptyspace.localPosition.z);
                                    emptyspace1.localPosition = new Vector3(hit.transform.localPosition.x + 0.5f* square_size, emptyspace1.localPosition.y, emptyspace1.localPosition.z);
                                }
                                hit.transform.localPosition = lastemptyspace;
                            }
                            
                           
                        
                        }
                    }
                    else if(Vector2.Distance(emptyspace.localPosition, hit.transform.localPosition) < 2 && Vector2.Distance(emptyspace1.localPosition, hit.transform.localPosition) < 2
                            && (Mathf.Abs(emptyspace.localPosition.y - emptyspace1.localPosition.y) > 3f || Mathf.Abs(emptyspace.localPosition.x - emptyspace1.localPosition.x) > 3f )){
                        
                        currentTile = hit.transform;
                        hit.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
                        hit.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
                    }
                    else if(Vector2.Distance(emptyspace.localPosition, hit.transform.localPosition) < 2 || Vector2.Distance(emptyspace1.localPosition, hit.transform.localPosition) < 2){
                        
                        Transform avil = null;
                        
                        if(hit.transform.rotation.z == 0){
                            if(Vector2.Distance(emptyspace.localPosition, hit.transform.localPosition) < 2 && Mathf.Abs(emptyspace.localPosition.y - hit.transform.localPosition.y )> 1.5f) avil = emptyspace;
                            else if(Vector2.Distance(emptyspace1.localPosition, hit.transform.localPosition) < 2 && Mathf.Abs(emptyspace1.localPosition.y - hit.transform.localPosition.y )> 1.5f)avil = emptyspace1;
                            if(avil != null){
                                if(avil.localPosition.y - hit.transform.localPosition.y > 1.5f){
                                    avil.localPosition = new Vector3( avil.localPosition.x, avil.localPosition.y  - square_size*2f, avil.localPosition.z );
                                    hit.transform.localPosition = new Vector3( hit.transform.localPosition.x, hit.transform.localPosition.y + square_size, hit.transform.localPosition.z );
                                }
                                else if(avil.localPosition.y - hit.transform.localPosition.y < -1.5f){
                                    
                                    avil.localPosition = new Vector3( avil.localPosition.x, avil.localPosition.y + square_size*2f, avil.localPosition.z );
                                    hit.transform.localPosition = new Vector3( hit.transform.localPosition.x, hit.transform.localPosition.y - square_size, hit.transform.localPosition.z );
                                }
                            }
                            
                        }
                        else {
                            if(Vector2.Distance(emptyspace.localPosition, hit.transform.localPosition) < 2 && Mathf.Abs(emptyspace.localPosition.x - hit.transform.localPosition.x )> 1.5f) avil = emptyspace;
                            else if(Vector2.Distance(emptyspace1.localPosition, hit.transform.localPosition) < 2 && Mathf.Abs(emptyspace1.localPosition.x - hit.transform.localPosition.x )> 1.5f)avil = emptyspace1;
                            if(avil != null){
                                if(avil.localPosition.x - hit.transform.localPosition.x > 1.5f){
                                    avil.localPosition = new Vector3( avil.localPosition.x - square_size*2f, avil.localPosition.y, avil.localPosition.z );
                                    hit.transform.localPosition = new Vector3( hit.transform.localPosition.x + square_size, hit.transform.localPosition.y, hit.transform.localPosition.z );
                                }
                                else if(avil.localPosition.x - hit.transform.localPosition.x < -1.5f){
                                    avil.localPosition = new Vector3( avil.localPosition.x + square_size*2f, avil.localPosition.y, avil.localPosition.z );
                                    hit.transform.localPosition = new Vector3( hit.transform.localPosition.x - square_size, hit.transform.localPosition.y, hit.transform.localPosition.z );
                                }
                            }
                        }
                        
                    }
                   
                }
                if(hit.transform.tag == "LargeSquare"){
                    if((Vector2.Distance(emptyspace.localPosition, hit.transform.localPosition) < 1.5f*square_size + 0.2f && Vector2.Distance(emptyspace1.localPosition, hit.transform.localPosition) < 1.5f*square_size + 0.2f)
                     && Vector2.Distance(emptyspace.localPosition, emptyspace1.localPosition) < square_size+0.2f){
                        float X_dis = emptyspace.localPosition.x - hit.transform.localPosition.x;
                        float Y_dis = emptyspace.localPosition.y - hit.transform.localPosition.y;
                        if(Mathf.Abs(X_dis) > 1.5f * square_size - 0.2f){
                            if(X_dis > 0){
                                hit.transform.localPosition = new Vector3(hit.transform.localPosition.x + square_size, hit.transform.localPosition.y, hit.transform.localPosition.z);
                                emptyspace.localPosition = new Vector3(emptyspace.localPosition.x - 2f* square_size, emptyspace.localPosition.y, emptyspace.localPosition.z);
                                emptyspace1.localPosition = new Vector3(emptyspace1.localPosition.x- 2f* square_size, emptyspace1.localPosition.y, emptyspace1.localPosition.z);
                            }
                            else{
                                hit.transform.localPosition = new Vector3(hit.transform.localPosition.x - square_size, hit.transform.localPosition.y, hit.transform.localPosition.z);
                                emptyspace.localPosition = new Vector3(emptyspace.localPosition.x + 2f* square_size, emptyspace.localPosition.y, emptyspace.localPosition.z);
                                emptyspace1.localPosition = new Vector3(emptyspace1.localPosition.x + 2f* square_size, emptyspace1.localPosition.y, emptyspace1.localPosition.z);
                            
                            }
                        }
                        else if(Mathf.Abs(Y_dis) > 1.5f * square_size - 0.2f){
                            if(Y_dis > 0){
                                hit.transform.localPosition = new Vector3(hit.transform.localPosition.x , hit.transform.localPosition.y+ square_size, hit.transform.localPosition.z);
                                emptyspace.localPosition = new Vector3(emptyspace.localPosition.x , emptyspace.localPosition.y- 2f* square_size, emptyspace.localPosition.z);
                                emptyspace1.localPosition = new Vector3(emptyspace1.localPosition.x, emptyspace1.localPosition.y - 2f* square_size, emptyspace1.localPosition.z);
                            }
                            else{
                                hit.transform.localPosition = new Vector3(hit.transform.localPosition.x, hit.transform.localPosition.y - square_size, hit.transform.localPosition.z);
                                emptyspace.localPosition = new Vector3(emptyspace.localPosition.x, emptyspace.localPosition.y + 2f* square_size, emptyspace.localPosition.z);
                                emptyspace1.localPosition = new Vector3(emptyspace1.localPosition.x, emptyspace1.localPosition.y + 2f* square_size, emptyspace1.localPosition.z);
                            
                            }
                        }
                        
                    }
                    
                }
                
            }
        }
        
    }
}
