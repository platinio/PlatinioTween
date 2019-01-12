using UnityEngine;

namespace Platinio.TweenEngine
{
    public class ColorTween : BaseTween
    {
        private Color m_from    = Color.white;
        private Color m_to      = Color.white;

        public ColorTween(Color from , Color to , float t , int id)
        {
            m_from = from;
            m_to = to;
            m_duration = t;
            m_id = id;
        }

        public override void Update(float deltaTime)
        {
            //wait a delay
            if (m_delay > 0.0f)
            {
                m_delay -= deltaTime;
                return;
            }

            //start counting time
            m_currentTime += deltaTime;

            //if time ends
            if (m_currentTime >= m_duration)
            {
                m_onComplete();

                if (m_onUpdateColor != null)
                    m_onUpdateColor(m_to);
                return;
            }

            Vector3 to = new Vector3(m_to.r , m_to.g , m_to.b);
            Vector3 from = new Vector3(m_from.r , m_from.g , m_from.b);

            //get new value
            Vector3 change = to - from;
            Vector3 value = Equations.ChangeVector(m_currentTime, from, change, m_duration, m_ease);

            //get new value
            float alphaChange = m_to.a - m_from.a;
            float alphaValue = Equations.ChangeFloat(m_currentTime, m_from.a, alphaChange, m_duration, m_ease);

            Color color = new Color(value.x , value.y , value.z , alphaValue);

            //call update if we have it
            if (m_onUpdateColor != null)
                m_onUpdateColor(color);
        }
    }

}

