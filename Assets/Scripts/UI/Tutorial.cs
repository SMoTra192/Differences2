using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    
    [SerializeField] private GameObject tutorialObj,obj2,tutorialObj2;
    private bool isSecReady = false;
    void Start()
    {
        if (PlayerPrefs.GetInt("Tutorial") == 0)
        {
            gameObject.SetActive(false);
        }
        FindObjectOfType<ReferenceIdentification>().ReferenceTouched.AddListener(() =>
        {
            if (PlayerPrefs.GetInt("Tutorial") == 1)
            {
                PlayerPrefs.SetInt("Tutorial",0);
                tutorialObj.SetActive(false);
                obj2.SetActive(false);
                tutorialObj2.SetActive(true);
                isSecReady = true;
            }
            
        });
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 2) tutorialObj2.SetActive(false);
    }

    
}
