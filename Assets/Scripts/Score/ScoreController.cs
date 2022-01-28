using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SodaDefender
{
    public class ScoreController : MonoBehaviour
    {
        private static int _scoreCollected;

        [SerializeField] private UnityEvent<int> ScoreChanged;

        private void Awake()
        {
            ScoreChanged?.Invoke(_scoreCollected);
        }

        private void ChangeScore(int value) 
        {
            _scoreCollected += value;
            ScoreChanged?.Invoke(_scoreCollected);
        }

        private void OnEnable()
        {
            EntityScore.OnChanged += ChangeScore;
        }

        private void OnDisable()
        {
            EntityScore.OnChanged -= ChangeScore;
        }
    }
}
