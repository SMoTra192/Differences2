using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ZoomAbility : MonoBehaviour 
{
    Vector3 touchStart;
    public float zoomOutMin = 1;
    public float zoomOutMax = 2;

    [SerializeField] private Image _firstImage, _secondImage;

    private float _currentValue, _value;
    private Vector3 _scale;
    private float xPos, yPos, xPos2, yPos2;

    private Vector3 startPosPic1, startPosPic2;
    private bool isTouched = false;
    
    
    [SerializeField] private RectTransform _parent1, _parent2;


    private float minX, maxX, minY, maxY;
    private float minX2, maxX2, minY2, maxY2;
    
    
    
    
    
    
    
    
    private void Awake()
    {
        _value = zoomOutMax;
        
        minX = _parent1.transform.position.x - _firstImage.sprite.bounds.size.x/2;
        maxX = _parent1.transform.position.x + _firstImage.sprite.bounds.size.x/2;
        
        
        minY = _parent1.transform.position.y - _firstImage.sprite.bounds.size.y/2;
        maxY = _parent1.transform.position.y + _firstImage.sprite.bounds.size.y/2;
        
        
        
        minX2 = _parent2.transform.position.x - _secondImage.sprite.bounds.size.x/2;
        maxX2 = _parent2.transform.position.x + _secondImage.sprite.bounds.size.x/2;
        
        
        minY2 = _parent2.transform.position.y - _secondImage.sprite.bounds.size.y/2;
        maxY2 = _parent2.transform.position.y + _secondImage.sprite.bounds.size.y/2;
        






    }

    void Update()
    {
        PanPicture();
       


        
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

    private void PanPicture()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            startPosPic1 = _firstImage.transform.position;
            startPosPic2 = _secondImage.transform.position;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition); 
            
            Vector3 picture1Pos = startPosPic1 - direction;
            Vector3 picture2Pos = startPosPic2 - direction;
            
            _firstImage.transform.position = ClampImage(picture1Pos);
            _secondImage.transform.position = ClampImage2(picture2Pos);
            
        }
    }
        void zoom(float increment)
        {
            _currentValue = Mathf.Clamp(_currentValue + increment, zoomOutMin, zoomOutMax);
            _value = Mathf.Clamp(_value - increment, zoomOutMin, zoomOutMax);
            _firstImage.transform.localScale = new Vector3(_currentValue, _currentValue, _currentValue);
            _firstImage.transform.position = ClampImage(_firstImage.transform.position);
            _secondImage.transform.localScale = new Vector3(_currentValue, _currentValue, _currentValue);
            _secondImage.transform.position = ClampImage2(_secondImage.transform.position);
           
        }

        private Vector3 ClampImage(Vector3 targetPos)
        {
            float ImageHeight = _value;
            float ImageWidth = _value * (_firstImage.sprite.bounds.size.x/_firstImage.sprite.bounds.size.y);
            
            
            float minX = (this.minX + ImageWidth);
            float maxX = (this.maxX - ImageWidth);
            float minY = (this.minY + ImageHeight); 
            float maxY = (this.maxY - ImageHeight);

            float newX = Mathf.Clamp(targetPos.x, minX, maxX);
            float newY = Mathf.Clamp(targetPos.y, minY, maxY);

            return new Vector3(newX, newY, targetPos.z);
            
            
        }
        private Vector3 ClampImage2(Vector3 targetPos)
        {
            float ImageHeight = _value;
            float ImageWidth = _value * (_secondImage.sprite.bounds.size.x/_secondImage.sprite.bounds.size.y);
            
            
            float minX = (this.minX2 + ImageWidth);
            float maxX = (this.maxX2 - ImageWidth);
            float minY = (this.minY2 + ImageHeight); 
            float maxY = (this.maxY2- ImageHeight);

            float newX = Mathf.Clamp(targetPos.x, minX, maxX);
            float newY = Mathf.Clamp(targetPos.y, minY, maxY);

            return new Vector3(newX, newY, targetPos.z);
            
            
        }
}

