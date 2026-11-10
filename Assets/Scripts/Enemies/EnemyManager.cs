using System.Collections;
using UnityEngine;

namespace GS
{
    public class EnemyManager : MonoBehaviour
    {
        [Header("Path")]
        [SerializeField] private WaypointPath[] _path;
        
        [Header("Wave")]
        [SerializeField] private WaveData _wave;
        
        [Header("UI")]
        [SerializeField] private HUD _HUD;
        
        private void Start()
        {
            StartCoroutine(SpawnEnemiesCoroutine());
        }

        private IEnumerator SpawnEnemiesCoroutine()
        {
            for (int i = 0; i < _wave.NumberEnemyToSpawn; i++)
            {
                // Spawn enemy
                GameObject instanceEnemy = Instantiate(_wave.PrefabToSpawn[i], Vector3.zero, Quaternion.identity);
                Enemy enemy = instanceEnemy.GetComponent<Enemy>();

                // Set random path
                int randomIndex = Random.Range(0, _path.Length);
                enemy.SetPath(_path[randomIndex]);
                
                // Update UI
                _HUD.IncreaseEnemyCount();
                
                yield return new WaitForSeconds(_wave.SpawnIntervalInSeconds);
            }
        }
    }
}
