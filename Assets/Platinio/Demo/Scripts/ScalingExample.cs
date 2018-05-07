using UnityEngine;
using Platinio.TweenEngine;

namespace Demo
{
    public class ScalingExample : MonoBehaviour
    {
        [SerializeField] private GameObject m_go = null;

        private void Awake()
        {
            PlatinioTween.instance.ScaleX(m_go , 50.0f , 10.0f);
            PlatinioTween.instance.ScaleY(m_go, 50.0f, 10.0f).SetDelay(4.0f).SetOnComplete(() => 
            {
                Debug.Log("complete");
            });
        }
    }

}

