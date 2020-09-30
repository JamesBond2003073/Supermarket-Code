using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class top : MonoBehaviour
{
  public static GameObject topCart;
  public static GameObject baseCart;
  public static float displacement;
  public static int multiple;
  public static int cartNumber; 
  public static int finishFlag;
  public List<GameObject> carts;


    // Start is called before the first frame update
    void Start()
    { 
      Application.targetFrameRate = 300;
      
      foreach (Transform child in GameObject.Find("cartsNew").transform)
    { 
      carts.Add(child.gameObject);
    }

       finishFlag = 0; 
        multiple = 0;
        cartNumber = 1;
        topCart = GameObject.Find("cart");
        baseCart = GameObject.Find("cart");
        
        displacement = 0.95f;
    }

    // Update is called once per frame
    void Update()
    {
      if(finishFlag == 1)
      {
        foreach (GameObject cart in carts)
        {
            foreach (BoxCollider col in cart.GetComponents<BoxCollider>())
            {
                if(col.isTrigger == false)
                col.enabled = true;
            }
        }
      }
    }
}
