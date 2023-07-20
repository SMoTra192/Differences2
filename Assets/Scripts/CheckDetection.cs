using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CheckDetection : MonoBehaviour
{
    private int index;
    //private int prop;
    private void Awake()
    {
        index = 0;
        Transform Check;
        
        FindObjectOfType<ReferenceIdentification>().ReferenceTouched.AddListener(() =>
        {
            if (index < gameObject.transform.childCount)
            {
                Check = gameObject.transform.GetChild(index);
                gameObject.transform.GetChild(index);
                Check.gameObject.transform.Find("Check").gameObject.SetActive(true);
                Check.gameObject.transform.Find("Cross").gameObject.SetActive(false);
                index++;
                
            }
        });
        
    }

    private void Update()
    {
        PointsToWin();
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
