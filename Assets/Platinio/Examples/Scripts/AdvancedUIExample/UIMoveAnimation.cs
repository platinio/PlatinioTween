using Platinio.TweenEngine;
using UnityEngine;

namespace Platinio
{
    public class UIMoveAnimation : UIAnimation
    {
        [SerializeField] private Vector2 targetPosition = Vector2.zero;
        [SerializeField] private RectTransform canvas = null;


        public override BaseTween Play()
        {
            return GetComponent<RectTransform>().MoveUI(targetPosition , canvas , time).SetEase(ease);
        }
    }

}

