using UnityEngine;
using Platinio.TweenEngine;

namespace Demo
{
    public class RotationExample : MonoBehaviour
    {
        private float currentAngle = 0.0f;

        private void Awake()
        {
            Rotate();
        }

        private void Rotate()
        {
            currentAngle += 90.0f;

            if (currentAngle > 360.0f)
                currentAngle = 0.0f;

            transform.RotateTween( Vector3.forward, currentAngle , 2.0f ).SetEase( Ease.EaseOutElastic ).SetDelay( 1.0f ).SetOnComplete(Rotate);
        }
    }

}

