using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Platinio.TweenEngine;

namespace Demo
{
    public class ImageColorTweenExample : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {

        [SerializeField] private Color m_selectColor = Color.black;
        [SerializeField] private Color m_normalColor = Color.black;
        [SerializeField] private float m_time = 0.0f;

        private Image m_image = null;

        private void Awake()
        {
            m_image = GetComponent<Image>();
            m_image.color = m_normalColor;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            PlatinioTween.instance.ColorTween(m_image , m_selectColor, m_time);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            PlatinioTween.instance.ColorTween(m_image, m_normalColor, m_time);
        }

    }

}

