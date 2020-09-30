using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movement : MonoBehaviour
{ // public Joystick joystickDir;
   public Rigidbody rb;
   public float fwdSpeed;
   public float sideSpeed;
   public float sideTiltVelocity;
   public float sideTilt;
   public float sideVel;
   public Vector3 refvel = Vector3.zero;
   public float smoothZero = 1f;
   public int finishFlag = 0;
   public int offsetFlag = 0;
   public int activeFlag = 0;
   public SmoothFollow followCam;
   public Animator anim;
   public float refAnim;
   public GameObject levelCleared;
   public GameObject confetti;
   public RigidbodyConstraints rbConstraints;
   public float smoothFov = 1f;
   public float refFov;
   public Vector2 startPos;
   public Vector2 distance;
   public int startFlag = 0;
   public int downFlag = 0;

    // Start is called before the first frame update
    void Start()
    {  //joystickDir =  GameObject.FindGameObjectWithTag("joyDir").GetComponent<Joystick>() as Joystick; 
       distance = Vector2.zero; 
       followCam = GameObject.Find("Main Camera").GetComponent<SmoothFollow>();
        anim = this.gameObject.transform.GetChild(10).GetComponent<Animator>(); 
        Time.timeScale = 1f;
        rbConstraints = RigidbodyConstraints.None;
    }



    void Update()
    { 
      // if(Input.touchCount > 0 && startFlag == 0)
      if(Input.GetMouseButton(0) && startFlag == 0)
      {
        startFlag = 1;
        // this.gameObject.transform.GetChild(10).transform.localPosition = new Vector3(-0.026f,0.93f,-0.32f);
        // this.gameObject.transform.GetChild(10).transform.localEulerAngles = new Vector3(0f,180f,0f);
      }
       
       if(finishFlag == 0 && top.finishFlag == 0)
      {

      if(startFlag == 1)
     {
       rb.velocity = new Vector3(Mathf.Clamp(rb.velocity.x,-5f,5f),rb.velocity.y,rb.velocity.z);
       rb.angularVelocity = Vector3.zero;
       rb.velocity = new Vector3(rb.velocity.x,0f,fwdSpeed);
       anim.SetBool("start",true);
      
     }
        if(Input.touchCount > 0)
        { 
          Touch touch = Input.GetTouch(0);
          if(touch.phase == TouchPhase.Began)
          {
           startPos = touch.position;
          }
          if( touch.phase == TouchPhase.Moved)
         { 
           if(Mathf.Sqrt((touch.position.x * startPos.x) + (touch.position.y * startPos.y)) > 0.05f && Input.GetAxis("Mouse X") != 0f)
          {
       rb.AddForce(Vector3.right  * sideSpeed * Input.GetAxis("Mouse X"));
       sideTilt = Mathf.SmoothDamp(sideTilt,-20f* Input.GetAxis("Mouse X"),ref sideTiltVelocity,8f * Time.deltaTime);
       sideTilt = Mathf.Clamp(sideTilt,-8.5f,8.5f);
          }
          else
          {
             sideTilt = Mathf.SmoothDamp(sideTilt,0f,ref sideTiltVelocity,10f * Time.deltaTime);
             rb.velocity = new Vector3(Mathf.SmoothDamp(rb.velocity.x,0f,ref sideVel,8f * Time.deltaTime),0f,rb.velocity.z);
          }
        }
        else
        {
          sideTilt = Mathf.SmoothDamp(sideTilt,0f,ref sideTiltVelocity,10f * Time.deltaTime);
          rb.velocity = new Vector3(Mathf.SmoothDamp(rb.velocity.x,0f,ref sideVel,8f * Time.deltaTime),0f,rb.velocity.z);
        }
       }
        else 
        {
             sideTilt = Mathf.SmoothDamp(sideTilt,0f,ref sideTiltVelocity,10f * Time.deltaTime);
             rb.velocity = new Vector3(Mathf.SmoothDamp(rb.velocity.x,0f,ref sideVel,8f * Time.deltaTime),0f,rb.velocity.z);
        }
        //rb.rotation = Quaternion.Euler(new Vector3(sideTilt,90-sideTilt ,0f));
        rb.rotation = Quaternion.Euler(new Vector3(0f,-sideTilt ,-sideTilt));
      }
      else if(finishFlag == 1 && top.finishFlag == 0)
      {
        TinySauce.OnGameFinished((SceneManager.GetActiveScene().buildIndex + 1).ToString(), 1);
        rb.velocity = Vector3.SmoothDamp(rb.velocity,Vector3.zero,ref refvel, smoothZero);
        anim.speed = Mathf.SmoothDamp(anim.speed,0f, ref refAnim,1f);
        if(offsetFlag == 0)
        {
          followCam.smoothSpeed = 1f;
          followCam.smoothFov = 1f;
          followCam.offset = new Vector3(followCam.offset.x,followCam.offset.y,followCam.offset.z - 3f);          
         followCam.fov += 5f;
          offsetFlag = 1;
        }
      }
      else if( top.finishFlag == 1)
      {
        rb.velocity = Vector3.zero;
        rb.constraints = rbConstraints; 
     
      }
      if(rb.velocity.z >= -1f && rb.velocity.z <= 1f && activeFlag == 0 && top.finishFlag == 0 && startFlag == 1)
      {
        levelCleared.SetActive(true);
        Instantiate(confetti,transform.position + new Vector3(0f,3f,0f),Quaternion.identity);
        activeFlag = 1;
      }
      //  transform.eulerAngles = new Vector3(transform.eulerAngles.x,transform.eulerAngles.x + sideTilt + 90,transform.eulerAngles.z + sideTilt);
    }
}
