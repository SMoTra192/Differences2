    using System;
    using System.Collections;
using System.Collections.Generic;
    using TMPro;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class TextOnImage : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    
    private void Update()
    {
        _text.text = $"lvl {gameObject.transform.GetSiblingIndex() + 1}";
    }
}
