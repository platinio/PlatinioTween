using UnityEngine;
using Platinio.UI;

namespace Platinio
{
    public class LoginSceneManager : MonoBehaviour
    {
        [SerializeField] private RectTransform canvas = null;
        [SerializeField] private UIAnimator brandTextAnimator = null;
        [SerializeField] private UIAnimator sloganTextAnimator = null;
        [SerializeField] private UIAnimator loadingScreenAnimator = null;
        [SerializeField] private UIAnimator loginBoxAnimator = null;
        [SerializeField] private UIAnimator loginButtonAnimator = null;
        [SerializeField] private UIAnimator usernameInputAnimator = null;
        [SerializeField] private UIAnimator passwordInputAnimator = null;
        [SerializeField] private GameObject loadingUI = null;
        
        private void Start()
        {
            PlayEnterAnimation();
        }

        private void PlayEnterAnimation()
        {
            brandTextAnimator.Play( "In" ).SetOnComplete( delegate
            {
                RectTransform rect = brandTextAnimator.GetComponent<RectTransform>();
                Vector2 size = rect.FromRectSizeToAbsoluteSize( canvas );
                Vector2 translation = new Vector2( 0.0f, size.y );

                rect.TranslateUI( translation, canvas, 1.0f ).SetEase( Ease.EaseOutExpo );
                sloganTextAnimator.Play( "FadeIn" ).SetOnComplete(delegate
                {
                    loadingScreenAnimator.Play("FadeOut").SetOnComplete(delegate { PlayLoginEnterAnimation(); } );
                } );
            } ).SetDelay(1.0f);
        }

        private void PlayLoginEnterAnimation()
        {
            loadingUI.SetActive(false);

            loginBoxAnimator.Play("FadeIn");
            loginBoxAnimator.Play("MoveIn").SetOnComplete(delegate 
            {
                loginButtonAnimator.Play("ScaleIn").SetOnComplete(delegate 
                {
                    usernameInputAnimator.Play( "TranslateIn" );
                    usernameInputAnimator.Play( "FadeIn" );

                    passwordInputAnimator.Play( "TranslateIn" ).SetDelay(0.5f);
                    passwordInputAnimator.Play( "FadeIn" ).SetDelay(0.5f);
                } );
            } );
        }



    }
}

