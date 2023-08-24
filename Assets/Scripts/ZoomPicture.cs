using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ZoomPicture : MonoBehaviour 

{
    private float _value;
    private Vector3 _scale;
    [SerializeField] private GameObject _firstImage,_secondImage;
        
    Vector3 touchStart;
    public float zoomOutMin = 1;
    public float zoomOutMax = 8;
	
    // Update is called once per frame
    void Update () {
        if(Input.GetMouseButtonDown(0)){
            touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if(Input.touchCount == 2){
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;

            zoom(difference * 0.01f);
        }else if(Input.GetMouseButton(0)){
            Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _firstImage.transform.position += direction * 0.01f;
            _secondImage.transform.position += direction * 0.01f;
        }
        zoom(Input.GetAxis("Mouse ScrollWheel"));
    }

    void zoom(float increment){
        _value = Mathf.Clamp(_value + increment, zoomOutMin, zoomOutMax);
        _firstImage.transform.localScale = new Vector3(_value, _value, _value);
        _secondImage.transform.localScale = new Vector3(_value, _value, _value);
    }

    
}