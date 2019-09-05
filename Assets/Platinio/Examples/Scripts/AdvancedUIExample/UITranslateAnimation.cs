using Platinio.TweenEngine;
using UnityEngine;

namespace Platinio
{
    public class UITranslateAnimation : UIAnimation
    {
        [SerializeField] private Vector2 translation = Vector2.zero;
        [SerializeField] private RectTransform canvas = null;

        public override BaseTween Play()
        {
            return GetComponent<RectTransform>().TranslateUI(translation , canvas , time).SetEase(ease);
        }
    }
}

