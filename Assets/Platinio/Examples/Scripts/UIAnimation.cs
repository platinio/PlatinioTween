using UnityEngine;
using Platinio.TweenEngine;

namespace Platinio
{
    public abstract class UIAnimation : MonoBehaviour
    {
        [SerializeField] private string id = null;
        [SerializeField] protected Ease ease = Ease.EaseInBack;
        [SerializeField] protected float time = 0.0f;

        public string ID { get { return id; } }

        public abstract BaseTween Play();
       
    }
}

