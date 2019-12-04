using System.Collections.Generic;
using UnityEngine;
using System;

namespace Platinio.TweenEngine
{
    public static class TweenPool
    {
        static List<ValueTween> valueTweens = new List<ValueTween>();
        static List<Vector2Tween> vector2Tweens = new List<Vector2Tween>();
        static List<Vector3Tween> vector3Tweens = new List<Vector3Tween>();
        static List<MoveTween> moveTweens = new List<MoveTween>();
        static List<ColorTween> colorTweens = new List<ColorTween>();

        static int counter = 0;

        static HashSet<BaseTween> _activeTweens = new HashSet<BaseTween>();
        public static ReadOnlyHashSet<BaseTween> activeTweens;

        static TweenPool()
        {
            activeTweens = new ReadOnlyHashSet<BaseTween>(_activeTweens);
        }

        private static int GenerateId()
        {
            try
            {
                counter++;
            }
            catch (OverflowException)
            {
                counter = 0;
            }

            return counter;
        }
        public static void FinishTween(BaseTween tween)
        {
            _activeTweens.Remove(tween);
            AddTweenToPool(tween);
        }

        private static void AddTweenToPool(BaseTween tween)
        {
            switch (tween)
            {
                case ValueTween t:
                    valueTweens.Add(t);
                    break;
                case MoveTween t:
                    moveTweens.Add(t);
                    break;
                case Vector2Tween t:
                    vector2Tweens.Add(t);
                    break;
                case Vector3Tween t:
                    vector3Tweens.Add(t);
                    break;
                case ColorTween t:
                    colorTweens.Add(t);
                    break;
                default:
                    break;
            }
        }

        private static bool TryGetTween<T>(List<T> list, out T tween) where T : BaseTween
        {
            if (list.Count > 0)
            {
                int last = list.Count - 1;
                tween = list[last];
                list.RemoveAt(last);
                tween.Reset();
                return true;
            }
            else
            {
                tween = null;
                return false;
            }
        }

        public static ValueTween GetValueTween(float start, float end, float t)
        {
            ValueTween tween;
            if (TryGetTween(valueTweens, out tween))
            {
                tween.Reset();
                tween.Init(start, end, t);
            }
            else
            {
                tween = new ValueTween(start, end, t, GenerateId());
            }

            _activeTweens.Add(tween);
            return tween;
        }

        internal static MoveTween GetMoveTween(Transform obj, Transform to, float t)
        {
            MoveTween tween;
            if (TryGetTween(moveTweens, out tween))
            {
                tween.Init(obj, to, t);
            }
            else
            {
                tween = new MoveTween(obj, to, t, GenerateId());
            }

            _activeTweens.Add(tween);
            return tween;
        }

        internal static Vector3Tween GetVector3Tween(Vector3 from, Vector3 to, float time)
        {
            Vector3Tween tween;
            if (TryGetTween(vector3Tweens, out tween))
            {
                tween.Init(from, to, time);
            }
            else
            {
                tween = new Vector3Tween(from, to, time, GenerateId());
            }
            _activeTweens.Add(tween);
            return tween;
        }

        internal static Vector2Tween GetVector2Tween(Vector2 from, Vector2 to, float t)
        {
            Vector2Tween tween;
            if (TryGetTween(vector2Tweens, out tween))
            {
                tween.Init(from, to, t);
            }
            else
            {
                tween = new Vector2Tween(from, to, t, GenerateId());
            }

            _activeTweens.Add(tween);
            return tween;
        }

        internal static ColorTween GetColorTween(Color from, Color to, float t)
        {
            ColorTween tween;
            if (TryGetTween(colorTweens, out tween))
            {
                tween.Init(from, to, t);
            }
            else
            {
                tween = new ColorTween(from, to, t, GenerateId());
            }
            _activeTweens.Add(tween);
            return tween;
        }

        public static void RemoveTween(BaseTween tween)
        {
            _activeTweens.Remove(tween);
        }
    }
}
