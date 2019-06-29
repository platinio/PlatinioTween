using UnityEngine;
using Platinio.TweenEngine;

namespace Platinio
{
    public class Popup : MonoBehaviour
    {
        [SerializeField] private Vector2 m_startPosition = Vector2.zero;
        [SerializeField] private Vector2 m_desirePosition = Vector2.zero;
        [SerializeField] private RectTransform m_canvas = null;
        [SerializeField] private float m_height = 0.5f;
        [SerializeField] private float m_time = 0.5f;
        [SerializeField] private Ease m_enterEase = Ease.EaseInOutExpo;
        [SerializeField] private Ease m_exitEase = Ease.EaseInOutExpo;

        private bool m_isVisible    = false;
        private bool m_isBusy       = false;       
        private RectTransform m_thisRect = null;

        private void Start()
        {
            m_thisRect = GetComponent<RectTransform>();   
            
            m_thisRect.anchoredPosition = PlatinioTween.FromAbsolutePositionToCanvasPosition(m_startPosition , m_thisRect , m_canvas);
        }

        private void Show()
        {
            PlatinioTween.instance.MoveUI(m_thisRect, m_desirePosition, m_canvas, m_time).SetEase(m_enterEase).SetOnComplete(delegate
            {
                m_isBusy = false;
                m_isVisible = true;
            });
            
        }

        private void Hide()
        {
            PlatinioTween.instance.MoveUI(m_thisRect, m_startPosition, m_canvas, m_time).SetEase(m_exitEase).SetOnComplete(delegate
            {
                m_isBusy = false;
                m_isVisible = false;
            });
        }

        public void Toggle()
        {
            if (m_isBusy)
                return;

            m_isBusy = true;

            if (m_isVisible)
                Hide();
            else
                Show();
        }
    }

}

