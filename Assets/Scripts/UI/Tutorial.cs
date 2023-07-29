using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    void Start()
    {
        if (PlayerPrefs.GetInt("Tutorial") == 0)
        {
            gameObject.SetActive(false);
        }
        if (PlayerPrefs.GetInt("Tutorial") == 1)
        {
            print(PlayerPrefs.GetInt("Tutorial"));
            PlayerPrefs.SetInt("Tutorial",0);
            print(PlayerPrefs.GetInt("Tutorial"));
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
