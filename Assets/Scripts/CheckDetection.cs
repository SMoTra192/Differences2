using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CheckDetection : MonoBehaviour
{
    private int index;
    private Transform check;
    
    private void Awake()
    {
        index = 0;
        FindObjectOfType<ReferenceIdentification>().ReferenceTouched.AddListener(() =>
        {
            if (index < gameObject.transform.childCount)
            {
                check = gameObject.transform.GetChild(index);
                gameObject.transform.GetChild(index);
                
                index++;
                
            }
        });
        
    }

    public void checkDetect()
    {
        check.gameObject.transform.Find("Check").gameObject.SetActive(true);
        check.gameObject.transform.Find("Cross").gameObject.SetActive(false);
    }

    public int WinningPoints()
    {
        return index;
    }

    public int PointsToWin()
    {
        return gameObject.transform.childCount;
    }

    

    
}
