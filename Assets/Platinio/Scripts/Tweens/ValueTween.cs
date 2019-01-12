
namespace Platinio.TweenEngine
{
    public class ValueTween : BaseTween
    {
        #region PRIVATE
        private float m_from    = 0.0f;
        private float m_to      = 0.0f;
        #endregion

        #region PUBLIC
        public ValueTween(float from, float to, float t, int id)
        {
            m_from      = from;
            m_to        = to;
            m_duration  = t;
            m_id        = id;
        }

        /// <summary>
        /// called every frame
        /// </summary>
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

                if (m_onUpdateFloat != null)
                    m_onUpdateFloat(m_to);
                return;
            }

            //get new value
            float change    = m_to - m_from;
            float value     = Equations.ChangeFloat(m_currentTime, m_from, change, m_duration, m_ease);

            //call update if we have it
            if (m_onUpdateFloat != null)
                m_onUpdateFloat(value);
        }
        #endregion
    }

}

