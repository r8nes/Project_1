using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SodaDefender
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private UnityEvent OnCheckPoint;

        [Range(1f, 10f)]
        [SerializeField] private float _speed = 5f;

        [SerializeField] private Path _path;

        private Rigidbody2D _rigidbody;
        private int _index;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            _rigidbody.MovePosition(Vector3.MoveTowards(transform.position, _path.Points[_index], _speed * Time.fixedDeltaTime));

            MoveByWaypoint();
        }

        private void MoveByWaypoint()
        {
            if (Vector3.Distance(transform.position, _path.Points[_index]) < 0.01f)
            {
                if (_index < _path.Points.Count - 1)
                {
                    _index++;
                    OnCheckPoint.Invoke();
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
