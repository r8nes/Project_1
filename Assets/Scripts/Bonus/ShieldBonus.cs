using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SodaDefender
{
    public class ShieldBonus : BaseBonus
    {
        [SerializeField] private EnergyShield _energyPrefab;
        [SerializeField] private float _liveTime = 2.5f;

        private static EnergyShield _currentShield;

        private void CheckShield()
        {
            if (_currentShield == null)
            {
                _currentShield = Instantiate(_currentShield);
            }
        }

        protected override void Activate(GameObject player)
        {
            CheckShield();

            _currentShield.Activate(_liveTime, player.transform);
        }
    }
}
