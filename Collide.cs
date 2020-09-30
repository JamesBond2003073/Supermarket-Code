using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collide : MonoBehaviour
{ public GameObject character;
  public GameObject characterDecoy;
  public GameObject gameOverDisplay;
  public float timer = 1f;
  public Rigidbody decoyBody;
  public int ragdollFlag = 0;
 public BoxCollider floor;
 public BoxCollider floor1;
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "cart" && (other.gameObject.name == "cart" || other.gameObject.GetComponent<stack>().stacked == 1) && ragdollFlag == 0 && top.finishFlag == 0)
        {  
           
                top.finishFlag = 1;
                 other.gameObject.GetComponent<movement>().enabled = false; 
                 floor.enabled = true;
                 if(SceneManager.GetActiveScene().buildIndex > 2)
                 floor1.enabled = true;
                 character.SetActive(false);
                 characterDecoy.SetActive(true);
                 ragdollFlag = 1;
                 decoyBody.AddForce(new Vector3(0f,100f,90f),ForceMode.Impulse);
             
            

        }
    }
    void Update()
    {// Debug.Log(top.finishFlag);
       if(ragdollFlag == 1 && timer > 0f)
       {
           timer -= Time.deltaTime;    
       }
       if(timer <= 0f)
       {  Camera.main.GetComponent<SmoothFollow>().enabled = false;
           gameOverDisplay.SetActive(true);
       }
    }
}
