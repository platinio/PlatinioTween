using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Platinio.TweenEngine;

namespace Demo
{
    public class ColorTweenExample : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private Color m_selectColor = Color.black;
        [SerializeField] private Color m_normalColor = Color.black;
        [SerializeField] private float m_time = 0.0f;

        private Image m_image = null;
        private int m_tweenID = -1;

        private void Awake()
        {
            m_image = GetComponent<Image>();
            m_image.color = m_normalColor;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if(m_tweenID != -1)
                PlatinioTween.instance.CancelTween(m_tweenID);

            m_tweenID = PlatinioTween.instance.ColorTween(m_image.color , m_selectColor , m_time).SetOnUpdate(delegate(Color c) { m_image.color = c; }).id;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (m_tweenID != -1)
                PlatinioTween.instance.CancelTween(m_tweenID);

            m_tweenID = PlatinioTween.instance.ColorTween(m_image.color, m_normalColor, m_time).SetOnUpdate(delegate (Color c) { m_image.color = c; }).id;
        }
    }

}

