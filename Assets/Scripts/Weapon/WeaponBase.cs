using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SodaDefender
{
    public abstract class WeaponBase : MonoBehaviour, IShootable
    {
        [Range(0, 20)]
        [SerializeField] private int _bulletsCount;
        
        [SerializeField] private WeaponType _weaponType;

        protected BulletPool _bulletsPool;

        private void OnEnable()
        {

            if (_bulletsPool == null)
            {
                _bulletsPool = FindObjectOfType<BulletPool>();
            }

            if (_bulletsCount > 0)
            {
                _bulletsPool.AddBullets(_weaponType.BulletPrefab, _bulletsCount);
            }
        }

        protected void BulletActivate(Transform bulletStartPosition) 
        {
            var bullet = _bulletsPool.GetBullet(_weaponType.BulletPrefab);
            bullet.transform.position = bulletStartPosition.position;
            bullet.transform.Rotate(transform.rotation.eulerAngles);
            bullet.SetActive(true);
        }
    
        public abstract void Shot();
    }
}
