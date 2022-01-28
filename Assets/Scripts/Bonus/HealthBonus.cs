using UnityEngine;

namespace SodaDefender
{
    public class HealthBonus : BaseBonus
    {
        [SerializeField, Range(100, 1000)] private int _health;

        protected override void Activate(GameObject player)
        {
            if (player.TryGetComponent(out PlayerHealth health))
            {
                health.AddHealth(_health);
            }
        }
    }
}
