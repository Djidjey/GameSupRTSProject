using System.Collections.Generic;
using UnityEngine;

namespace CS
{
    public class AttackBuilding : Building
    {
        [SerializeField] private int _damage;
        [SerializeField] private float _attackRange;
        [SerializeField] private float _timeBetweenAttacksInSeconds;

        private float _nextAttackTime;

        private EnemyManager _enemyManager;
        
        private void Start()
        {
            _nextAttackTime = Time.time + _timeBetweenAttacksInSeconds;
            _enemyManager = LevelManager.Instance.EnemyManager;
        }

        private void Update()
        {
            if (Time.time > _nextAttackTime)
            {
                // Detect enemies
                List<Enemy> detectedEnemies = _enemyManager.GetEnemiesAtRangeFromPosition(transform.position, _attackRange);
                
                // Select enemies
                float shortestDistance = Mathf.Infinity;
                Enemy targetEnemy = null;
                foreach (Enemy detectedEnemy in detectedEnemies)
                {
                    float distance = Vector3.Distance(transform.position, detectedEnemy.transform.position);
                    if (distance < shortestDistance)
                    {
                        shortestDistance = distance;
                        targetEnemy = detectedEnemy;
                    }
                }
                
                // Attack enemies
                if (targetEnemy != null)
                {
                    targetEnemy.TakeDamage(_damage);
                }
                
                _nextAttackTime = Time.time + _timeBetweenAttacksInSeconds;
            }
        }
    }
}
