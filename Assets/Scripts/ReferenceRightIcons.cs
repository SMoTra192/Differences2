using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ReferenceRightIcons : MonoBehaviour
{
    [SerializeField] private GameObject parentImage1, parentImage2, parentRightIcons,parentHints,parentHints2;
    [SerializeField] private GameObject prefabRightIcon,prefabHints;
    [SerializeField] private Button _buttonhint;
    public static int index;
    private int rndIndex;
    private void Awake()
    {
        _buttonhint.onClick.AddListener(CheckHint);
        _buttonhint.onClick.AddListener(CheckHint2);
        int Childs = parentImage1.transform.childCount;
        for (int i = 0; i < Childs; i++)
        {
            Transform child = parentImage1.transform.GetChild(i);
            Transform child2 = parentImage2.transform.GetChild(i);
            //Vector3 positionChild = child.transform.position - new Vector3(0,2.55f,0);
            Vector3 normalScale = new Vector3(1, 1, 1);
            GameObject childIcon = Instantiate(prefabRightIcon, parentRightIcons.transform.position, quaternion.identity);
            //childIcon.transform.position = new Vector3(transform.position.x,transform.position.y,0);
            childIcon.transform.SetParent(parentRightIcons.transform);
            childIcon.transform.localScale = normalScale;
            GameObject hints = Instantiate(prefabHints, child.transform.position, quaternion.identity);
            hints.transform.SetParent(parentHints.transform);
            hints.transform.localScale = normalScale;
            GameObject hints2 = Instantiate(prefabHints, child2.transform.position, quaternion.identity);
            hints2.transform.SetParent(parentHints2.transform);
            hints2.transform.localScale = normalScale;

        }

        FindObjectOfType<ReferenceIdentification>().ReferenceTouched.AddListener(() =>
        {
           //print(index);
            Transform child = parentImage1.transform.GetChild(index);
            child.transform.Find("Button").gameObject.SetActive(false);
            child.transform.Find("RefCircle").gameObject.SetActive(true);
            Transform child2 = parentImage2.transform.GetChild(index);
            child2.transform.Find("Button").gameObject.SetActive(false);
            child2.transform.Find("RefCircle").gameObject.SetActive(true);
            Transform hint = parentHints.transform.GetChild(index);
            Transform hint2 = hint.transform.Find("Hint");
            if(hint2 != null) Destroy(hint2.gameObject);
            
            Transform hint3 = parentHints.transform.GetChild(index);
            Transform hint4 = hint3.transform.Find("Hint");
            if(hint4 != null) Destroy(hint4.gameObject);
            
        });
        
        FindObjectOfType<ReferenceIdentification>().ReferenceTouched.AddListener(() =>
        {
            for (int i = 0; i < parentHints.transform.childCount ; i++)
            {
                Transform hint = parentHints.transform.GetChild(i);
                Transform hint2;
                if (hint.transform.childCount > 0)
                {
                    hint2 = hint.transform.GetChild(0);
                    if(hint2.gameObject.activeInHierarchy) Destroy(hint2.gameObject);
                }
                
               
            }
            for (int i = 0; i < parentHints2.transform.childCount ; i++)
            {
                Transform hint = parentHints2.transform.GetChild(i);
                Transform hint2;
                if (hint.transform.childCount > 0)
                {
                    hint2 = hint.transform.GetChild(0);
                    if(hint2.gameObject.activeInHierarchy) Destroy(hint2.gameObject);
                }
                
               
            }
        });
    }

    

    public void CheckHint()
    {
        
        rndIndex= Random.Range(0, parentHints.transform.childCount);
        if (parentHints.transform.childCount > 0)
        {
            Transform hint = parentHints.transform.GetChild(rndIndex);
            Transform hint2 = hint.gameObject.transform.Find("Hint");
            if (hint2 == null) CheckHint();
            else
            {
                if (hint2.gameObject.activeInHierarchy) CheckHint();
                else
                {
                    hint2.gameObject.SetActive(true);
                }
            }
            
        }
        
        
        
    }

    public void CheckHint2()
    {
        if (parentHints2.transform.childCount > 0)
        {
            Transform hint = parentHints2.transform.GetChild(rndIndex);
            Transform hint2 = hint.gameObject.transform.Find("Hint");
            if (hint2 == null) CheckHint2();
            else
            {
                if (hint2.gameObject.activeInHierarchy) CheckHint2();
                else
                {
                    hint2.gameObject.SetActive(true);
                }
            }
            
        }
    }

    
}
