using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TotalLevels : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private void Update()
    {
        _text.text = $"{PlayerPrefs.GetInt("LevelValue") - 2} / {SceneManager.sceneCountInBuildSettings - 2}";
    }
}
