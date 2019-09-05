using UnityEngine;

namespace Platinio
{
    public class LoginSceneManager : MonoBehaviour
    {
        [SerializeField] private UIAnimator brandTextAnimator = null;

        private void Start()
        {
            brandTextAnimator.Play("In");
        }
    }
}

