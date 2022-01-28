using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SodaDefender
{
    public class EntityScore : MonoBehaviour
    {
        private int _score;

        [SerializeField] private int _minValue;
        [SerializeField] private int _maxValue;

        public static event Action<int> OnChanged;

        private void OnEnable()
        {
            _score = UnityEngine.Random.Range(_minValue, _maxValue);
        }

        public void Activate() 
        {
            OnChanged?.Invoke(_score);
        }
    }
}
