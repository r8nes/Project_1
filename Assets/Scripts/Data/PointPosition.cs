using UnityEngine;

namespace SodaDefender
{
    public class PointPosition
    {
        private Vector2 _position;
        private float _offsetY;
        private const float MULTIPLIER = 3.5f;

        public PointPosition() 
        {
            SafeAreaData safeArea = new SafeAreaData();
            _position = safeArea.GetMin();
            _offsetY = _position.x / MULTIPLIER;
        }

        public Vector2 GetNextPosition() 
        {
            _position.x = _offsetY;
            _position.y += Mathf.Abs(_offsetY);
            _offsetY = -_offsetY;

            return _position;
        }
    }   
}
