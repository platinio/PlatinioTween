using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platinio.TweenEngine;

namespace Platinio
{
    public class Banner : MonoBehaviour
    {
        [SerializeField] private float rotAmount = 360.0f;
        [SerializeField] private float time = 2.0f;
        [SerializeField] private Ease ease = Ease.EaseInBack;

        private bool isBusy = false;
        

        public void Rotate()
        {
            if(isBusy)
                return;

            isBusy = true;

            PlatinioTween.instance.RotateTween(transform, Vector3.forward , transform.rotation.eulerAngles.z + rotAmount, time).SetEase(ease).SetOnComplete(delegate
            {
                isBusy = false;                
            });

        }

    }

}

