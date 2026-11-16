using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GS
{
    public enum TowerState
    {
        Idle,
        Detecting,
        Targeting, 
        Attacking
    }
    
    public class Tower : MonoBehaviour
    {
        [SerializeField] private TowerData _towerData;
        [SerializeField] private LayerMask _layerMask;
        
        private TowerState _currentState = TowerState.Idle;
        private float _timerAttack;

        private List<Enemy> _allEnemies;
        private List<Enemy> _detectedEnemies;
        private List<Enemy> _targetedEnemies;

        private EnemyManager _enemyManager;

        private void Start()
        {
            _detectedEnemies = new List<Enemy>();
            _enemyManager = FindAnyObjectByType<EnemyManager>();
        }

        private void Update()
        {
            _timerAttack += Time.deltaTime;
            
            switch (_currentState)
            {
                case TowerState.Idle:
                    if (_timerAttack > _towerData.RatePerSeconds)
                    {
                        _timerAttack = 0;
                        _currentState = TowerState.Detecting;
                    }
                    break;
                case TowerState.Detecting:
                    _detectedEnemies = DetectEnemies();

                    if (_detectedEnemies.Count > 0)
                    {
                        _currentState = TowerState.Targeting;
                    }
                    else
                    {
                        _currentState = TowerState.Idle;
                    }
                    break;
                case TowerState.Targeting:
                    _targetedEnemies = new List<Enemy>();
                    _targetedEnemies = TargetEnemies(_detectedEnemies);

                    if (_targetedEnemies.Count > 0)
                    {
                        _currentState = TowerState.Attacking;
                    }
                    else
                    {
                        _currentState = TowerState.Idle;
                    }
                    break;
                case TowerState.Attacking:
                    Attack(_targetedEnemies);
                    _currentState = TowerState.Idle;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void Attack(List<Enemy> targetedEnemies)
        {
            foreach (Enemy targetedEnemy in targetedEnemies)
            {
                targetedEnemy.TakeDamage(_towerData.Damage);
            }
        }

        private List<Enemy> TargetEnemies(List<Enemy> detectedEnemies)
        {
            if (detectedEnemies.Count == 0) return null;

            List<Enemy> targetedEnemies = new List<Enemy>();
            
            switch (_towerData.TowerTargetingMode)
            {
                case TowerTargetingMode.FirstOnPath:
                    break;
                case TowerTargetingMode.ClosestOnPath:
                    Enemy closestEnemy = detectedEnemies[0];
                    float shortestDistance = Vector3.Distance(transform.position, closestEnemy.transform.position);

                    for (int i = 1; i < detectedEnemies.Count; i++)
                    {
                        float distance = Vector3.Distance(transform.position, detectedEnemies[i].transform.position);
                        if (distance < shortestDistance)
                        {
                            shortestDistance = distance;
                            closestEnemy = detectedEnemies[i];
                        }
                    }
                    
                    targetedEnemies.Add(closestEnemy);
                    
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
            return targetedEnemies;
        }

        private List<Enemy> DetectEnemies()
        {
            List<Enemy> enemies = new List<Enemy>();
            // method 1 : physic
            foreach (Collider collider in Physics.OverlapSphere(transform.position, _towerData.Range, _layerMask))
            {
                enemies.Add(collider.GetComponent<Enemy>());
            }
            
            // // method 2 : math
            // _allEnemies = _enemyManager.Active
            // foreach (Enemy enemy in _allEnemies)
            // {
            //     float distance = Vector3.Distance(enemy.transform.position, transform.position);
            //     if (distance <= _towerData.Range)
            //     {
            //         enemies.Add(enemy);
            //     }
            // }
            
            return enemies;
        }

        private void OnDrawGizmosSelected()
        {
            switch (_currentState)
            {
                case TowerState.Idle:
                    Gizmos.color = Color.grey;
                    break;
                case TowerState.Detecting:
                    Gizmos.color = Color.yellow;
                    break;
                case TowerState.Targeting:
                    Gizmos.color = Color.orange;
                    break;
                case TowerState.Attacking:
                    Gizmos.color = Color.red;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            Gizmos.DrawWireSphere(transform.position, _towerData.Range);

            if (_detectedEnemies != null && _currentState == TowerState.Detecting)
            {
                foreach (Enemy detectedEnemy in _detectedEnemies)
                {
                    Gizmos.DrawLine(transform.position, detectedEnemy.transform.position);
                }
            }

            if (_targetedEnemies != null && _currentState == TowerState.Targeting)
            {
                foreach (Enemy detectedEnemy in _targetedEnemies)
                {
                    Gizmos.DrawLine(transform.position, detectedEnemy.transform.position);
                }
            }
        }
    }
}


