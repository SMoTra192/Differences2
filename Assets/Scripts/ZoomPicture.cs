using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ZoomPicture : MonoBehaviour 

{
    [SerializeField] private GameObject obj,obj2;
    [SerializeField] private float minZoom=1, maxZoom=5;
    private Vector3 VminZoom, VmaxZoom;
    public float sensitivity;
    private Vector3 _scale;
    Vector2 f0start;
    Vector2 f1start;
    private Vector2 f0PrevPos, f1PrevPos;

    private void Awake()
    {
        VminZoom = new Vector3(minZoom, minZoom, minZoom);
        VmaxZoom = new Vector3(maxZoom, maxZoom, maxZoom);
    }

    void Update()

    {

        if (Input.touchCount < 2)

        {

            f0start = Vector2.zero;

            f1start = Vector2.zero;

        }
        if (Input.touchCount == 2) Zoom();

    }

    public void Zoom()

    {

        if (f0start == Vector2.zero && f1start == Vector2.zero)

        {

            f0start = Input.GetTouch(0).position;

            f1start = Input.GetTouch(1).position;

        }

        Vector2 f0position = Input.GetTouch(0).position;
//print(f0position);
        Vector2 f1position = Input.GetTouch(1).position;
//print(f1position);
        float dir = Mathf.Sign(Vector2.Distance(f1start, f0start) - Vector2.Distance(f0position, f1position));
        //float zoom = f0start.x / f0position.x;
        //transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.forward, dir * sensitivity * Time.deltaTime * Vector3.Distance(f0position, f1position));
        //float XandYScale = zoom * sensitivity;
        float XandYScale = dir * sensitivity * Time.deltaTime * Vector3.Distance(f0position, f1position);
        //print(XandYScale);
        Vector3 Scale = new Vector3(XandYScale , XandYScale, 0);
        _scale = Scale;   
        print(_scale);
        if(f0PrevPos != f0position)obj.transform.localScale -= _scale;
        if(f0PrevPos != f0position)obj2.transform.localScale -= _scale;
        
        f0PrevPos = f0position;
        f1PrevPos = f1position;
        
        if (obj.transform.localScale.x < VminZoom.x) obj.transform.localScale = VminZoom;
        if (obj.transform.localScale.x > VmaxZoom.x) obj.transform.localScale = VmaxZoom;
        
        
        if (obj2.transform.localScale.x < VminZoom.x) obj2.transform.localScale = VminZoom;
        if (obj2.transform.localScale.x > VmaxZoom.x) obj2.transform.localScale = VmaxZoom;
        
    }

    
}