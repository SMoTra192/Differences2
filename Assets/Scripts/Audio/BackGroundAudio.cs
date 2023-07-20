using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundAudio : MonoBehaviour
{
    [SerializeField] private string tag;
    
    
       private void Awake()
       {
          GameObject obj = GameObject.FindWithTag(tag);
          if (obj != null) Destroy(this.gameObject);
          else
          {
             this.gameObject.tag = tag;
             DontDestroyOnLoad(gameObject);
          }
       }
}
