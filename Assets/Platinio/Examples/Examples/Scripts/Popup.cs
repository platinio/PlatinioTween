using UnityEngine;
using Platinio.TweenEngine;

namespace Platinio
{
    public class Popup : MonoBehaviour
    {
        [SerializeField] private Vector2 startPosition = Vector2.zero;
        [SerializeField] private Vector2 desirePosition = Vector2.zero;
        [SerializeField] private RectTransform canvas = null;
        [SerializeField] private float height = 0.5f;
        [SerializeField] private float time = 0.5f;
        [SerializeField] private Ease enterEase = Ease.EaseInOutExpo;
        [SerializeField] private Ease exitEase = Ease.EaseInOutExpo;

        private bool isVisible    = false;
        private bool isBusy       = false;       
        private RectTransform m_thisRect = null;

        private void Start()
        {
            m_thisRect = GetComponent<RectTransform>();   
            
            m_thisRect.anchoredPosition = m_thisRect.FromAbsolutePositionToAnchoredPosition(startPosition , canvas);
        }

        private void Show()
        {
            PlatinioTween.instance.MoveUI(m_thisRect, desirePosition, canvas, time).SetEase(enterEase).SetOnComplete(delegate
            {
                isBusy = false;
                isVisible = true;
            });
            
        }

        private void Hide()
        {
            PlatinioTween.instance.MoveUI(m_thisRect, startPosition, canvas, time).SetEase(exitEase).SetOnComplete(delegate
            {
                isBusy = false;
                isVisible = false;
            });
        }

        public void Toggle()
        {
            if (isBusy)
                return;

            isBusy = true;

            if (isVisible)
                Hide();
            else
                Show();
        }
    }

}

