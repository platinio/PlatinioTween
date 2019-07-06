using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Platinio.TweenEngine;

namespace Platinio
{
    public class Animal : MonoBehaviour , IPointerEnterHandler , IPointerExitHandler , IPointerClickHandler
    {
        [SerializeField] private Vector3 m_scale = Vector3.zero;
        [SerializeField] private float m_speed = 50.0f;
        [SerializeField] private float m_scapeTime = 0.01f;
        [SerializeField] private float m_rotAmount = 360.0f;
        [SerializeField] private float m_dieTime = 0.5f;
        [SerializeField] private Ease m_ease = Ease.Linear;

        private RectTransform m_canvas = null;
        private RectTransform m_thisRect = null;
        private AnimalCatchManager m_manager = null;
        private bool m_running = false;
        private bool m_mouseHover = false;
        private bool m_canRun = true;
        private int m_tweenId = -1;
        private bool m_dead = false;

        public void Construct(AnimalCatchManager manager , Sprite sprite)
        {
            GetComponent<Image>().sprite = sprite;
            GetComponent<Image>().SetNativeSize();

            m_manager = manager;
            m_thisRect = GetComponent<RectTransform>();
            m_canvas = m_manager.Canvas;
            
            transform.localScale = m_scale;

            m_thisRect.anchoredPosition = GetRandomPoint();
        }

        private void Update()
        {
            if(m_mouseHover)
                Run();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            m_mouseHover = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            m_mouseHover = false;
        }

        public void OnPointerClick(PointerEventData eventData)
        {           
            Die();
        }

        public void Run()
        {   
            if(m_running || !m_canRun)
                return;

            m_running = true;

            m_tweenId = PlatinioTween.instance.MoveUIAtSpeed( m_thisRect , new Vector2(Random.Range(0.01f, 0.98f), Random.Range(0.01f, 0.98f)) , m_canvas , m_speed).SetDelay(m_scapeTime).SetEase( m_ease ).SetOnComplete(delegate { m_running = false; }).id;
        }

        private void Die()
        {
            if(m_dead)
                return;

            m_dead = true;
            m_canRun = false;
            CancelTween();

            PlatinioTween.instance.RotateTween(transform, Vector3.forward, transform.rotation.eulerAngles.z + m_rotAmount, m_dieTime).SetEase(m_ease).SetOnComplete(delegate { Destroy(gameObject); });
            PlatinioTween.instance.ScaleTween(transform, Vector3.zero , m_dieTime).SetEase(m_ease);
            PlatinioTween.instance.ColorTween(GetComponent<Image>() , Color.red , 0.3f);

        }

        private Vector2 GetRandomPoint()
        {
            return m_thisRect.FromAbsolutePositionToAnchoredPosition(new Vector2( Random.Range(0.01f , 0.98f) , Random.Range(0.01f, 0.98f)) , m_canvas );
        }

        private void CancelTween()
        {
            if (m_tweenId != -1)
                PlatinioTween.instance.CancelTween(m_tweenId);
        }


    }

}

