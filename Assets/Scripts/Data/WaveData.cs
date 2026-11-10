using System.Collections.Generic;
using UnityEngine;

namespace GS
{
    [CreateAssetMenu(fileName = "WaveData", menuName = "Scriptable Objects/WaveData")]
    public class WaveData : ScriptableObject
    {
        [SerializeField] private List<GameObject> _prefabToSpawn;
        [SerializeField] private float _spawnIntervalInSeconds;
        
        public List<GameObject> PrefabToSpawn => _prefabToSpawn;
        public float SpawnIntervalInSeconds => _spawnIntervalInSeconds;
        public int NumberEnemyToSpawn => _prefabToSpawn.Count;
    }
}
