using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zoom : MonoBehaviour
{
    Vector3 touchStart;
    public float maxZoom;
    public float minZoom;
    public float sensitivity;
    [SerializeField] private Image _picture1,_picture2;
    [SerializeField] private GameObject _picture1Parent, _picture2Parent;
    private Vector3 startPosPic1, startPosPic2,startpointForPic1,startPointForPic2;
    [SerializeField] private float xMin1, xMax1, yMin1, yMax1,xMin2, xMax2, yMin2, yMax2;
    private float scalingMax, scalingMin;
    [SerializeField] private Camera _camera;
    private void Awake()
    {
        
        startpointForPic1 = _picture1Parent.transform.position;
        xMin1 += startpointForPic1.x;
        xMax1 += startpointForPic1.x;
        yMin1 += startpointForPic1.y;
       yMax1 += startpointForPic1.y;
        startPointForPic2 = _picture2Parent.transform.position;
        xMin2 += startPointForPic2.x;
        xMax2 += startPointForPic2.x;
       yMin2 += startPointForPic2.y;
        yMax2 += startPointForPic2.y;
        scalingMax = xMax1;
        scalingMin = startpointForPic1.x;
    }

    private void Start()
    {
        
    }

    public void Update()
    {
        gameObject.transform.position = new Vector3(transform.position.x,transform.position.y,100);
        if (Input.GetMouseButtonDown(0))
        {
            touchStart = _camera.ScreenToWorldPoint(Input.mousePosition);
            startPosPic1 = _picture1Parent.transform.position;
            startPosPic2 = _picture2Parent.transform.position;
        }
        
        else if (Input.GetMouseButton(0))
        {
            //ZoomEnds(Input.GetAxis("Mouse ScrollWheel"));
            Vector3 normalScale = new Vector3(1, 1, 1);
            //if (_picture1Parent.transform.localScale != normalScale && _picture2Parent.transform.localScale != normalScale)
            {
                Vector3 direction = (touchStart - _camera.ScreenToWorldPoint(Input.mousePosition)) * 1f;
                Vector3 picture1Pos = startPosPic1 - direction;
                Vector3 picture2Pos= startPosPic2 - direction;
                
                _picture1Parent.transform.position = picture1Pos;
                _picture2Parent.transform.position = picture2Pos;
                
                if (xMin1 > _picture1Parent.transform.position.x)
                    _picture1Parent.transform.position =  new Vector3(xMin1, _picture1Parent.transform.position.y, _picture1Parent.transform.position.z);
                
                if (xMax1 < _picture1Parent.transform.position.x)
                    _picture1Parent.transform.position =  new Vector3(xMax1, _picture1Parent.transform.position.y, _picture1Parent.transform.position.z);
                
                if (yMin1 > _picture1Parent.transform.position.y)
                    _picture1Parent.transform.position =  new Vector3(_picture1Parent.transform.position.x, yMin1, _picture1Parent.transform.position.z);
                
                if (yMax1 < _picture1Parent.transform.position.y)
                    _picture1Parent.transform.position =  new Vector3(_picture1Parent.transform.position.x, yMax1, _picture1Parent.transform.position.z);
                
                if (xMin2 > _picture2Parent.transform.position.x)
                    _picture2Parent.transform.position =  new Vector3(xMin2, _picture2Parent.transform.position.y, _picture2Parent.transform.position.z);
                
                if (xMax2 < _picture2Parent.transform.position.x)
                    _picture2Parent.transform.position =  new Vector3(xMax2, _picture2Parent.transform.position.y, _picture2Parent.transform.position.z);
                
                if (yMin2 > _picture2Parent.transform.position.y)
                    _picture2Parent.transform.position =  new Vector3(_picture2Parent.transform.position.x, yMin2, _picture2Parent.transform.position.z);
                
                if (yMax2 < _picture2Parent.transform.position.y)
                    _picture2Parent.transform.position =  new Vector3(_picture2Parent.transform.position.x, yMax2, _picture2Parent.transform.position.z);
                

                //print(_picture1Parent.transform.position.y);
                
            }
            
        }

    }

    void ZoomPicture(float increment)
    {
        float XandYScale = increment * sensitivity;
        Vector3 Scale = new Vector3(XandYScale, XandYScale, 0);
        //Vector3 localScaleX = _picture1Parent.transform.localScale;

        _picture2Parent.transform.localScale += Scale;
        _picture1Parent.transform.localScale += Scale;
        
        if (_picture1Parent.transform.localScale.x <minZoom && _picture2Parent.transform.localScale.x <minZoom  )
        {
            Vector3 permanentScale = new Vector3(minZoom, minZoom, 0);
            _picture2Parent.transform.localScale = permanentScale;
            _picture1Parent.transform.localScale = permanentScale;
        }
        if (_picture1Parent.transform.localScale.x >maxZoom && _picture2Parent.transform.localScale.x >maxZoom  )
        {
            Vector3 permanentScale = new Vector3(maxZoom, maxZoom, 0);
            _picture2Parent.transform.localScale = permanentScale;
            _picture1Parent.transform.localScale = permanentScale;
        }
    }

    void ZoomEnds(float increment)
    {
        float Scale = increment * sensitivity;
        //if (scalingMax < 0.1f) xMax1 = xMax2 = yMax1 = yMax2 = 0.1f;
        //if (scalingMax > 1f) xMax1 = xMax2 = yMax1 = yMax2 = 1f;
        //if (scalingMin > -0.1f) xMin1 = xMin2 = yMin1 = yMin2 = -0.1f;
        //if (scalingMin < -1f) xMin1 = xMin2 = yMin1 = yMin2 = -1f;
        xMin1 += Scale;  
        xMin2+= Scale;
        xMax1+= Scale;
        xMax2+= Scale;
        yMin1+= Scale;
        yMax1+= Scale;
        yMin2+= Scale;
        yMax2+= Scale;
    }
    
}
