using UnityEngine;
using UnityEngine.Events;

namespace SodaDefender
{
    [RequireComponent(typeof(CircleCollider2D))]
    public abstract class BaseBonus : MonoBehaviour
    {
        private const float SPEED = 5f;

        [SerializeField] private UnityEvent Activated;
        
        private void Update()                                                           
        {
            transform.Translate(Vector3.down * SPEED * Time.deltaTime);

            if (transform.position.y < -12)
            {
                gameObject.SetActive(false);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out PlayerMove playerMove))
            {
                Activate(playerMove.gameObject);
                Activated.Invoke();
                gameObject.SetActive(false);
            }
        }

        protected virtual void Activate(GameObject player)
        {}
    }
}