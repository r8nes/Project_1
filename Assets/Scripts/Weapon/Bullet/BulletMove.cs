using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SodaDefender
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class BulletMove : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField, Range(5, 50)] private float _speed = 25f;

        public void FixedUpdate()
        {
            _rigidbody.velocity = transform.up * _speed;
        }
    }
}