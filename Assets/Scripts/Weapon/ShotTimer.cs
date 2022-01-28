using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SodaDefender
{
    public class ShotTimer : MonoBehaviour
    {
        [SerializeField, Range(0.1f, 1)] private float _shotInterval = 0.5f;
        [SerializeField] private UnityEvent OnShot;

        private WaitForSeconds _wait;

        private IEnumerator Timer() 
        {
            while (true)
            {
                OnShot.Invoke();
                yield return _wait;
            }
        }

        public void StartTimer()
        {
            _wait = new WaitForSeconds(_shotInterval);
            StartCoroutine(Timer());
        }
    }
}
