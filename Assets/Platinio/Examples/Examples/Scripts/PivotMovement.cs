using UnityEngine;
using Platinio.TweenEngine;

namespace Platinio
{
    public class PivotMovement : MonoBehaviour
    {
        [SerializeField] private Vector2 finalPos = Vector2.zero;
        [SerializeField] private PivotPreset anchor = PivotPreset.UpperRight;
        [SerializeField] private RectTransform canvas = null;

        private RectTransform thisRectTransform = null;
        private Vector2 startPosition = Vector2.zero;

        private void Start()
        {            
            thisRectTransform = GetComponent<RectTransform>();
            startPosition = thisRectTransform.anchoredPosition;

            Move();
        }

        private void Move()
        {
            thisRectTransform.anchoredPosition = startPosition;
            PlatinioTween.instance.MoveUI( thisRectTransform, finalPos, canvas, 0.5f, anchor ).SetOnComplete(Move).SetDelay(1.0f);
        }
      
    }

}
