using UnityEngine;
using Platinio.TweenEngine;

namespace Platinio
{
    public class GearMenu : MonoBehaviour
    {
        [SerializeField] private float m_height = 0.05f;
        [SerializeField] private float m_gearRotation = 180.0f;
        [SerializeField] private RectTransform m_canvas = null;
        [SerializeField] private RectTransform m_hideMenu = null;
        [SerializeField] private RectTransform m_gearIcon = null;
        [SerializeField] private float m_time = 1.0f;
        [SerializeField] private Ease m_ease = Ease.Linear;

        private Vector2 m_startPosition = Vector2.zero;
        private bool m_isVisible = false;
        private bool m_isBusy = false;

        private void Start()
        {
            m_startPosition = m_hideMenu.FromAnchoredPositionToAbsolutePosition(m_canvas);            
        }

        private void Show()
        {
            PlatinioTween.instance.MoveUI(m_hideMenu, new Vector2(m_startPosition.x, m_startPosition.y + m_height), m_canvas, m_time).SetEase(m_ease);
            PlatinioTween.instance.RotateTween(m_gearIcon , Vector3.forward , m_gearIcon.rotation.eulerAngles.z + m_gearRotation  , m_time).SetEase(m_ease).SetOnComplete(delegate 
            {
                m_isBusy = false;
                m_isVisible = true;
            });
        }

        private void Hide()
        {
            PlatinioTween.instance.MoveUI(m_hideMenu, m_startPosition, m_canvas, m_time).SetEase(m_ease);
            PlatinioTween.instance.RotateTween(m_gearIcon, Vector3.forward, m_gearIcon.rotation.eulerAngles.z - m_gearRotation, m_time).SetEase(m_ease).SetOnComplete(delegate
            {
                m_isBusy = false;
                m_isVisible = false;
            }); ;
        }

        public void Toggle()
        {
            if(m_isBusy)
                return;

            m_isBusy = true;

            if(m_isVisible)
                Hide();
            else
                Show();
        }

       
    }

}

