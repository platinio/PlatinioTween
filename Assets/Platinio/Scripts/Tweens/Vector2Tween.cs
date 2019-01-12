using UnityEngine;

namespace Platinio.TweenEngine
{

    public class Vector2Tween : BaseTween
    {
        #region PRIVATE
        private Vector2 m_from = Vector3.zero;
        private Vector2 m_to = Vector3.zero;
        #endregion

        #region PUBLIC
        public Vector2Tween(Vector2 from, Vector2 to, float t, int id)
        {
            m_from = from;
            m_to = to;
            m_duration = t;
            m_id = id;
        }

        /// <summary>
        /// called every frame
        /// </summary>
        public override void Update()
        {
            //wait a delay
            if (m_delay > 0.0f)
            {
                m_delay -= Time.deltaTime;
                return;
            }

            //start counting time
            m_currentTime += Time.deltaTime;

            //if time ends
            if (m_currentTime >= m_duration)
            {
               
                if (m_onUpdateVector2 != null)
                    m_onUpdateVector2(m_to);

                m_onComplete();
                return;
            }

            //get new value
            Vector2 change = m_to - m_from;
            Vector2 value = Equations.ChangeVector(m_currentTime, m_from, change, m_duration, m_ease);

            //Vector2 vector2Value = new Vector2(value.x , value.y);

            //call update if we have it
            if (m_onUpdateVector2 != null)
                m_onUpdateVector2(value);
        }
        #endregion
    }

}
