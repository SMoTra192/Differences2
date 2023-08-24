using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PointDetect : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IPointerMoveHandler
{
    private Button _button;
    private Vector2 pointPosition;
    public UnityEvent ImageClicked = new();
    [SerializeField] private Camera _camera;
    [SerializeField] private RectTransform _canvas;
    private float _timer = 0f, starttimer;
    private bool isTouched = false;
    private bool isDowned = false;

    private void Awake()
    {
        starttimer = _timer;
        _button = GetComponent<Button>();

    }

    public Vector2 PointPosition()
    {
        return pointPosition;
    }

    public void OnMouseDown()
    {
        //print(isDowned);
        //isDowned = true;
        // print(isDowned);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!isTouched && Input.touchCount != 2)
        {
            FindObjectOfType<TakeTime>().timeDown.Invoke();
            RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvas, Input.mousePosition, _camera,
                out pointPosition
            );
            ImageClicked.Invoke();

        }

        if (isDowned) isDowned = false;
        if (isTouched)
        {
            isTouched = false;

        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isDowned = true;
        //print("Downed");
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        if (isDowned)
        {
            //print("moved");
            //FindObjectOfType<ZoomPicture>().Zoom();
            isTouched = true;
        }


    }


}
