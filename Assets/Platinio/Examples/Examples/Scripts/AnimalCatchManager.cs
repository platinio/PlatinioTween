using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platinio
{
    public class AnimalCatchManager : MonoBehaviour
    {
        [SerializeField] private Animal animalPrefab = null;
        [SerializeField] private List<Sprite> animalSprites = null;
        [SerializeField] private RectTransform canvas = null;
        [SerializeField] private int amount = 10;
        
        public RectTransform Canvas { get { return canvas; } }

        private void Start()
        {
            for (int n = 0 ; n < amount ; n++)
            {
                Animal clone = Instantiate(animalPrefab , canvas.transform);
                
                clone.Construct(this , animalSprites[Random.Range(0 , animalSprites.Count)]);
            }
        }
        
    }

}

