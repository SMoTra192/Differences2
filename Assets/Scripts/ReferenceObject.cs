using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;




public class ReferenceObject : MonoBehaviour
{
    private int index;
    

    public void ButtonClick()
    { 
        index = gameObject.transform.GetSiblingIndex();
        //ReferenceRightIcons.prevIndex = ReferenceRightIcons.index;
        ReferenceRightIcons.index = index;
        FindObjectOfType<ReferenceIdentification>().ReferenceTouched.Invoke();
    }

}
