using UnityEngine;

namespace SodaDefender
{
    public class PlayerStartPosition : MonoBehaviour
    {
        private const float Offset = 2f;

        private void Start()
        {
            SetPosition();
        }

        private void SetPosition()
        {
            float position = new SafeAreaData().GetMin().y + Offset;
            Vector2 startPosition = new Vector2(transform.position.x, position);
            transform.position = startPosition;

            if (transform.position.y < startPosition.y)
            {
                transform.position = new Vector2(transform.position.x, position + (Offset * 3f));
            }
        }
    }
}
