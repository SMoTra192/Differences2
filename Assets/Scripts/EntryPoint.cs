using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private UIEndGame _endGame;
    [SerializeField] private CheckDetection _check;
    private float time,timeForGameOver,timerForFinishStart = 1f;
    private int _winningPoints, pointsToWin;
    public UnityEvent endGamed = new();
    public UnityEvent endGamedWithSuccess = new(),startEndGameEffect = new();
    private bool isEndGamedWithSuccess =false;
    private bool isFinished = false;
    [SerializeField] private GameObject _counter;
    [SerializeField] private GameObject iconsParent;
    [SerializeField] private AudioSource _sourceDiffIcons;
    void Start()
    {
        
        _timer.GetComponent<Timer>();
        _endGame.GetComponent<UIEndGame>();
        _check.GetComponent<CheckDetection>();
        endGamed.AddListener(endGameCanvas);
        
        
        pointsToWin = _check.PointsToWin();
//print(pointsToWin);
        FindObjectOfType<ReferenceIdentification>().ReferenceTouched.AddListener(() =>
        {
            _winningPoints = _check.WinningPoints();
            //print(_winningPoints);
        FindObjectOfType<CheckEffects>().endEffects.AddListener(()=> isEndGamedWithSuccess = true);        
            

        });
    }
    

    private void Update()
    {
        
        if (_winningPoints == pointsToWin)
        {
            timerForFinishStart -= Time.deltaTime;
        }
        
        if (_winningPoints == pointsToWin && timerForFinishStart < 0 && isFinished == false)
        {
           // print("sucC");
            _counter.SetActive(true);
            _sourceDiffIcons.Play();
            startEndGameEffect.Invoke();
            isFinished = true;
        }
        time = _timer.getTimeValue();
       //
       
             if (time < 1f ) endGamed?.Invoke();
             if (_winningPoints == pointsToWin && isEndGamedWithSuccess == true)
             {
                 //print("succ");
                 endGamedWithSuccess.Invoke();
             }   

    }

    private void endGameCanvas()
    {
        _endGame.ShowPanel();
        _endGame.HideObjects();
        _endGame.ShowParticles();
    }

    public void ExtraTimeCanvas()
    {
        _endGame.HidePanel();
        _endGame.HideParticles();
        _endGame.ShowObjects();
    }
    
    public bool IsFinished()
    {
        return isFinished;
    }
}