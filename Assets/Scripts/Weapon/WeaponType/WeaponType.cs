using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SodaDefender
{

    [CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
    public class WeaponType : ScriptableObject
    {
        [SerializeField] private int _damage;
        [SerializeField] private bool _shootRycasts = false;

        [SerializeField] private GameObject _bulletPrefab;

        public int Damage { get => _damage; }
        public bool ShootRycasts { get => _shootRycasts; }
        public GameObject BulletPrefab { get => _bulletPrefab; }
    }
}
