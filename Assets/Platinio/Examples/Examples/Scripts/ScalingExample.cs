using UnityEngine;
using Platinio.TweenEngine;

namespace Demo
{
    public class ScalingExample : MonoBehaviour
    {
        [SerializeField] private GameObject go = null;

        private float targetScale = 0.0f;


        private void Awake()
        {
            Scale();
        }

        private void Scale()
        {
            float t = 1.5f;

            targetScale += 5.0f;

            if (targetScale > 40.0f)
            {
                t = 5.0f;
                targetScale = 5.0f;
            }
                

            go.ScaleTween( Vector3.one * targetScale, t ).SetEase( Ease.EaseOutElastic ).SetDelay( 0.2f ).SetOnComplete(Scale);            
        }
    }

}

