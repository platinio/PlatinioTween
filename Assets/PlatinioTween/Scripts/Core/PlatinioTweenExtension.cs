using UnityEngine;
using UnityEngine.UI;
using Platinio.TweenEngine;
using Platinio.UI;

public static class PlatinioTweenExtension
{
    public static BaseTween ScaleTween(this Transform t , Vector3 to , float time)
    {
        return PlatinioTween.instance.ScaleTween(t , to , time);
    }

    public static BaseTween ScaleTween(this GameObject go, Vector3 to, float time)
    {
        return PlatinioTween.instance.ScaleTween( go.transform, to, time );
    }

    public static BaseTween ScaleTween(this RectTransform rect, Vector3 to, float time)
    {
        return PlatinioTween.instance.ScaleTween( rect, to, time );
    }

    public static BaseTween ScaleAtSpeed(this Transform t, Vector3 to, float speed)
    {
        return PlatinioTween.instance.ScaleTweenAtSpeed(t , to , speed);
    }

    public static BaseTween ScaleAtSpeed(this GameObject go, Vector3 to, float speed)
    {
        return PlatinioTween.instance.ScaleTweenAtSpeed(go , to , speed);
    }

    public static BaseTween ScaleAtSpeed(this RectTransform rect, Vector3 to, float speed)
    {
        return PlatinioTween.instance.ScaleTweenAtSpeed(rect , to , speed);
    }

    public static BaseTween ScaleX(this Transform obj, float value, float t)
    {
        return PlatinioTween.instance.ScaleX(obj , value , t);
    }

    public static BaseTween ScaleX(this GameObject obj, float value, float t)
    {
        return PlatinioTween.instance.ScaleX(obj , value , t);
    }

    public static BaseTween ScaleX(this RectTransform obj, float value, float t)
    {
        return PlatinioTween.instance.ScaleX(obj , value , t);
    }

    public static BaseTween ScaleXAtSpeed(this Transform obj, float value, float speed)
    {
        return PlatinioTween.instance.ScaleXAtSpeed(obj , value , speed);
    }

    public static BaseTween ScaleXAtSpeed(this GameObject obj, float value, float speed)
    {
        return PlatinioTween.instance.ScaleXAtSpeed(obj , value , speed);
    }

    public static BaseTween ScaleXAtSpeed(this RectTransform obj, float value, float speed)
    {
        return PlatinioTween.instance.ScaleXAtSpeed(obj , value , speed);
    }
    
    public static BaseTween ScaleY(this Transform obj, float value, float t)
    {
        return PlatinioTween.instance.ScaleY( obj, value, t );
    }

    public static BaseTween ScaleY(this GameObject obj, float value, float t)
    {
        return PlatinioTween.instance.ScaleY( obj, value, t );
    }

    public static BaseTween ScaleY(this RectTransform obj, float value, float t)
    {
        return PlatinioTween.instance.ScaleY( obj, value, t );
    }

    public static BaseTween ScaleYAtSpeed(this Transform obj, float value, float speed)
    {
        return PlatinioTween.instance.ScaleYAtSpeed( obj, value, speed );
    }

    public static BaseTween ScaleYAtSpeed(this GameObject obj, float value, float speed)
    {
        return PlatinioTween.instance.ScaleYAtSpeed( obj, value, speed );
    }

    public static BaseTween ScaleYAtSpeed(this RectTransform obj, float value, float speed)
    {
        return PlatinioTween.instance.ScaleYAtSpeed( obj, value, speed );
    }

    public static BaseTween ScaleZ(this Transform obj, float value, float t)
    {
        return PlatinioTween.instance.ScaleX( obj, value, t );
    }

    public static BaseTween ScaleZ(this GameObject obj, float value, float t)
    {
        return PlatinioTween.instance.ScaleX( obj, value, t );
    }

    public static BaseTween ScaleZ(this RectTransform obj, float value, float t)
    {
        return PlatinioTween.instance.ScaleX( obj, value, t );
    }

    public static BaseTween ScaleZAtSpeed(this Transform obj, float value, float speed)
    {
        return PlatinioTween.instance.ScaleXAtSpeed( obj, value, speed );
    }

    public static BaseTween ScaleZAtSpeed(this GameObject obj, float value, float speed)
    {
        return PlatinioTween.instance.ScaleXAtSpeed( obj, value, speed );
    }

    public static BaseTween ScaleZAtSpeed(this RectTransform obj, float value, float speed)
    {
        return PlatinioTween.instance.ScaleXAtSpeed( obj, value, speed );
    }

    public static BaseTween RotateTween(this Transform t, Vector3 axis, float to, float time)
    {
        return PlatinioTween.instance.RotateTween(t , axis , to , time);
    } 

    public static BaseTween RotateTween(this Transform t, Vector3 to, float time)
    {
        return PlatinioTween.instance.RotateTween(t, to, time);
    }

    public static BaseTween RotateTween(this Transform t, Quaternion to, float time)
    {
        return PlatinioTween.instance.RotateTween(t, to, time);
    }

    public static BaseTween RotateTween(this GameObject go, Vector3 to, float time)
    {
        return PlatinioTween.instance.RotateTween(go.transform, to, time);
    }

    public static BaseTween RotateTween(this GameObject go, Vector3 axis, float to, float time)
    {
        return PlatinioTween.instance.RotateTween(go, axis, to, time);
    }

    public static BaseTween RotateTween(this GameObject go, Quaternion to, float time)
    {
        return PlatinioTween.instance.RotateTween(go.transform, to, time);
    }

    public static BaseTween RotateTween(this RectTransform rect, Vector3 to, float time)
    {
        return PlatinioTween.instance.RotateTween(rect, to, time);
    }

    public static BaseTween RotateTween(this RectTransform rect, Quaternion to, float time)
    {
        return PlatinioTween.instance.RotateTween(rect, to, time);
    }
    public static BaseTween RotateTween(this RectTransform rect, Vector3 axis, float to, float time)
    {
        return PlatinioTween.instance.RotateTween(rect, axis, to, time);
    }

    public static BaseTween FadeOutAtSpeed(this CanvasGroup cg, float speed)
    {
        return PlatinioTween.instance.FadeOutAtSpeed(cg , speed);
    }

    public static BaseTween FadeIn(this CanvasGroup cg, float t)
    {
        return PlatinioTween.instance.FadeIn(cg , t);
    }

    public static BaseTween FadeInAtSpeed(this CanvasGroup cg, float speed)
    {
        return PlatinioTween.instance.FadeInAtSpeed(cg , speed);
    }

    public static BaseTween Fade(this CanvasGroup cg, float to, float t)
    {
        return PlatinioTween.instance.Fade(cg , to , t);
    }

    public static BaseTween FadeAtSpeed(this CanvasGroup cg, float to, float speed)
    {
        return PlatinioTween.instance.FadeAtSpeed(cg , to , speed);
    }

    public static BaseTween Fade(Image image, float to, float t)
    {
        return PlatinioTween.instance.Fade(image , to , t);
    }

    public static BaseTween FadeAtSpeed(this Image img, float to, float speed)
    {
        return PlatinioTween.instance.FadeAtSpeed(img , to , speed);
    }

    public static BaseTween FadeOut(this Image image, float t)
    {
        return PlatinioTween.instance.FadeOut(image , t);
    }

    public static BaseTween FadeOutAtSpeed(this Image img, float speed)
    {
        return PlatinioTween.instance.FadeOutAtSpeed(img , speed);
    }

    public static BaseTween FadeIn(this Image image, float t)
    {
        return PlatinioTween.instance.FadeIn(image , t);
    }

    public static BaseTween FadeInAtSpeed(this Image img, float speed)
    {
        return PlatinioTween.instance.FadeInAtSpeed(img , speed);
    }

    public static BaseTween Fade(this SpriteRenderer sprite, float to, float t)
    {
        return PlatinioTween.instance.Fade(sprite , to , t);
    }

    public static BaseTween FadeAtSpeed(this SpriteRenderer sprite, float to, float speed)
    {
        return PlatinioTween.instance.FadeAtSpeed(sprite , to , speed);
    }

    public static BaseTween FadeOut(this CanvasGroup cg , float t)
    {
        return PlatinioTween.instance.FadeOut(cg, t);
    }

    public static BaseTween FadeOut(this SpriteRenderer sprite, float t)
    {
        return PlatinioTween.instance.FadeOut(sprite , t);
    }

    public static BaseTween FadeOutAtSpeed(this SpriteRenderer sprite, float speed)
    {
        return PlatinioTween.instance.FadeOutAtSpeed(sprite , speed);
    }

    public static BaseTween FadeIn(this SpriteRenderer sprite, float t)
    {
        return PlatinioTween.instance.FadeIn(sprite , t);
    }

    public static BaseTween FadeInAtSpeed(this SpriteRenderer sprite, float speed)
    {
        return PlatinioTween.instance.FadeInAtSpeed(sprite , speed);
    }

    public static BaseTween ColorTween(this SpriteRenderer sprite, Color to, float t)
    {
        return PlatinioTween.instance.ColorTween(sprite , to , t);
    }

    public static BaseTween ColorTweenAtSpeed(this SpriteRenderer sprite, Color to, float speed)
    {
        return PlatinioTween.instance.ColorTweenAtSpeed(sprite , to , speed);
    }

    public static BaseTween ColorTween(this Image image, Color to, float t)
    {
        return PlatinioTween.instance.ColorTween(image , to , t);
    }

    public static BaseTween ColorTweenAtSpeed(this Image img, Color to, float speed)
    {
        return PlatinioTween.instance.ColorTweenAtSpeed(img , to , speed);
    }

    public static BaseTween FillAmountTween(this Image img , float to , float t)
    {
        return PlatinioTween.instance.FillAmountTween(img , to , t);
    }

    public static BaseTween FillAmountTweenAtSpeed(this Image img, float to, float speed)
    {
        return PlatinioTween.instance.FillAmountTween(img, to, speed);
    }

    public static BaseTween Move(this Transform obj, Transform to, float t)
    {
        return PlatinioTween.instance.Move(obj , to , t);
    }

    public static BaseTween MoveAtSpeed(this Transform obj, Transform to, float speed)
    {
        return PlatinioTween.instance.MoveAtSpeed(obj , to , speed);
    }

    public static BaseTween Move(this Transform obj, Vector3 to, float t)
    {
        return PlatinioTween.instance.Move(obj , to , t);
    }

    public static BaseTween MoveAtSpeed(this Transform obj, Vector3 to, float speed)
    {
        return PlatinioTween.instance.MoveAtSpeed(obj , to , speed);
    }


    public static BaseTween Move(this GameObject obj, Transform to, float t)
    {
        return PlatinioTween.instance.Move(obj , to , t);
    }

    public static BaseTween MoveAtSpeed(this GameObject obj, Transform to, float speed)
    {
        return PlatinioTween.instance.MoveAtSpeed(obj , to , speed);
    }

    public static BaseTween Move(this GameObject obj, Vector3 to, float t)
    {
        return PlatinioTween.instance.Move(obj , to , t);
    }

    public static BaseTween MoveAtSpeed(this GameObject obj, Vector3 to, float speed)
    {
        return PlatinioTween.instance.MoveAtSpeed(obj , to , speed);
    }

    public static BaseTween Move(this GameObject obj, GameObject to, float t)
    {
        return PlatinioTween.instance.Move(obj , to , t);
    }

    public static BaseTween MoveAtSpeed(this GameObject obj, GameObject to, float speed)
    {
        return PlatinioTween.instance.MoveAtSpeed(obj , to , speed);
    }

    public static BaseTween Move(this Transform obj, GameObject to, float t)
    {
        return PlatinioTween.instance.Move(obj , to , t);
    }

    public static BaseTween MoveAtSpeed(this Transform obj, GameObject to, float speed)
    {
        return PlatinioTween.instance.MoveAtSpeed(obj , to , speed);
    }

    public static BaseTween Move(this RectTransform rect, Vector2 pos, float t)
    {
        return PlatinioTween.instance.Move(rect , pos , t);
    }

    public static BaseTween MoveAtSpeed(this RectTransform rect, Vector2 pos, float speed)
    {
        return PlatinioTween.instance.MoveAtSpeed(rect , pos , speed);
    }

    public static BaseTween MoveUI(this RectTransform rect, Vector2 absolutePosition, RectTransform canvas, float t, PivotPreset pivotPreset = PivotPreset.MiddleCenter)
    {
        return PlatinioTween.instance.MoveUI(rect , absolutePosition , canvas, t , pivotPreset);
    }


    public static BaseTween MoveUIAtSpeed(this RectTransform rect, Vector2 absolutePosition, RectTransform canvas, float speed , PivotPreset pivotPreset = PivotPreset.MiddleCenter)
    {
        return PlatinioTween.instance.MoveUIAtSpeed(rect , absolutePosition , canvas , speed , pivotPreset);
    }

    public static BaseTween TranslateUI(this RectTransform rect, Vector2 translation, RectTransform canvas, float t, PivotPreset pivotPreset = PivotPreset.MiddleCenter)
    {
        return PlatinioTween.instance.TranslateUI(rect , translation  , canvas , t , pivotPreset);
    }

    public static BaseTween TranslateUIAtSpeed(this RectTransform rect, Vector2 translation, RectTransform canvas, float speed, PivotPreset pivotPreset = PivotPreset.MiddleCenter)
    {
        return PlatinioTween.instance.TranslateUIAtSpeed( rect, translation, canvas, speed, pivotPreset );
    }    

    public static void CancelAllTweens(this GameObject go)
    {
        PlatinioTween.instance.CancelTween(go);
    }

    public static void CancelTween(this GameObject go , int id)
    {
        PlatinioTween.instance.CancelTween(id);
    }

}
