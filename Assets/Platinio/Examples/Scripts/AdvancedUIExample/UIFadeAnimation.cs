using Platinio.TweenEngine;
using UnityEngine;

namespace Platinio
{
    public class UIFadeAnimation : UIAnimation
    {
        [SerializeField] private CanvasGroup cg = null;
        [SerializeField] private float targetAlpha = 0.0f;

        public override BaseTween Play()
        {
            return cg.Fade(targetAlpha , time).SetEase(ease);
        }
    }
}

