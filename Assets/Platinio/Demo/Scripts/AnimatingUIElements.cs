using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Platinio.TweenEngine;

namespace Demo
{
    public class AnimatingUIElements : MonoBehaviour
    {
        [SerializeField] private List<RectTransform> m_rectList = null;

        private void Awake()
        {
            Vector2 center = new Vector2(Screen.width / 2.0f , Screen.height / 2.0f);

            PlatinioTween.instance.Move(m_rectList[0] , center , 1.0f).SetEase(Ease.EaseOutElastic);
            PlatinioTween.instance.Move(m_rectList[1], center, 1.0f).SetEase(Ease.EaseOutElastic).SetDelay(2.0f);
            PlatinioTween.instance.Move(m_rectList[2], center, 1.0f).SetEase(Ease.EaseOutElastic).SetDelay(4.0f);
            PlatinioTween.instance.Move(m_rectList[3], center, 1.0f).SetEase(Ease.EaseOutElastic).SetDelay(6.0f);
        }
        
    }

}

