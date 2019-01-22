using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platinio.TweenEngine;

public class ScaleTest : MonoBehaviour
{

    private void Awake()
    {
        PlatinioTween.instance.ScaleTween(transform , Vector3.one * 20.0f , 20.0f).SetOwner(gameObject);
        PlatinioTween.instance.ColorTween(GetComponent<SpriteRenderer>() , Color.red , 20.0f).SetOwner(gameObject);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            PlatinioTween.instance.CancelTween(gameObject);
    }

}
