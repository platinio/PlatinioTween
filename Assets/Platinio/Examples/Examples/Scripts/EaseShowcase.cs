using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platinio.TweenEngine
{
    public class EaseShowcase : MonoBehaviour
    {
        [SerializeField] private Ease ease;
        [SerializeField] private float t;
        [SerializeField] private Vector3 pos;

        private void Awake()
        {
            PlatinioTween.instance.Move(transform , pos , t).SetEase(ease);
        }
       
    }

}

