using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    [SerializeField] private Camera _camera1;
    [SerializeField] private RectTransform _canvas;
    [SerializeField] private Vector3 pointPosition;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           
            Ray ray = new Ray(_camera1.transform.position,_camera1.ScreenPointToRay(Input.mousePosition).direction);
            RaycastHit2D Hit =Physics2D.Raycast(ray.origin,ray.direction) ;
            
            
            

            Debug.DrawRay(_camera1.transform.position,pointPosition,
                Color.red,10);
            
            if (Hit.collider != null)
                {
                    print("GOOD");
                }
        }
    }
}
