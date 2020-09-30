using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restfood : MonoBehaviour
{
  public SmoothFollowFood1 follow;
  public GameObject cart;
  public GameObject scorePrefab;
  public GameObject instance;
  public Camera cam;
  public GameObject canvas;
  public Vector3 center;
    // Start is called before the first frame update
    void Start()
    { 
      follow = transform.GetChild(0).gameObject.GetComponent<SmoothFollowFood1>();
      cam = GameObject.Find("Main Camera").GetComponent<Camera>();
      canvas = GameObject.Find("Canvas");
      center = new Vector3(154f,-20f,0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == follow.target.gameObject)
        {  
           cart = other.gameObject.transform.parent.gameObject;
           follow.target = other.gameObject.transform.parent.transform.GetChild(3).transform;
           follow.smoothSpeed = 0.02f;
        }
        if(other.gameObject == follow.target.transform.parent.GetChild(3).transform.gameObject)
        {
         //this.gameObject.GetComponent<MeshRenderer>().enabled = false;
         this.gameObject.SetActive(false);
         if(SceneManager.GetActiveScene().buildIndex == 2 || SceneManager.GetActiveScene().buildIndex == 5 || SceneManager.GetActiveScene().buildIndex == 6)
         other.gameObject.transform.parent.transform.GetChild(3).transform.gameObject.GetComponent<Weight>().weight+= 2.6f;
         else
         other.gameObject.transform.parent.transform.GetChild(3).transform.gameObject.GetComponent<Weight>().weight++;

         top.multiple ++;
         if(top.multiple % 15 == 0)
         { 
          instance = Instantiate(scorePrefab,new Vector3(cart.transform.position.x,cart.transform.position.y,center.z),Quaternion.identity);
          
          instance.transform.SetParent(canvas.transform,false);
        }
    if(SceneManager.GetActiveScene().buildIndex == 2 || SceneManager.GetActiveScene().buildIndex == 5 || SceneManager.GetActiveScene().buildIndex == 6)
       {
         if(this.gameObject.transform.parent.gameObject.name == "original")
        {
        if(top.multiple % 12 == 0)
        Taptic.Light();
        }
        if(this.gameObject.transform.parent.gameObject.name == "cubestraight")
        {
        if(top.multiple % 7 == 0)
        Taptic.Light();
        }
        if(this.gameObject.transform.parent.gameObject.name == "tiltedvertical")
        {
        if(top.multiple % 4 == 0)
        Taptic.Light();
        }
       }
       else
       {
            if(this.gameObject.transform.parent.gameObject.name == "original")
        {
        if(top.multiple % 17 == 0)
        Taptic.Light();
        }
        if(this.gameObject.transform.parent.gameObject.name == "cubestraight")
        {
        if(top.multiple % 12 == 0)
        Taptic.Light();
        }
        if(this.gameObject.transform.parent.gameObject.name == "tiltedvertical")
        {
        if(top.multiple % 7 == 0)
        Taptic.Light();
        }
       }
        }

    }
}
