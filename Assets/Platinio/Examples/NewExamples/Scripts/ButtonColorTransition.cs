using UnityEngine;
using UnityEngine.EventSystems;
using Platinio.TweenEngine;
using UnityEngine.UI;

namespace Platinio
{
    public class ButtonColorTransition : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private Color m_highlightColor = Color.black;
        [SerializeField] private float m_time = 0.1f;

        private int m_tweenId = -1;
        private Color m_originalColor = Color.black;
        private Image m_thisImage = null;

        private void Awake()
        {
            m_thisImage = GetComponent<Image>();
            m_originalColor = m_thisImage.color;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            CancelTween();

            m_tweenId = PlatinioTween.instance.ColorTween(m_thisImage, m_highlightColor, m_time).id;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            CancelTween();

            m_tweenId = PlatinioTween.instance.ColorTween(m_thisImage, m_originalColor, m_time).id;
        }

        private void CancelTween()
        {
            if (m_tweenId != -1)
                PlatinioTween.instance.CancelTween(m_tweenId);
        }
    }

}

