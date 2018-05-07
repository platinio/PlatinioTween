using UnityEngine;


namespace Platinio.TweenEngine
{
    public class MoveTween : BaseTween
    {
        #region PRIVATE
        private Transform m_object      = null;
        private Transform m_to          = null;
        private Vector3   m_initialPos  = Vector3.zero;
        #endregion

        #region PUBLIC
        public MoveTween(Transform obj , Transform to, float t, int id)
        {
            m_object        = obj;
            m_to            = to;
            m_duration      = t;
            m_initialPos    = obj.position; 
            m_id            = id;
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
                m_object.position = m_to.position;

                m_onComplete();

                if (m_onUpdateTransform != null)
                    m_onUpdateTransform(m_object);
                return;
            }
            
            //get new value
            Vector3 change = m_to.position - m_initialPos;
            m_object.position = Equations.ChangeVector(m_currentTime, m_initialPos, change, m_duration, m_ease);
                        
            //call update if we have it
            if (m_onUpdateTransform != null)
                m_onUpdateTransform(m_object);
                
        }
        #endregion        
    }

}

