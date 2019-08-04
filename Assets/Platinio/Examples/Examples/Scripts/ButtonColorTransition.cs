using UnityEngine;
using UnityEngine.EventSystems;
using Platinio.TweenEngine;
using UnityEngine.UI;

namespace Platinio
{
    public class ButtonColorTransition : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private Color highlightColor = Color.black;
        [SerializeField] private float time = 0.1f;

        private int tweenId = -1;
        private Color originalColor = Color.black;
        private Image thisImage = null;

        private void Awake()
        {
            thisImage = GetComponent<Image>();
            originalColor = thisImage.color;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            CancelTween();

            tweenId = PlatinioTween.instance.ColorTween(thisImage, highlightColor, time).ID;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            CancelTween();

            tweenId = PlatinioTween.instance.ColorTween(thisImage, originalColor, time).ID;
        }

        private void CancelTween()
        {
            if (tweenId != -1)
                PlatinioTween.instance.CancelTween(tweenId);
        }
    }

}

