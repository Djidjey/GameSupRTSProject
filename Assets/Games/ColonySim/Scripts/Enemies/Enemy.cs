using UnityEngine;

namespace CS
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private float _speed = 5f;
        [SerializeField] private int _healthPoint = 5;
        [SerializeField] private int _attackRange = 1;
        [SerializeField] private int _damage = 1;
        [SerializeField] private int _currencyValue = 10;
        
        private Transform _target;
        
        private void Start()
        {
            _target = LevelManager.Instance.ColonyManager.MainBaseBuilding.transform;
        }

        private void Update()
        {
            // Move to main base
            Vector3 direction = _target.position - transform.position;
            float distanceToTarget = direction.magnitude;
            Vector3 normalizedDirection = direction.normalized;
            
            transform.position += normalizedDirection * (_speed * Time.deltaTime);
            transform.rotation = Quaternion.LookRotation(normalizedDirection);
            
            // attack main base
            if (distanceToTarget <= _attackRange)
            {
                LevelManager.Instance.ColonyManager.MainBaseBuilding.TakeDamage(_damage);
                Die();
            }
        }

        private void Die()
        {
            LevelManager.Instance.EnemyManager.OnEnemyDeath(this);
            Destroy(gameObject);
        }

        public void TakeDamage(int damage)
        {
            _healthPoint -= damage;

            if (_healthPoint <= 0)
            {
                Die();
                LevelManager.Instance.AddCurrency(_currencyValue);
            }
        }
    }
}
