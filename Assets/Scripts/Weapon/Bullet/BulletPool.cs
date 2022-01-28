using System.Collections.Generic;
using UnityEngine;

namespace SodaDefender
{
    public class BulletPool : MonoBehaviour
    {
        private readonly Dictionary<string, List<GameObject>> _bullets = new Dictionary<string, List<GameObject>>();

        public void AddBullets(GameObject bulletPrefab, int count)
        {
            if (_bullets.ContainsKey(bulletPrefab.name) == false)
            {
                _bullets.Add(bulletPrefab.name, new List<GameObject>());
            }

            for (int i = 0; i < count; i++)
            {
                CreateBullet(bulletPrefab);
            }
        }

        private GameObject CreateBullet(GameObject bulletPrefab)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform);
            bullet.SetActive(false);
            _bullets[bulletPrefab.name].Add(bullet);

            return bullet;
        }

        public GameObject GetBullet(GameObject bulletPrefab)
        {
            if (_bullets.ContainsKey(bulletPrefab.name))
            {
                for (int i = 0; i < _bullets[bulletPrefab.name].Count; i++)
                {
                    if (_bullets[bulletPrefab.name][i].activeInHierarchy == false)
                    {
                        return _bullets[bulletPrefab.name][i];
                    }
                }
                return CreateBullet(bulletPrefab);
            }
            else
            {
                _bullets.Add(bulletPrefab.name, new List<GameObject>());
            }
            return CreateBullet(bulletPrefab);
        }
    }
}
