using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platinio
{
    public class AnimalCatchManager : MonoBehaviour
    {
        [SerializeField] private Animal m_animalPrefab = null;
        [SerializeField] private List<Sprite> m_animalSprites = null;
        [SerializeField] private RectTransform m_canvas = null;
        [SerializeField] private int m_amount = 10;
        
        public RectTransform Canvas { get { return m_canvas; } }

        private void Start()
        {
            for (int n = 0 ; n < m_amount ; n++)
            {
                Animal clone = Instantiate(m_animalPrefab , m_canvas.transform);
                clone.transform.localScale = Vector3.one;

                clone.Construct(this);
            }
        }
        
    }

}

