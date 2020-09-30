using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementnew : MonoBehaviour
{
   public Rigidbody rb;
   public float fwdSpeed;
   public float sideSpeed;
   public float sideTiltVelocity;
   public float sideTilt;
   public float sideVel;
   
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
    }

    

    // Update is called once per frame
    void FixedUpdate()
    { Debug.Log(sideTilt);
      
      rb.velocity = new Vector3(Mathf.Clamp(rb.velocity.x,-5f,5f),rb.velocity.y,rb.velocity.z);
        rb.angularVelocity = Vector3.zero;
        
      rb.velocity = new Vector3(rb.velocity.x,0f,-fwdSpeed);
      // Debug.Log(Input.GetAxis("Mouse X"));
        if(Input.GetMouseButton(0) && (Input.GetAxis("Mouse X") > 0f || Input.GetAxis("Mouse X") < 0f))
        {
       rb.AddForce(Vector3.right  * -sideSpeed * Input.GetAxis("Mouse X"));
       sideTilt = Mathf.SmoothDamp(sideTilt,-55* Input.GetAxis("Mouse X"),ref sideTiltVelocity,0.1f);
       sideTilt = Mathf.Clamp(sideTilt,-8.5f,8.5f);
        }
        else
        {
             sideTilt = Mathf.SmoothDamp(sideTilt,0f,ref sideTiltVelocity,0.1f);
             rb.velocity = new Vector3(Mathf.SmoothDamp(rb.velocity.x,0f,ref sideVel,0.3f),0f,rb.velocity.z);
        }
        rb.rotation = Quaternion.Euler(new Vector3(-90 + sideTilt,sideTilt-180 ,rb.rotation.z));

      //  transform.eulerAngles = new Vector3(transform.eulerAngles.x,transform.eulerAngles.x + sideTilt + 90,transform.eulerAngles.z + sideTilt);
    }
}
