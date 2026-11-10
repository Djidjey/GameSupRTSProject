using System.Collections;
using UnityEngine;

namespace GS
{
    public class EnemyManager : MonoBehaviour
    {
        [Header("Path")]
        [SerializeField] private WaypointPath[] _path;
        
        [Header("Enemies")]
        [SerializeField] private GameObject _prefabEnemy;
        [SerializeField] private int _numberEnemyToSpawn;
        [SerializeField] private float _intervalTimeSpawn;
        
        [Header("UI")]
        [SerializeField] private HUD _HUD;
        
        private void Start()
        {
            StartCoroutine(SpawnEnemiesCoroutine());
        }

        private IEnumerator SpawnEnemiesCoroutine()
        {
            for (int i = 0; i < _numberEnemyToSpawn; i++)
            {
                // Spawn enemy
                GameObject instanceEnemy = Instantiate(_prefabEnemy, Vector3.zero, Quaternion.identity);
                Enemy enemy = instanceEnemy.GetComponent<Enemy>();

                // Set random path
                int randomIndex = Random.Range(0, _path.Length);
                enemy.SetPath(_path[randomIndex]);
                
                // Update UI
                _HUD.IncreaseEnemyCount();
                
                yield return new WaitForSeconds(_intervalTimeSpawn);
                // i++
            }
            // no more enemy to spawn
            // stop
        }
    }
}
