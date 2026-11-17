using System.Collections;
using UnityEngine;

namespace CS
{
    public class Building : MonoBehaviour
    {
        [SerializeField] private GameObject _view;
        [SerializeField] private float _spawnAnimationDuration;
        [SerializeField] private int _healthPoints;
        [SerializeField] private int _currencyCost;

        private Vector3 _initialScale;
        public int CurrencyCost => _currencyCost;
        
        private void Awake()
        {
            _initialScale = _view.transform.localScale;
        }

        private void Update()
        {
            
        }
        
        public IEnumerator SpawnAnimation(float timeBeforeAnimationStartInSeconds)
        {
            transform.localScale = Vector3.zero;

            yield return new WaitForSeconds(timeBeforeAnimationStartInSeconds);
            
            float timer = 0;
            while (timer < _spawnAnimationDuration)
            {
                transform.localScale = _initialScale * timer / _spawnAnimationDuration;
                timer += Time.deltaTime;
                yield return null;
            }
            
            transform.localScale = _initialScale;
        }

        public void TakeDamage(int damage)
        {
            _healthPoints -= damage;
        }
    }
}
