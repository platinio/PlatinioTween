using UnityEngine;
using Platinio.UI;

namespace Platinio
{
    public class LoginSceneManager : MonoBehaviour
    {
        [SerializeField] private RectTransform canvas = null;
        [SerializeField] private UIAnimator brandTextAnimator = null;
        [SerializeField] private UIAnimator sloganTextAnimator = null;
        
        private void Start()
        {
            brandTextAnimator.Play("In").SetOnComplete(delegate 
            {
                RectTransform rect = brandTextAnimator.GetComponent<RectTransform>();
                Vector2 size = rect.FromRectSizeToAbsoluteSize(canvas);
                Vector2 translation = new Vector2(0.0f , size.y);

                rect.TranslateUI(translation , canvas , 1.0f).SetEase(Ease.EaseOutExpo);
                sloganTextAnimator.Play("FadeIn");
            } );
        }



    }
}

