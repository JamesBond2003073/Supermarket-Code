using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveUI : MonoBehaviour
{
    
   // public float timer = 0.2f;
    public RectTransform myRectTransform;
    
    // Start is called before the first frame update
    void Start()
    {
        myRectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    { // timer -= Time.deltaTime;

        if(Time.timeScale != 0f)
        transform.Translate(0f,9.5f,0f);
        
 
    }
}
