using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stack : MonoBehaviour
{
 public int stackFlag = 0;
 public float displacement;
 public GameObject splash;
 public GameObject splashInstance;
 public Vector3 splashOffset = new Vector3(0f,0f,1f);
 public movement mov;
 public float stacked = 0;
 public SmoothFollow followCam;
 public GameObject speedPS;
 private float speedTimer = 1f;
public GameObject frontCart;
public int speedFlag = 0;

void Start()
{ mov = GameObject.Find("cart").GetComponent<movement>();
  followCam = GameObject.Find("Main Camera").GetComponent<SmoothFollow>();
}

   void OnTriggerEnter(Collider other)
    {
      if(this.gameObject == top.topCart && other.gameObject.tag == "stack" && stackFlag == 0)
      {    
              other.gameObject.transform.parent.gameObject.GetComponent<stack>().stacked = 1;
              Taptic.Medium();
              speedPS.SetActive(true);
              //other.gameObject.transform.parent.gameObject.GetComponent<movement>().enabled = true;
              foreach(BoxCollider col in GetComponents<BoxCollider>())
              {
                 // if(col.isTrigger == false)
                 // col.enabled = false;
              }
              foreach(BoxCollider col in other.gameObject.transform.parent.gameObject.GetComponents<BoxCollider>())
              {
                 // if(col.isTrigger == false)
                 // col.enabled = true;
              }
              stackFlag = 1;
              top.cartNumber ++;
              top.topCart = other.gameObject.transform.parent.gameObject;
              displacement = top.displacement;
              top.displacement += 0.95f;
              frontCart = other.gameObject.transform.parent.gameObject;
              top.topCart.transform.GetChild(1).GetComponent<BoxCollider>().enabled = false;
             splashInstance = Instantiate(splash,this.transform.position + splashOffset, Quaternion.identity );
             splashInstance.transform.SetParent(this.gameObject.transform,true);

             followCam.fov += 1.5f;
             followCam.temp.x += 0.7f;
             followCam.offset += new Vector3(0f,0.2f,0.2f);
      }
      if(other.gameObject.tag == "Finish")
      {
        mov.finishFlag = 1;
      }

    }
    
    void Update()
    {
    if(stackFlag == 1 && top.finishFlag == 0 )
    {  speedTimer -= Time.deltaTime;
      if(speedTimer <= 0f && frontCart == top.topCart && speedFlag == 0)
     {  speedFlag = 1;
        speedPS.SetActive(false);
        followCam.fov -= 1f;
        //top.baseCart.GetComponent<Rigidbody>().velocity = new Vector3
     }
  frontCart.transform.position = new Vector3(top.baseCart.transform.position.x ,top.baseCart.transform.position.y,top.baseCart.transform.position.z + displacement);
  frontCart.transform.rotation  =  top.baseCart.transform.rotation;
    }

    }
}
