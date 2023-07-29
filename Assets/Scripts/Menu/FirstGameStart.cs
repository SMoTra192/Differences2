using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstGameStart : MonoBehaviour
{
    private string firstStart;
    private void Awake()
    {
        firstStart = "FirstStartGame";
        if (PlayerPrefs.GetInt(firstStart) == 0)
        {
            //PlayerPrefs.SetInt(UI.hint,2);
            PlayerPrefs.SetInt("Tutorial",1);
            PlayerPrefs.SetInt("LevelValue",2);
        }
        PlayerPrefs.SetInt(firstStart,1);
        
    }
    
}
