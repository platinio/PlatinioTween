using UnityEngine;
using Platinio.TweenEngine;
using Platinio.UI;

namespace Platinio
{
    public class GearMenu : MonoBehaviour
    {
        [SerializeField] private float height = 0.05f;
        [SerializeField] private float gearRotation = 180.0f;
        [SerializeField] private RectTransform canvas = null;
        [SerializeField] private RectTransform hideMenu = null;
        [SerializeField] private RectTransform gearIcon = null;
        [SerializeField] private float time = 1.0f;
        [SerializeField] private Ease ease = Ease.Linear;

        private Vector2 startPosition = Vector2.zero;
        private bool isVisible = false;
        private bool isBusy = false;

        private void Start()
        {
            startPosition = hideMenu.FromAnchoredPositionToAbsolutePosition( canvas );
        }

        private void Show()
        {
           
            hideMenu.MoveUI(new Vector2(startPosition.x, startPosition.y + height ), canvas, time).SetEase(ease);
            gearIcon.RotateTween( Vector3.forward , gearIcon.rotation.eulerAngles.z + gearRotation  , time).SetEase(ease).SetOnComplete(delegate 
            {
                isBusy = false;
                isVisible = true;
            });
            
        }

        private void Hide()
        {
            hideMenu.MoveUI(startPosition, canvas, time).SetEase(ease);
            gearIcon.RotateTween(Vector3.forward, gearIcon.rotation.eulerAngles.z - gearRotation, time).SetEase(ease).SetOnComplete(delegate
            {
                isBusy = false;
                isVisible = false;
            }); 
        }

        public void Toggle()
        {
            if(isBusy)
                return;

            isBusy = true;

            if(isVisible)
                Hide();
            else
                Show();
        }


       
    }

}

