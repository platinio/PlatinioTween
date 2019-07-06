using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platinio.TweenEngine;

namespace Platinio
{
    public class PivotMovement : MonoBehaviour
    {
        [SerializeField] private Vector2 finalPos = Vector2.zero;
        [SerializeField] private PivotPreset anchor = PivotPreset.MiddleCenter;
        [SerializeField] private RectTransform canvas = null;
        

        private void Start()
        {
            PlatinioTween.instance.MoveUI(GetComponent<RectTransform>() , finalPos, canvas , 0.5f , anchor);
        }
      
    }

}
