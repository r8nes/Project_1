using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SodaDefender
{
    public class EnemyWaves : MonoBehaviour
    {
        private int _indexWave;
        private int _indexEnemy;

        private LevelData _level;

        private List<GameObject> _enemies = new List<GameObject>();

        private void Awake()
        {
            // TODO: Use map scene to change index 
            int index = 2;
            /*new LevelNameData().GetLevelIndex();*/
            _level = Resources.Load<LevelData>($"Levels/Level{index}");
        }

        public void Generate()
        {
            int offset = 2;
            Vector2 startPosition = new Vector2(0, new SafeAreaData().GetMax().y + offset);

            foreach (Wave wave in _level.Waves)
            {
                for (int i = 0; i < wave.CountInWave; i++)
                {
                    GameObject enemy = Instantiate(wave.EnemyPrefab, transform);
                    enemy.transform.position = startPosition;
                    enemy.SetActive(false);
                    _enemies.Add(enemy);
                }
            }    
        }
        public void Activate() 
        {
            StartCoroutine(EnemyActivate());
        }

        private IEnumerator EnemyActivate()
        {
            WaitForSeconds wait = new WaitForSeconds(0.5f);
            var count = _level.Waves[_indexWave].CountInWave;

            while (count > 0)
            {
                count--;
                _enemies[_indexEnemy].gameObject.SetActive(true);
                _indexEnemy++;
                yield return wait;
            }

            if (_indexWave < _level.Waves.Count - 1)
            {
                Invoke(nameof(Activate), _level.Waves[_indexWave].WaitAfterWave);
                _indexWave++;
            }
        }

    }
}
