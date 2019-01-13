using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platinio.TweenEngine;

namespace Platinio
{
    public class Banner : MonoBehaviour
    {
        [SerializeField] private float m_rotAmount = 360.0f;
        [SerializeField] private float m_time = 2.0f;
        [SerializeField] private Ease m_ease = Ease.EaseInBack;

        private bool m_isBusy = false;
        

        public void Rotate()
        {
            if(m_isBusy)
                return;

            m_isBusy = true;

            PlatinioTween.instance.RotateTween(transform, Vector3.forward , transform.rotation.eulerAngles.z + m_rotAmount, m_time).SetEase(m_ease).SetOnComplete(delegate
            {
                m_isBusy = false;                
            });

        }

    }

}

