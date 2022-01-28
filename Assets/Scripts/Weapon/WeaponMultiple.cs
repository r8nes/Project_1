using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SodaDefender
{
    public class WeaponMultiple : WeaponBase
    {
        [SerializeField] private List<Transform> _bullets;

        public override void Shot()
        {
            foreach (var item in _bullets)
            {
                BulletActivate(item);
            }
        }
    }
}