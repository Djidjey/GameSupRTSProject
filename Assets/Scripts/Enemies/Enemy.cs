using UnityEngine;

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
#endregion

        // Health
        private int _currentHealthPoint = 0;
        
        private WayPointFollower _wayPointFollower;

        private void Awake()
        {
            _currentHealthPoint = _initialHealthPoint;
            _wayPointFollower = GetComponent<WayPointFollower>();
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

            if (_currentHealthPoint <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}
