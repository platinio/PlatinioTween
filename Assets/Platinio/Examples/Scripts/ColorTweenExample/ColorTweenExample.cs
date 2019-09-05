using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Platinio.TweenEngine;

namespace Demo
{
    public class ColorTweenExample : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private Color selectColor = Color.black;
        [SerializeField] private Color normalColor = Color.black;
        [SerializeField] private float speed = 0.0f;
        [SerializeField] private Ease ease = Ease.EaseInBack;

        private Image image = null;        

        private void Awake()
        {
            image = GetComponent<Image>();
            image.color = normalColor;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            gameObject.CancelAllTweens();
            image.ColorTweenAtSpeed( selectColor , speed).SetEase(ease).SetOwner(gameObject);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            gameObject.CancelAllTweens();
            image.ColorTweenAtSpeed( normalColor, speed ).SetEase( ease ).SetOwner( gameObject );
        }
    }

}

