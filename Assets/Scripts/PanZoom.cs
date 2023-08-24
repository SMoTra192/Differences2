using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanZoom : MonoBehaviour
{
    private Vector3 touchStart;
    [SerializeField] private Camera _camera1, _camera2;
    public float zoomOutMin = 1f;
    public float zoomOutMax = 3.1f;  



    [SerializeField] private SpriteRenderer _imageRenderer,_imageRenderer2;
    private float minX, maxX, minY, maxY;
    private float minX2, maxX2, minY2, maxY2;


    private Vector3 startPos1, startPos2;
    private void Awake()
    {
        minX = _imageRenderer.transform.position.x - _imageRenderer.bounds.size.x/2;
        maxX = _imageRenderer.transform.position.x + _imageRenderer.bounds.size.x/2;
        
        minY = _imageRenderer.transform.position.y - _imageRenderer.bounds.size.y/2;
        maxY = _imageRenderer.transform.position.y + _imageRenderer.bounds.size.y/2;
        
        minX2 = _imageRenderer2.transform.position.x - _imageRenderer2.bounds.size.x/2;
        maxX2 = _imageRenderer2.transform.position.x + _imageRenderer2.bounds.size.x/2;
        
        minY2 = _imageRenderer2.transform.position.y - _imageRenderer2.bounds.size.y/2;
        maxY2 = _imageRenderer2.transform.position.y + _imageRenderer2.bounds.size.y/2;
        
        
    }

    private void Update()
    {
        panPicture();
        if (Input.touchCount == 2)
        {
            
                Touch touchZero = Input.GetTouch(0);
                Touch touchOne = Input.GetTouch(1);

                Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
                Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

                float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
                float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

                float difference = currentMagnitude - prevMagnitude;

                zoom(difference * 0.01f);
                
        }
        
        zoom(Input.GetAxis("Mouse ScrollWheel"));
        
    }

    private void panPicture()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            startPos1 = _camera1.transform.position;
            startPos2 = _camera2.transform.position;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 Difference = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 picture1Pos = startPos1 + Difference;
            Vector3 picture2Pos = startPos2 + Difference;
            _camera1.transform.position = ClampCamera(picture1Pos);
            _camera2.transform.position = ClampCamera2(picture2Pos);
            
            print(_camera1.orthographicSize);
            print(_camera1.aspect);
            
        }

        ;
        
    }
    void zoom(float increment){
        _camera1.orthographicSize = Mathf.Clamp(_camera1.orthographicSize - increment, zoomOutMin, zoomOutMax);
        _camera1.transform.position = ClampCamera(_camera1.transform.position);
        _camera2.orthographicSize = Mathf.Clamp(_camera2.orthographicSize - increment, zoomOutMin, zoomOutMax);
        _camera2.transform.position = ClampCamera2(_camera2.transform.position);
        
    }

    private Vector3 ClampCamera(Vector3 targetPos)
    {
        float camHeight = _camera1.orthographicSize;
        float camWidth = _camera1.orthographicSize * _camera1.aspect;
        float minX = this.minX + camWidth;
        float maxX = this.maxX - camWidth;
        float minY = this.minY + camHeight;
        float maxY = this.maxY - camHeight;

        float newX = Mathf.Clamp(targetPos.x, minX, maxX);
        float newY = Mathf.Clamp(targetPos.y, minY, maxY);

        return new Vector3(newX, newY, targetPos.z);

    }
    private Vector3 ClampCamera2(Vector3 targetPos)
    {
        float camHeight = _camera2.orthographicSize;
        float camWidth = _camera2.orthographicSize * _camera2.aspect;
        
        float minX = this.minX2 + camWidth;
        float maxX = this.maxX2 - camWidth;
        float minY = this.minY2 + camHeight;
        float maxY = this.maxY2 - camHeight;

        float newX = Mathf.Clamp(targetPos.x, minX, maxX);
        float newY = Mathf.Clamp(targetPos.y, minY, maxY);

        return new Vector3(newX, newY, targetPos.z);

    }
}
