using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platinio.TweenEngine;
using UnityEngine.UI;


public class Test : MonoBehaviour
{
    public Vector2 dest = Vector2.zero;

    private void Start()
    {
        PlatinioTween.instance.MoveUI(GetComponent<RectTransform>() , dest , FindObjectOfType<Canvas>().GetComponent<RectTransform>() , 2.0f ).SetEvent(delegate { Debug.Log("2"); } , 0.2f).SetEvent(delegate { Debug.Log("3"); } , 0.5f).SetEvent(delegate { Debug.Log("1"); } , 0.1f);
    }
}
