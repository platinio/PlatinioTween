using UnityEngine;
using Platinio.TweenEngine;

namespace Platinio
{
    public class UIAnimator : MonoBehaviour
    {
        private UIAnimation[] animationArray = null;

        private void Awake()
        {
            animationArray = GetComponents<UIAnimation>();
        }

        public BaseTween Play(string id)
        {
            UIAnimation animation = GetAnimationByID(id);

            if (animation != null)
                return animation.Play();

            return null;
        }

        private UIAnimation GetAnimationByID(string id)
        {
            for (int n = 0; n < animationArray.Length; n++)
            {
                if (animationArray[n].ID == id)
                    return animationArray[n];
            }

            return null;
        }
    }
}

