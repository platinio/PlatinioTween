﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Platinio.TweenEngine;
using Platinio.UI;

namespace Platinio
{
    public class Animal : MonoBehaviour , IPointerEnterHandler , IPointerExitHandler , IPointerClickHandler
    {
        [SerializeField] private Vector3 scale = Vector3.zero;
        [SerializeField] private float speed = 50.0f;
        [SerializeField] private float scapeTime = 0.01f;
        [SerializeField] private float rotAmount = 360.0f;
        [SerializeField] private float dieTime = 0.5f;
        [SerializeField] private Ease ease = Ease.Linear;

        private RectTransform canvas = null;
        private RectTransform thisRect = null;        
        private bool running = false;
        private bool mouseHover = false;
        private bool canRun = true;
        private int tweenId = -1;
        private bool dead = false;

        public void Construct(AnimalCatchManager manager , Sprite sprite)
        {
            GetComponent<Image>().sprite = sprite;
            GetComponent<Image>().SetNativeSize();

           
            thisRect = GetComponent<RectTransform>();
            canvas = manager.Canvas;
            
            transform.localScale = scale;

            thisRect.anchoredPosition = GetRandomPoint();
        }

        private void Update()
        {
            if(mouseHover)
                Run();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            mouseHover = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            mouseHover = false;
        }

        public void OnPointerClick(PointerEventData eventData)
        {           
            Die();
        }

        public void Run()
        {   
            if(running || !canRun)
                return;

            running = true;

            tweenId = PlatinioTween.instance.MoveUIAtSpeed( thisRect , new Vector2(Random.Range(0.01f, 0.98f), Random.Range(0.01f, 0.98f)) , canvas , speed).SetDelay(scapeTime).SetEase( ease ).SetOnComplete(delegate { running = false; }).ID;
        }

        private void Die()
        {
            if(dead)
                return;

            dead = true;
            canRun = false;
            CancelTween();

            PlatinioTween.instance.RotateTween(transform, Vector3.forward, transform.rotation.eulerAngles.z + rotAmount, dieTime).SetEase(ease).SetOnComplete(delegate { Destroy(gameObject); });
            PlatinioTween.instance.ScaleTween(transform, Vector3.zero , dieTime).SetEase(ease);
            PlatinioTween.instance.ColorTween(GetComponent<Image>() , Color.red , 0.3f);

        }

        private Vector2 GetRandomPoint()
        {
            return thisRect.FromAbsolutePositionToAnchoredPosition(new Vector2( Random.Range(0.01f , 0.98f) , Random.Range(0.01f, 0.98f)) , canvas );
        }

        private void CancelTween()
        {
            if (tweenId != -1)
                PlatinioTween.instance.CancelTween(tweenId);
        }


    }

}

