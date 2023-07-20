using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuPictureButton : MonoBehaviour
{
    private Button _button;
    [SerializeField] private GameObject completedImage, unCompletedImage,lockImage;
    //[SerializeField] private TextMeshProUGUI _textMeshProUGUI;
    private void Awake()
    {
        _button = gameObject.GetComponent<Button>();
        //_textMeshProUGUI.GetComponent<TextMeshProUGUI>();
        //_textMeshProUGUI.text = $"{(gameObject.transform.GetSiblingIndex()) + 1}";
    }

    private void Update()
    {
        int buttonIndex = gameObject.transform.GetSiblingIndex() + 2;
        //print($"ButtonIndex{buttonIndex}");
        int completeValueInt = PlayerPrefs.GetInt("LevelValue");
        //print($"CompleteValueIndex{completeValueInt}");
        if (buttonIndex < completeValueInt)
        {
            unCompletedImage.SetActive(false);
            completedImage.SetActive(true);
        }
        if (buttonIndex == completeValueInt)
        {
            unCompletedImage.SetActive(true);
        }
        if (buttonIndex > completeValueInt) lockImage.SetActive(true);
    }
}
