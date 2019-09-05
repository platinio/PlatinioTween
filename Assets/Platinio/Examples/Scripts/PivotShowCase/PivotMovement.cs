using UnityEngine;
using Platinio.TweenEngine;
using Platinio.UI;
using System.Collections;

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

            StartCoroutine( MoveRoutine() );
        }

        
        private IEnumerator MoveRoutine()
        {
            while (true)
            {
                thisRectTransform.anchoredPosition = startPosition;
                thisRectTransform.MoveUI( finalPos, canvas, 0.5f, anchor );

                yield return new WaitForSeconds(2.0f);
            }            
        }
        

    }

}
