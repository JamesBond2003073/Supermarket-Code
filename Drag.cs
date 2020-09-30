using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour,IEndDragHandler,IDragHandler
{
  public Camera cam;
  public Vector3 targetPosition;
  public int dragging = 0;
  public Vector3 screenPosition;
  
void Start()
{
     cam = GameObject.Find("Main Camera").GetComponent<Camera>();
}

    public void OnDrag(PointerEventData eventData)
    {  dragging = 1;
         Vector3 dragVectorDirection = (eventData.position - eventData.pressPosition);
        // Debug.Log(dragVectorDirection);
      screenPosition = eventData.position;
      screenPosition.z = 5;
      targetPosition = cam.ScreenToWorldPoint(screenPosition);
    // targetPosition = (eventData.position);
     
      Debug.Log(targetPosition);
    }
    public void OnEndDrag(PointerEventData eventData)
{
       dragging = 0;
}

}
