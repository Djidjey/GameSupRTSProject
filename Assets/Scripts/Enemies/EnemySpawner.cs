using TMPro;
using UnityEngine;

namespace GS
{
    public class EnemySpawner : MonoBehaviour
    {
        [Header("Path")]
        [SerializeField] private WaypointPath[] _path;
        
        [Header("Enemies")]
        [SerializeField] private GameObject _prefabEnemy;
        [SerializeField] private int _numberEnemyToSpawn;
        [SerializeField] private float _intervalTimeSpawn;
        
        [Header("UI")]
        [SerializeField] private HUD _HUD;
        
        private float _spawnTimer;
        private int _numberEnemySpawned;
        
        private void Start()
        {
            _spawnTimer = 0;
            _numberEnemySpawned = 0;
        }

        private void Update()
        {
            if (_numberEnemySpawned >= _numberEnemyToSpawn)
            {
                return;
            }
            
            _spawnTimer += Time.deltaTime;

            if (_spawnTimer > _intervalTimeSpawn)
            {
                _spawnTimer = 0;
                _numberEnemySpawned++;
                
                // Spawn enemy
                GameObject instanceEnemy = Instantiate(_prefabEnemy, Vector3.zero, Quaternion.identity);
                Enemy enemy = instanceEnemy.GetComponent<Enemy>();

                // Set random path
                int randomIndex = Random.Range(0, _path.Length);
                enemy.SetPath(_path[randomIndex]);
                
                // Update UI
                _HUD.IncreaseEnemyCount();
            }
        }
    }
}
