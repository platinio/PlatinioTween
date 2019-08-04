using UnityEngine;
using UnityEngine.EventSystems;
using Platinio.TweenEngine;

namespace Demo
{
    public class SpriteColorTweenExample : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {

        [SerializeField] private Color m_selectColor = Color.black;
        [SerializeField] private Color m_normalColor = Color.black;
        [SerializeField] private float m_time = 0.0f;

        private SpriteRenderer m_sprite = null;
        private int m_tweenID = -1;

        private void Awake()
        {
            m_sprite = GetComponent<SpriteRenderer>();
            m_sprite.color = m_normalColor;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (m_tweenID != -1)
                PlatinioTween.instance.CancelTween(m_tweenID);

             m_tweenID = PlatinioTween.instance.ColorTween(m_sprite, m_selectColor, m_time).ID;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (m_tweenID != -1)
                PlatinioTween.instance.CancelTween(m_tweenID);

            m_tweenID = PlatinioTween.instance.ColorTween(m_sprite, m_normalColor, m_time).ID;
        }
    }

}

