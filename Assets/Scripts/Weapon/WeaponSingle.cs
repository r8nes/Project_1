using UnityEngine;

namespace SodaDefender
{
    public class WeaponSingle : WeaponBase
    {
        [SerializeField] private Transform _bulletStartPosition;

        public override void Shot()
        {
                BulletActivate(_bulletStartPosition);
        }
    }
}
