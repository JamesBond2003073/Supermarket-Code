using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitleft : MonoBehaviour
{ 
    public int openFlag = 0;

   void OnTriggerEnter(Collider other)
   {
      if(other.gameObject.tag == "cart")
      {
          openFlag = 1;
      }
   }

   void Update()
   {
       if(openFlag == 1)
       transform.Translate(0.05f,0f,0f);
   }
}
