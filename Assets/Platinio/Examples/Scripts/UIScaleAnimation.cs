using Platinio.TweenEngine;
using UnityEngine;

namespace Platinio
{
    public class UIScaleAnimation : UIAnimation
    {
        [SerializeField] private Vector3 targetScale = Vector3.zero;

        public override BaseTween Play()
        {
            return gameObject.ScaleTween(targetScale , time).SetEase(ease);
        }
    }
}

