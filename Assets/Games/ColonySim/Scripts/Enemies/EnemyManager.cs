using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CS
{
    public class EnemyManager : MonoBehaviour
    {
        private enum State
        {
            WaitingNextWave,
            SpawningWave,
            Over
        }
        
        [SerializeField] private Enemy _enemyPrefab;
        [SerializeField] private GameObject _enemySpawnerPrefab;
        [SerializeField] private int _waveCount;
        [SerializeField] private int _enemyCountPerWave;
        [SerializeField] private float _timeBetweenWaves;
        [SerializeField] private float _timeBetweenSpawns;

        private State _state;
        
        private List<Transform> _spawnPoint = new();
        
        private float _nextWaveTime;
        private float _nextSpawnTime;
        private int _enemySpawnedThisWaveCount;
        private int _waveSpawnedCount;

        private List<Enemy> _enemies = new();
        
        private void Awake()
        {
            _state = State.WaitingNextWave;
            _nextWaveTime = Time.time + _timeBetweenWaves;
            _nextSpawnTime = 0;
        }

        private void Update()
        {
            switch (_state)
            {
                case State.WaitingNextWave:
                    if (Time.time > _nextWaveTime)
                    {
                        _state = State.SpawningWave;
                        _nextSpawnTime = Time.time + _timeBetweenSpawns;
                    }
                    break;
                case State.SpawningWave:
                    if (Time.time > _nextSpawnTime)
                    {
                        SpawnEnemy();
                        _nextSpawnTime = Time.time + _timeBetweenSpawns;

                        if (_enemySpawnedThisWaveCount >= _enemyCountPerWave)
                        {
                            _waveSpawnedCount++;

                            if (_waveSpawnedCount >= _waveCount)
                            {
                                _state = State.Over;
                            }
                            else
                            {
                                _nextWaveTime = Time.time + _timeBetweenWaves;
                                _state = State.WaitingNextWave;
                            }
                        }
                    }
                    break;
                case State.Over:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void SpawnEnemy()
        {
            Vector3 spawnPoint = _spawnPoint[Random.Range(0, _spawnPoint.Count)].position;
            _enemySpawnedThisWaveCount++;
            Enemy instance = Instantiate(_enemyPrefab, spawnPoint, Quaternion.identity);
            _enemies.Add(instance);
        }

        public void CreateEnemySpawner(GridTile gridTile)
        {
            GameObject enemySpawnerPoint = Instantiate(_enemySpawnerPrefab, gridTile.transform.position, Quaternion.identity);
            _spawnPoint.Add(enemySpawnerPoint.transform);
        }

        public void OnEnemyDeath(Enemy enemy)
        {
            _enemies.Remove(enemy);
        }

        public List<Enemy> GetEnemiesAtRangeFromPosition(Vector3 position, float attackRange)
        {
            List<Enemy> enemies = new();
            foreach (Enemy enemy in _enemies)
            {
                float distance = Vector3.Distance(position, enemy.transform.position);
                if (distance < attackRange)
                {
                    enemies.Add(enemy);
                }
            }

            return enemies;
        }
    }
}
