using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;




public class ReferenceObject : MonoBehaviour 
{
    private int index;
    private bool isDowned = false, isTouched = false;
    [SerializeField]private Button _button;
    
    private void Awake()
    { ;
        
        _button.onClick.AddListener(() =>
        {
            index = gameObject.transform.GetSiblingIndex();
            ReferenceGetRightIcons.index = index;

            if (!isTouched) FindObjectOfType<ReferenceIdentification>().ReferenceTouched.Invoke();
            else
            {
                
                isTouched = false;
            };
           // gameObject.SetActive(false);
        });
    }
    
    private void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch _touch = Input.GetTouch(0);
            if (_touch.phase == TouchPhase.Moved)
            {
                print("hello");
                isTouched = true;  
            }

            if (_touch.phase == TouchPhase.Ended)
            {
                isTouched = false;
            }
        }
    }
}
