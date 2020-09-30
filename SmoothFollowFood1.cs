using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollowFood1 : MonoBehaviour
{
public Transform target;
   public float smoothSpeed = 0.3f;
  public Vector3 offset = Vector3.zero;
 private Vector3 refvel;  
 public Rigidbody rb; 
 public int fallFlag = 0;

void OnTriggerEnter(Collider other)
{
    if(other.gameObject.tag == "cart" && fallFlag == 0 && other.gameObject.transform.GetChild(3).GetComponent<Weight>().weight < 250)
    {
    target = other.gameObject.transform.GetChild(2).transform;  
    fallFlag = 1;
    }
}

   void Start()
   {
     rb = this.gameObject.transform.parent.gameObject.GetComponent<Rigidbody>();
    
   }

    void FixedUpdate()
    {     if(fallFlag == 1)
         { Vector3 desiredPosition = target.position + offset;
      Vector3 smoothedPosition = Vector3.SmoothDamp(transform.parent.transform.position,desiredPosition,ref refvel,smoothSpeed);
       transform.parent.transform.position = smoothedPosition;
         }
    }
}
