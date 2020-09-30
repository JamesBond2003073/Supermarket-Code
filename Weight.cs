using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weight : MonoBehaviour
{
  public float weight = 0;
  public GameObject lowWeight;
  public GameObject medWeight;
  public GameObject highWeight;
  public int lowFlag = 0;
  public int medFlag = 0;
  public int highFlag = 0;
    void Update()
    {
    
            if(weight > 15f && lowFlag == 0 && medFlag == 0 && highFlag == 0)
            {
                lowWeight.SetActive(true);
                medWeight.SetActive(false);
                highWeight.SetActive(false);
                lowFlag = 1;
            }
            if(weight > 150f && medFlag == 0 && highFlag == 0)
            {
                lowWeight.SetActive(false);
                medWeight.SetActive(true);
                highWeight.SetActive(false);
                lowFlag = 0;
                medFlag = 1;
            }
            if(weight >= 250f && highFlag == 0)
            {
                lowWeight.SetActive(false);
                medWeight.SetActive(false);
                highWeight.SetActive(true);
                medFlag = 0;
                highFlag = 1;
               // this.gameObject.transform.parent.transform.GetChild(9).gameObject.SetActive(true);
            }
            
        
    }
}
