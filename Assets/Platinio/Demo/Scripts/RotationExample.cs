using UnityEngine;
using Platinio.TweenEngine;

namespace Demo
{
    public class RotationExample : MonoBehaviour
    {
        private void Awake()
        {
            PlatinioTween.instance.RotateTween(transform , Vector3.forward , 90.0f , 3.0f).SetEase(Ease.EaseOutElastic).SetDelay(2.0f);
        }
    }

}

