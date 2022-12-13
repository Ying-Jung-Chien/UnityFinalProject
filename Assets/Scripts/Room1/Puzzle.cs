using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    private Camera camera_m;
    public Transform emptyspace;
    public Transform emptyspace1;
    private Transform currentTile = null;
    public GameObject button;

    // Start is called before the first frame update
    void Start()
    {
        camera_m = Camera.main;
        
    }

    public void ButtonUp(){
        Transform empty;

        if(emptyspace.position.y > emptyspace1.position.y)empty = emptyspace;
        else empty = emptyspace1;
        Vector3 lastemptyspace = empty.position;
        empty.position = currentTile.position;
        currentTile.position = lastemptyspace;
        ClearButton();
    }

    public void ButtonDown(){
        Transform empty;
        if(emptyspace.position.y < emptyspace1.position.y) empty = emptyspace;
        else empty = emptyspace1;
        Vector3 lastemptyspace = empty.position;
        empty.position = currentTile.position;
        currentTile.position = lastemptyspace;
        ClearButton();
    }

    public void ButtonLeft(){
        Transform empty;
        if(emptyspace.position.x < emptyspace1.position.x) empty = emptyspace;
        else empty = emptyspace1;
        Vector3 lastemptyspace = empty.position;
        empty.position = currentTile.position;
        currentTile.position = lastemptyspace;
        ClearButton();
    }

    public void ButtonRight(){
        Transform empty;
        if(emptyspace.position.x > emptyspace1.position.x) empty = emptyspace;
        else empty = emptyspace1;
        Vector3 lastemptyspace = empty.position;
        empty.position = currentTile.position;
        currentTile.position = lastemptyspace;
        ClearButton();
    }

    void ClearButton(){
        if(currentTile != null){
            for(int i=0;i<4;i++){
                currentTile.GetChild(0).GetChild(i).gameObject.SetActive(false);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            print(emptyspace.position);
            Ray ray = camera_m.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if(hit){
                ClearButton();
                if(hit.transform.tag == "square"){
                    if(Vector2.Distance(emptyspace.position, hit.transform.position) < 1.5 && Vector2.Distance(emptyspace1.position, hit.transform.position) < 1.5){
                        currentTile = hit.transform;
                        float X_dis = emptyspace.position.x - hit.transform.position.x;
                        float X_dis1 = emptyspace1.position.x - hit.transform.position.x;
                        float Y_dis = emptyspace.position.y - hit.transform.position.y;
                        float Y_dis1 = emptyspace1.position.y - hit.transform.position.y;
                        
                        if(Y_dis > 0.9f || Y_dis1 > 0.9f) hit.transform.GetChild(0).GetChild(2).gameObject.SetActive(true);
                        if(Y_dis < -0.9f || Y_dis1 < -0.9f) hit.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
                        if(X_dis > 0.9f || X_dis1 > 0.9f) hit.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
                        if(X_dis < -0.9f || X_dis1 < -0.9f) hit.transform.GetChild(0).GetChild(3).gameObject.SetActive(true);
                        
                    }
                    else if(Vector2.Distance(emptyspace.position, hit.transform.position) < 1.5){
                        Vector3 lastemptyspace = emptyspace.position;
                        emptyspace.position = hit.transform.position;
                        hit.transform.position = lastemptyspace;
                    }
                    else if(Vector2.Distance(emptyspace1.position, hit.transform.position) < 1.5){
                        Vector3 lastemptyspace = emptyspace1.position;
                        emptyspace1.position = hit.transform.position;
                        hit.transform.position = lastemptyspace;
                    }
                }
                if(hit.transform.tag == "rect"){
                    if(Vector2.Distance(emptyspace.position, hit.transform.position) < 2 && Vector2.Distance(emptyspace1.position, hit.transform.position) < 2 &&
                        Vector2.Distance(emptyspace.position, emptyspace1.position) < 2){
                        Vector3 lastemptyspace = (emptyspace.position + emptyspace1.position)/2f;
                        if(Mathf.Abs(emptyspace.position.y - hit.transform.position.y) > 0.9f && Mathf.Abs(emptyspace1.position.y - hit.transform.position.y) > 0.9f){
                            emptyspace.position = new Vector3(emptyspace.position.x, hit.transform.position.y, emptyspace.position.z);
                            emptyspace1.position = new Vector3(emptyspace1.position.x, hit.transform.position.y, emptyspace1.position.z);
                        }
                        else {
                            emptyspace.position = new Vector3(hit.transform.position.x, emptyspace.position.y, emptyspace.position.z);
                            emptyspace1.position = new Vector3(hit.transform.position.x, emptyspace1.position.y, emptyspace1.position.z);
                        }
                        hit.transform.position = lastemptyspace;
                    }
                    else if(Vector2.Distance(emptyspace.position, hit.transform.position) < 2 && Vector2.Distance(emptyspace1.position, hit.transform.position) < 2
                            && (Mathf.Abs(emptyspace.position.y - emptyspace1.position.y) > 3f || Mathf.Abs(emptyspace.position.x - emptyspace1.position.x) > 3f )){
                        currentTile = hit.transform;
                        hit.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
                        hit.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
                    }
                    else if(Vector2.Distance(emptyspace.position, hit.transform.position) < 2 || Vector2.Distance(emptyspace1.position, hit.transform.position) < 2){
                        
                        if(hit.transform.rotation.z == 0){
                            if(Mathf.Abs(emptyspace.position.y - emptyspace1.position.y) > 1.5f){

                            }
                        }
                        
                    }
                   
                }
                if(hit.transform.tag == "LargeSquare"){
                    if(Vector2.Distance(emptyspace.position, hit.transform.position) < 2){
                        Vector2 lastemptyspace = emptyspace.position;
                        emptyspace.position = hit.transform.position;
                        hit.transform.position = emptyspace.position;
                    }
                    else if(Vector2.Distance(emptyspace1.position, hit.transform.position) < 2){
                        Vector2 lastemptyspace = emptyspace1.position;
                        emptyspace1.position = hit.transform.position;
                        hit.transform.position = emptyspace1.position;
                    }
                }
                
            }
        }
        
    }
}
