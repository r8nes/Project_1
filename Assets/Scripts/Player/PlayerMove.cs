using System;
using UnityEngine;

namespace SodaDefender
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMove : MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;

        [SerializeField] private float _speed = 3f;
        [SerializeField] private DynamicJoystick _joystick;

        private Vector2 _direction = Vector2.zero;

        public static event Action<bool> OnJoystickTouch;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            if (_joystick.Horizontal !=0 || _joystick.Vertical !=0)
            {
                _direction.x = _joystick.Horizontal;
                _rigidbody2D.MovePosition(_rigidbody2D.position + _speed * Time.fixedDeltaTime * _direction);
            }
            else
            {
                _rigidbody2D.velocity = Vector2.zero;
            }
        }

        public void GetActiveJoystick()
        {
            Transform activeSegment = _joystick.transform.GetChild(0);
            IShootable weapon = GetComponent<IShootable>();

            if (activeSegment.gameObject.activeInHierarchy)
            {
                weapon.Shot();
            }
        }
    }
}
