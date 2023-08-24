using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Moving : MonoBehaviour , IDragHandler , IPointerDownHandler , IPointerUpHandler
{
    [SerializeField] private Transform knob;
    [SerializeField] private Vector2 start;
    [SerializeField] private Vector2 current;
    [SerializeField] private float maxAmplitude = 100;
    private Vector3 touchStart;
    private void Awake()
    {
        start = transform.position;
    }

    public Vector2 Direction ()
    {
        return (current - start) / maxAmplitude;
    }
    

    public void OnDrag(PointerEventData eventData)
    {
        var distance = Vector2.Distance(start, eventData.position);
        if (distance > maxAmplitude)
        {
            var delta = (eventData.position - start).normalized * maxAmplitude;
            eventData.position = start + delta;
        }

        knob.position = current = eventData.position;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        knob.position = current = start = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        knob.position = current = start;
    }
}
