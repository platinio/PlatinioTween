using UnityEngine;
using System;

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
        #endregion

        /// <summary>
        /// Called to update this tween
        /// </summary>
        public abstract void Update();
                
        /// <summary>
        /// Set ease type
        /// </summary>
        /// <param name="ease"></param>
        public virtual BaseTween SetEase(Ease ease)
        {
            m_ease = ease;
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

}

