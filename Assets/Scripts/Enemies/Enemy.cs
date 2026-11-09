using UnityEngine;
using UnityEngine.UI;

namespace GS
{
    [RequireComponent(typeof(WayPointFollower))]
    public class Enemy : MonoBehaviour
    {
#region SerializeFields
        [Header("Infos")] 
        [SerializeField] private string _enemyName;
        [SerializeField, TextArea(1, 5)] private string _enemyDescription;
        
        [Header("Health")]
        [SerializeField] private int _initialHealthPoint;

        [Header("UI")]
        [SerializeField] private Image _healthBarImage;
#endregion

        // Health
        private int _currentHealthPoint = 0;
        
        private WayPointFollower _wayPointFollower;

        private void Awake()
        {
            _currentHealthPoint = _initialHealthPoint;
            _wayPointFollower = GetComponent<WayPointFollower>();
            
            UpdateHealthBarUI();
        }

        private void Update()
        {
            
        }

        public void SetPath(WaypointPath waypointPath)
        {
            _wayPointFollower.SetPath(waypointPath);
        }

        public virtual void TakeDamage(int damage)
        {
            _currentHealthPoint -= damage;
            
            UpdateHealthBarUI();

            if (_currentHealthPoint <= 0)
            {
                Die();
            }
        }

        private void UpdateHealthBarUI()
        {
            _healthBarImage.fillAmount = _currentHealthPoint / (float)_initialHealthPoint;
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}
