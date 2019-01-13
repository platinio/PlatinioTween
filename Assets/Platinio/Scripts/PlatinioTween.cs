using UnityEngine;
using UnityEngine.UI;
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
        private List<BaseTween> m_tweens = null;
        private int m_counter = 0;
        #endregion

        #region UNITY_EVENTS
        protected override void Awake()
        {
            base.Awake();
            m_tweens = new List<BaseTween>();
        }

        private void Update()
        {
            for (int n = 0; n < m_tweens.Count; n++)
            {
                m_tweens[n].Update(Time.deltaTime);
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
            tween.SetOnComplete(delegate { m_tweens.Remove(tween); });
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


        
        #region SCALE_TWEENS
        public BaseTween ScaleTween(Transform t , Vector3 to , float time)
        {
            Vector3Tween tween = new Vector3Tween(t.localScale, to, time, GenerateId());
            tween.SetOnUpdate(delegate(Vector3 v) 
            {
                t.localScale = v;
            });
            return ProcessTween(tween);
        }

        public BaseTween ScaleTween(GameObject go, Vector3 to, float time)
        {
            return ScaleTween(go.transform , to , time);
        }

        public BaseTween ScaleTween(RectTransform rect, Vector3 to, float time)
        {
            return ScaleTween(rect.transform, to, time);
        }

        public BaseTween ScaleTweenAtSpeed(Transform t, Vector3 to, float speed)
        {
            float time = Vector3.Distance(t.position , to) / speed;

            return ScaleTween(t, to, time);
        }

        public BaseTween ScaleTweenAtSpeed(GameObject go, Vector3 to, float speed)
        {
            float time = Vector3.Distance(go.transform.position, to) / speed;

            return ScaleTween(go, to, time);
        }

        public BaseTween ScaleTweenAtSpeed(RectTransform rect, Vector3 to, float speed)
        {
            float time = Vector3.Distance(rect.transform.position, to) / speed;

            return ScaleTween(rect.transform, to, time);
        }
        public BaseTween ScaleX(Transform obj, float value, float t)
        {
            return ValueTween(obj.localScale.x, value, t).SetOnUpdate((float v) =>
            {
                Vector3 currentScale = obj.localScale;
                currentScale.x = v;
                obj.localScale = currentScale;
            });
        }

        public BaseTween ScaleX(GameObject obj, float value, float t)
        {
            return ScaleX(obj.transform, value, t);
        }

        public BaseTween ScaleY(Transform obj, float value, float t)
        {
            return ValueTween(obj.localScale.y, value, t).SetOnUpdate((float v) =>
            {
                Vector3 currentScale = obj.localScale;
                currentScale.y = v;
                obj.localScale = currentScale;
            });
        }

        public BaseTween ScaleY(GameObject obj, float value, float t)
        {
            return ScaleY(obj.transform, value, t);
        }

        public BaseTween ScaleZ(Transform obj, float value, float t)
        {
            return ValueTween(obj.localScale.z, value, t).SetOnUpdate((float v) =>
            {
                Vector3 currentScale = obj.localScale;
                currentScale.z = v;
                obj.localScale = currentScale;
            });
        }

        public BaseTween ScaleZ(GameObject obj, float value, float t)
        {
            return ScaleZ(obj.transform, value, t);
        }
        #endregion

        #region ROTATE_TWEENS

        public BaseTween RotateTween(Transform t , Vector3 axis , float to , float time)
        {
            Vector3Tween tween = new Vector3Tween(t.rotation.eulerAngles , axis * to , time, GenerateId());
            tween.SetOnUpdate(delegate(Vector3 v) 
            {
                t.rotation = Quaternion.Euler(v);
            });
            return ProcessTween(tween);
        }

        public BaseTween RotateTween(GameObject go, Vector3 axis, float to, float time)
        {
            return RotateTween(go.transform , axis , to , time);
        }

        public BaseTween RotateTween(RectTransform rect, Vector3 axis, float to, float time)
        {
            return RotateTween(rect.transform, axis, to, time);
        }

        #endregion

        #region FADE_TWEENS

        public BaseTween FadeOut(CanvasGroup cg, float t)
        {
            return Fade(cg, 0.0f, t);
        }

        public BaseTween FadeIn(CanvasGroup cg, float t)
        {
            return Fade(cg , 1.0f , t);           
        }

        public BaseTween Fade(CanvasGroup cg, float to, float t)
        {
            ValueTween tween = new ValueTween(cg.alpha, to, t, GenerateId());
            tween.SetOnUpdate(delegate (float v) { cg.alpha = v; });
            return ProcessTween(tween);
        }

        public BaseTween Fade(Image image, float to, float t)
        {
            ValueTween tween = new ValueTween( image.color.a , to, t, GenerateId());
            tween.SetOnUpdate(delegate (float v) 
            {
                Color c = image.color;
                c.a = v;
                image.color = c;
            });
            return ProcessTween(tween);
        }

        public BaseTween FadeOut(Image image , float t)
        {
            return Fade(image , 0.0f , t);
        }

        public BaseTween FadeIn(Image image, float t)
        {
            return Fade(image, 1.0f, t);
        }

        public BaseTween Fade(SpriteRenderer sprite, float to, float t)
        {
            ValueTween tween = new ValueTween(sprite.color.a, to, t, GenerateId());
            tween.SetOnUpdate(delegate (float v)
            {
                Color c = sprite.color;
                c.a = v;
                sprite.color = c;
            });
            return ProcessTween(tween);
        }

        public BaseTween FadeOut(SpriteRenderer sprite, float t)
        {
            return Fade(sprite, 0.0f, t);
        }

        public BaseTween FadeIn(SpriteRenderer sprite, float t)
        {
            return Fade(sprite, 1.0f, t);
        }

        #endregion

        #region COLOR_TWEEN
        public BaseTween ColorTween(SpriteRenderer sprite, Color to, float t)
        {
            ColorTween tween = new ColorTween(sprite.color, to, t, GenerateId());
            tween.SetOnUpdate(delegate (Color c) { sprite.color = c; });
            return ProcessTween(tween);
        }

        public BaseTween ColorTween(Image image, Color to, float t)
        {
            ColorTween tween = new ColorTween(image.color, to, t, GenerateId());
            tween.SetOnUpdate(delegate (Color c) { image.color = c; });
            return ProcessTween(tween);
        }

        public BaseTween ColorTween(Color from, Color to, float t)
        {
            ColorTween tween = new ColorTween(from, to, t, GenerateId());
            return ProcessTween(tween);
        }
        #endregion

        #region VECTOR_TWEEN
        public BaseTween Vector2Tween(Vector2 from, Vector2 to, float t)
        {
            Vector2Tween tween = new Vector2Tween(from, to, t, GenerateId());
            return ProcessTween(tween);
        }

        public BaseTween Vector3Tween(Vector3 from, Vector3 to, float t)
        {
            Vector3Tween tween = new Vector3Tween(from, to, t, GenerateId());
            return ProcessTween(tween);
        }
        #endregion


        #region VALUE_TWEEN
        public BaseTween ValueTween(float from , float to , float t)
        {
            ValueTween tween = new ValueTween(from , to , t , GenerateId());
            return ProcessTween(tween);
        }
        #endregion

        #region MOVE_TWEEN
        public BaseTween Move(Transform obj , Transform to , float t)
        {
            MoveTween tween = new MoveTween(obj , to , t , GenerateId());
            return ProcessTween(tween);
        }

        public BaseTween Move(Transform obj , Vector3 to , float t)
        {
            Vector3Tween tween = new Vector3Tween(obj.position , to , t , GenerateId());
            tween.SetOnUpdate((Vector3 pos) => 
            {
                obj.position = pos;
            });
            return ProcessTween(tween);
        }

        public BaseTween Move(GameObject obj , Transform to , float t)
        {
            return Move(obj.transform , to , t);
        }

        public BaseTween Move(GameObject obj, Vector3 to, float t)
        {
            return Move(obj.transform, to, t);
        }

        public BaseTween Move(GameObject obj, GameObject to, float t)
        {
            return Move(obj.transform, to.transform, t);
        }

        public BaseTween Move(Transform obj, GameObject to, float t)
        {
            return Move(obj, to.transform, t);
        }

        public BaseTween Move(RectTransform rect , Vector2 pos , float t)
        {
            return Vector3Tween(new Vector3(rect.anchoredPosition.x , rect.anchoredPosition.y , 0.0f) , new Vector3(pos.x, pos.y , 0.0f) , t).SetOnUpdate((Vector3 value) =>
            {
                rect.anchoredPosition = new Vector2(value.x , value.y);
            });
        }

        //use this to position UI in absolute coordenates
        //0.0 , 1.0 _______________________1.0 , 1.0
        //          |                      |
        //          |                      |                  
        //          |                      |
        //          |                      |
        //0.0 , 0.0 |______________________| 1.0 , 0.0

        
        /// <summary>
        /// Move a UI element using absolute position
        /// Note: dont use this on Awake
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="absolutePosition"></param>
        /// <param name="canvas"></param>
        /// <param name="t"></param>
        /// <returns></returns>        

        public BaseTween MoveUI(RectTransform rect , Vector2 absolutePosition , RectTransform canvas , float t)
        {
            Vector2 pos = PlatinioTween.FromAbsolutePositionToCanvasPosition(absolutePosition , rect , canvas);

            return Move(rect , pos , t);
        }

        #endregion


        public static Vector2 FromAbsolutePositionToCanvasPosition(Vector2 v, RectTransform rect , RectTransform canvas)
        {
            return Vector2.Scale(v - rect.anchorMin, canvas.sizeDelta);
        }

        public static Vector2 FromCanvasPositionToAbsolutePosition(RectTransform rect, RectTransform canvas)
        {
            return new Vector2(rect.anchoredPosition.x / canvas.sizeDelta.x , rect.anchoredPosition.y / canvas.sizeDelta.y) + rect.anchorMin;
        }

    }

}

