using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
public Transform target;
public float smoothRotation = 10f;
public float smoothFov = 2f;
   public float smoothSpeed = 0.3f;
  public Vector3 offset;
 private Vector3 refvel;   
 public Quaternion targetRotation;
 public Vector3 temp;
 public float fov;
 public float refFov;
 public movement mov;
   void Start()
   { mov = GameObject.Find("cart").GetComponent<movement>();
     offset = new Vector3(0f,6.1f,-3f);
      temp.x = 37f;
    //offset = new Vector3(0f,4f,-2.7f);
     //temp.x = 30f;
     fov = 60f;
     temp.y = transform.rotation.eulerAngles.y;
     temp.z = transform.rotation.eulerAngles.z;
   }

    void FixedUpdate()
    {   if(mov.startFlag == 1)
    {
          Vector3 desiredPosition = target.position + offset;
      Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position,desiredPosition,ref refvel,smoothSpeed);
       transform.position = smoothedPosition;

         targetRotation.eulerAngles = temp; 
         transform.rotation = Quaternion.RotateTowards(transform.rotation,targetRotation,smoothRotation * Time.deltaTime);
        Camera.main.fieldOfView = Mathf.SmoothDamp(Camera.main.fieldOfView,fov,ref refFov,smoothFov * Time.deltaTime);
         //offset = new Vector3(0f,5f,-1.6f);
        
    }  
    }
}
