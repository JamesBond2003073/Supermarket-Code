using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VehicleStart : MonoBehaviour
{
    public int vehicleFlag = 0;
    public GameObject vehicle1;
    public GameObject vehicle2;
    public GameObject vehicle3;
    public GameObject vehicle4;
    
   void OnTriggerEnter(Collider other)
   {
       if(other.gameObject.tag == "cart")
       vehicleFlag = 1;
   }

    // Update is called once per frame
    void Update()
    {   if(vehicleFlag == 1)
        {   if(SceneManager.GetActiveScene().buildIndex == 4)
            {
            vehicle1.transform.Translate(0f,0f,-8f * Time.deltaTime);
            vehicle2.transform.Translate(0f,0f,-8f * Time.deltaTime);
            }
            vehicle3.transform.Translate(0f,0f,-8f * Time.deltaTime);
            vehicle4.transform.Translate(0f,0f,-8f * Time.deltaTime);
        }
    }
}
