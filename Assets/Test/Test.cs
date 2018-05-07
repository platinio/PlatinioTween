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
       
       PlatinioTween.instance.ScaleX(obj.transform , 10.0f , t);
       PlatinioTween.instance.ScaleY(obj , 20.0f , t);
              
    }

    
}
