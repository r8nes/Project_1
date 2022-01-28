using UnityEngine;
using UnityEngine.Events;

namespace SodaDefender
{
    public sealed class PlayerHealth : EntityHealth
    {
        [SerializeField] private UnityEvent<int> OnChangedHealth;

        protected override void OnEnable()
        {
            base.OnEnable();
            OnChangedHealth?.Invoke(GetCurrentHealth());
        }

        public override void TakeDamage(int value)
        {
            base.TakeDamage(value);
            OnChangedHealth?.Invoke(GetCurrentHealth());
        }

        public void PrintHealth()
        {
            Debug.Log(GetCurrentHealth() );
        }
    }
}