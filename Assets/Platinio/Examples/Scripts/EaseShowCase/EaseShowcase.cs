using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platinio.TweenEngine
{
    public class EaseShowcase : MonoBehaviour
    {
        [SerializeField] private Ease ease;
        [SerializeField] private float time;
        [SerializeField] private Vector3 pos;

        private Vector3 startPosition = Vector3.zero;

        private void Start()
        {
            startPosition = transform.position;
            Move();
        }
        private void Move()
        {
            transform.position = startPosition;
            transform.Move(pos, time).SetEase(ease).SetOnComplete(Move);
        }
       
    }

}

