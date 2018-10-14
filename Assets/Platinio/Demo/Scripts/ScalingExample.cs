using UnityEngine;
using Platinio.TweenEngine;

namespace Demo
{
    public class ScalingExample : MonoBehaviour
    {
        [SerializeField] private GameObject m_go = null;

        private void Awake()
        {
            PlatinioTween.instance.ScaleTween(m_go.transform , Vector3.one * 8 , 1.5f).SetEase(Ease.EaseOutElastic).SetDelay(2.0f);
        }
    }

}

