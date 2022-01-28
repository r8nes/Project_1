using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SodaDefender
{
    [CreateAssetMenu(fileName = "Level", menuName = "GameSO/Level")]
    public class LevelData : ScriptableObject
    {
        public List<Wave> Waves = new List<Wave>();
    }

    [System.Serializable]
    public class Wave 
    {
        public GameObject EnemyPrefab;

        [Range(1,100)]
        public int CountInWave;

        [Range(1,360)]
        public int WaitAfterWave;
    }
}
