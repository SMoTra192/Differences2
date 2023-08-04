using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomAbility : MonoBehaviour
{
    Vector3 touchStart;
    public float zoomOutMin = 1;
    public float zoomOutMax = 8;

    [SerializeField] private RectTransform _firstImage, _secondImage;
    private float _value;
    private Vector3 _scale;


    private Vector3 startPosPic1, startPosPic2;
    
    
[SerializeField] float leftLimit=-1,rightLimit = 1;
private Vector3[] _vector3 = new Vector3[4];
float topLimit ,bottomLimit,topLimit2,bottomLimit2;
    private void Awake()
    {
        _value = _firstImage.transform.localScale.x;
        topLimit = _firstImage.position.y + 1;
        bottomLimit = _firstImage.position.y - 1;
        topLimit2 = _secondImage.position.y + 1;
        bottomLimit2 = _secondImage.position.y - 1;
    }

    // Update is called once per frame
    void Update () {
        if(Input.GetMouseButtonDown(0)){
            touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            startPosPic1 = _firstImage.transform.position;
            startPosPic2 = _secondImage.transform.position;
        }
        if(Input.touchCount == 2)
        {
            
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
            Camera.main.transform.position += direction;
            
            
            Vector3 picture1Pos = startPosPic1 - direction;
            Vector3 picture2Pos= startPosPic2 - direction;
                
            
            _firstImage.position = new Vector3(Mathf.Clamp(picture1Pos.x, leftLimit, rightLimit),
               Mathf.Clamp(picture1Pos.y, bottomLimit, topLimit), transform.position.z);
            _secondImage.position = new Vector3(Mathf.Clamp(picture2Pos.x, leftLimit, rightLimit),
               Mathf.Clamp(picture2Pos.y, bottomLimit2, topLimit2), transform.position.z);
            


        }
        zoom(Input.GetAxis("Mouse ScrollWheel"));
        
    }

    void zoom(float increment){
        _value = Mathf.Clamp(_value + increment, zoomOutMin, zoomOutMax);
        _firstImage.transform.localScale = new Vector3(_value, _value, _value);
        _secondImage.transform.localScale = new Vector3(_value, _value, _value);
        //Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, zoomOutMin, zoomOutMax);
    }
}
