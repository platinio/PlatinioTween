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

            thisImage.ColorTween(highlightColor, time);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            CancelTween();
            thisImage.ColorTween(originalColor, time);
        }

        private void CancelTween()
        {
            gameObject.CancelAllTweens();
        }
    }

}

