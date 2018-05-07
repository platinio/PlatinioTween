
using UnityEngine;
using System.Collections.Generic;
using System;

namespace Platinio.TweenEngine
{    
    
    /// <summary>
    /// Tween engine
    /// </summary>
    public class PlatinioTween : Singleton<PlatinioTween>
    {
        #region PRIVATE
        private List<BaseTween> m_tweens    = null;
        private int             m_counter   = 0;
        #endregion

        #region UNITY_EVENTS
        protected override void Awake()
        {
            base.Awake();
            m_tweens = new List<BaseTween>();
        }

        private void Update()
        {

            for (int n = 0 ; n < m_tweens.Count ; n++)
            {                
                m_tweens[n].Update();
            }
        }
        #endregion

        private int GenerateId()
        {
            try
            {
                m_counter++;
            }
            catch (OverflowException)
            {
                m_counter = 0;
            }

            return m_counter;
        }

        private BaseTween ProcessTween(BaseTween tween)
        {
            tween.SetOnComplete( delegate { m_tweens.Remove(tween); } );
            m_tweens.Add(tween);

            return tween;
        }

        public void CancelTween(int id)
        {
            for (int n = 0; n < m_tweens.Count; n++)
            {
                if (m_tweens[n].id == id)
                {
                    m_tweens.RemoveAt(n);
                    break;
                }
            }
        }


        #region TWEENS
        public BaseTween Vector3Tween(Vector3 from , Vector3 to , float t)
        {
            Vector3Tween tween = new Vector3Tween(from , to , t , GenerateId() );
            return ProcessTween(tween);           
        }

        public BaseTween ValueTween(float from , float to , float t)
        {
            ValueTween tween = new ValueTween(from , to , t , GenerateId());
            return ProcessTween(tween);
        }

        public BaseTween Move(Transform obj , Transform to , float t)
        {
            MoveTween tween = new MoveTween(obj , to , t , GenerateId());
            return ProcessTween(tween);
        }

        #endregion

    }

}

