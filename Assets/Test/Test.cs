using UnityEngine;
using Platinio.TweenEngine;
using System.Collections;

public class Test : MonoBehaviour
{
    
    public GameObject obj = null;

    public float t = 0.0f;
    public Transform to = null;

    int id  = 0;

    void Start()
    {
       
       PlatinioTween.instance.Move(obj.transform , to , 1.0f);
              
    }

    
}
