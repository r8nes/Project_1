using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SodaDefender
{
    public class EnergyShield : MonoBehaviour
    {
        private float _currentTime;
        private bool _isEnabled;
        
        private Transform _target;
     
        [SerializeField] private CircleCollider2D _collider;
        [SerializeField] private SpriteRenderer _spriteRenderer;

        public bool IsEnabled => _isEnabled;

        private void Update()
        {
            if (_isEnabled)
            {
                transform.position = _target.position;
            }
        }

        public void Activate(float liveTime, Transform target) 
        {
            _currentTime += liveTime;

            if (_isEnabled == false)
            {
                _target = target;
                transform.position = target.position;
                ShowShield(true);
                StartCoroutine(Timer());
            }
        }

        private void ShowShield(bool value) 
        {
            _collider.enabled = value;
            _spriteRenderer.enabled = value;
            _isEnabled = value;
        }

        private IEnumerator Timer() 
        {
            float waitAndStep = 0.5f;

            WaitForSeconds wait = new WaitForSeconds(0.5f);

            while (_currentTime > 0)
            {
                _currentTime -= waitAndStep;
                yield return wait;
            }

            _currentTime = 0;
            ShowShield(false);
            transform.SetParent(null);
        }
    }
}
