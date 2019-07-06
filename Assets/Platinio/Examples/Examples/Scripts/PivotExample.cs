using UnityEngine;
using Platinio.TweenEngine;

namespace Platinio
{

    public class PivotExample : MonoBehaviour
    {
        [SerializeField] private RectTransform containerRect = null;
        [SerializeField] private RectTransform hideMessageRect = null;
        [SerializeField] private RectTransform canvas = null;
        [SerializeField] private Ease ease = Ease.EaseInBack;
        [SerializeField] private float time;

        private float hideMessageWidth = 0.0f;
        private Vector2 startPosition = Vector2.zero;
        private bool isVisible = false;
        private bool isBusy = false;

        private void Start()
        {
            hideMessageWidth = hideMessageRect.FromRectSizeToAbsoluteSize(canvas).x;
            startPosition = containerRect.FromAnchoredPositionToAbsolutePosition(canvas , PivotPreset.MiddleLeft);

           
        }

        public void Toggle()
        {
            if (isVisible)
                Hide();
            else
                Show();
        }

        public void Show()
        {
            if (isVisible || isBusy)
                return;

            isBusy = true;

            PlatinioTween.instance.MoveUI( containerRect, startPosition + ( Vector2.right * hideMessageWidth ), canvas, time , PivotPreset.MiddleLeft).SetOnComplete(delegate 
            {
                isVisible = true;
                isBusy = false;
            } ).SetEase( ease );
        }

        public void Hide()
        {
            if (!isVisible || isBusy)
                return;

            isBusy = true;
                        
            PlatinioTween.instance.MoveUI( containerRect, startPosition , canvas, time , PivotPreset.MiddleLeft).SetOnComplete( delegate
            {
                isVisible = false;
                isBusy = false;
            } ).SetEase(ease);
        }

    }
}
