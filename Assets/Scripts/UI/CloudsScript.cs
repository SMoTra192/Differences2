using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CloudsScript : MonoBehaviour
{
    [SerializeField] private GameObject _cloudsOpen, _cloudsClose;
    [SerializeField] private float _secondsForWaitingSceneChange = 2f;
    
    public void NextLevelClouds()
    {
        StartCoroutine(waitNext());
        
    }
    public void AgainLevelClouds()
    {
        StartCoroutine(waitAgain());
    }
    public void MenuLevelClouds()
    {
        StartCoroutine(waitMenu());
    }

    IEnumerator waitMenu()
    {
        _cloudsClose.SetActive(true);
        yield return new WaitForSeconds(_secondsForWaitingSceneChange);
        SceneManager.LoadScene("Menu");
    }
   
    IEnumerator waitAgain()
    {
        _cloudsClose.SetActive(true);
        yield return new WaitForSeconds(_secondsForWaitingSceneChange);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    IEnumerator waitNext()
    {
        _cloudsClose.SetActive(true);
        yield return new WaitForSeconds(_secondsForWaitingSceneChange);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
