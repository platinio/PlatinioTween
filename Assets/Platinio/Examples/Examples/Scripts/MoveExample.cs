using UnityEngine;
using Platinio.TweenEngine;

namespace Demo
{
    public class MoveExample : MonoBehaviour
    {
        [SerializeField] private Transform m_leftMarker = null;
        [SerializeField] private Transform m_rightMarker = null;
        [SerializeField] private Transform m_obj = null;   

        private bool m_moveLeft = false;

        private void Awake()
        {
            Move();
        }

        private void Move()
        {
            m_moveLeft = !m_moveLeft;

            PlatinioTween.instance.Move(m_obj , m_moveLeft? m_leftMarker : m_rightMarker , 1.0f).SetEase(Ease.EaseInQuint).SetOnComplete( () => 
            {
                Move();
            } );
        }
        
    }

}

