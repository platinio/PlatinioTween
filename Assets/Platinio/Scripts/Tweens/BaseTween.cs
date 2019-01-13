using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Platinio.TweenEngine
{
    /// <summary>
    /// Base tween class
    /// </summary>
    public abstract class BaseTween 
    {
        #region PROTECTED
        protected int               m_id                = 0;
        protected float             m_delay             = 0.0f;
        protected float             m_startTime         = 0.0f;
        protected float             m_duration          = 0.0f;
        protected float             m_currentTime       = 0.0f;
        protected Ease              m_ease              = Ease.Linear;
        #endregion

        public int id { get { return m_id; } }

        #region EVENTS
        protected Action            m_onComplete        = null;
        protected Action<Vector3>   m_onUpdateVector3   = null;
        protected Action<float>     m_onUpdateFloat     = null;
        protected Action<Transform> m_onUpdateTransform = null;
        protected Action<Color>     m_onUpdateColor     = null;
        protected Action<Vector2>   m_onUpdateVector2   = null;
        protected List<TimeEvent>   m_events            = new List<TimeEvent>();
        #endregion

        private float m_timeSinceStart = 0.0f;

        public bool ShouldBeCleaned { get; set; }

        /// <summary>
        /// Called to update this tween
        /// </summary>
        public virtual void Update(float deltaTime)
        {
            m_timeSinceStart += deltaTime;

            if (m_events.Count > 0 && m_timeSinceStart >= m_events[0].Time)
            {
                m_events[0].Action();
                m_events.RemoveAt(0);
            }
        }
                
        /// <summary>
        /// Set ease type
        /// </summary>
        /// <param name="ease"></param>
        public virtual BaseTween SetEase(Ease ease)
        {
            m_ease = ease;
            return this;
        }

        public BaseTween SetEvent(Action action , float t)
        {
            m_events.Add(new TimeEvent(action , t));

            //sort this list
            if(m_events.Count > 1)
                m_events = m_events.OrderBy( o => o.Time).ToList();

           
            return this;
        }

        /// <summary>
        /// Set callback for onComplete
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public virtual BaseTween SetOnComplete(Action action)
        {
            m_onComplete += action;
            return this;
        }

        /// <summary>
        /// set a delay
        /// </summary>
        /// <param name="t">delay in seconds </param>
        /// <returns></returns>
        public virtual BaseTween SetDelay(float t)
        {
            m_delay = t;

            return this;
        }

        public virtual BaseTween SetOnUpdate(Action<Vector2> action)
        {
            m_onUpdateVector2 += action;
            return this;
        }

        public virtual BaseTween SetOnUpdate(Action<Color> action)
        {
            m_onUpdateColor += action;
            return this;
        }

        /// <summary>
        /// Set Callback for OnUpdate
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public virtual BaseTween SetOnUpdate(Action<Vector3> action)
        {
            m_onUpdateVector3 += action;
            return this;
        }

        /// <summary>
        /// Set Callback for OnUpdate
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public virtual BaseTween SetOnUpdate(Action<float> action)
        {
            m_onUpdateFloat += action;
            return this;
        }

        /// <summary>
        /// Set Callback for OnUpdate
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public virtual BaseTween SetOnUpdate(Action<Transform> action)
        {
            m_onUpdateTransform += action;
            return this;
        }

    }

    public class TimeEvent
    {
        public Action Action;
        public float Time;

        public TimeEvent(Action action , float t)
        {
            Action = action;
            Time = t;
        }
    }

}

