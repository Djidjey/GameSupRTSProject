using UnityEngine;

namespace GS
{
    public class Enemy : MonoBehaviour
    {
#region Constants
        private const int FIRST_WAYPOINT_INDEX = 0;
#endregion
        
#region SerializeFields
        [Header("Infos")] 
        [SerializeField] private string _enemyName;
        [SerializeField, TextArea(1, 5)] private string _enemyDescription;
        
        [Header("Health")]
        [SerializeField] private int _initialHealthPoint;
        
        [Header("Movement")]
        [SerializeField]
        [Tooltip("Base speed when moving, must be a positive value")]
        [Min(0)]
        private float _speed;
        [SerializeField]
        [Tooltip("Distance to waypoint to change next way point"), Range(0, 5)]
        protected float _distanceToStop;
#endregion
        
        // Members
        // Waypoints
        private WaypointPath _waypointPath;
        private int _nextWayPointIndex;
        private int _waypointCount;

        // Health
        private int _currentHealthPoint = 0;

        private void Awake()
        {
            _currentHealthPoint = _initialHealthPoint;
        }
        
        private void Start()
        {
            // Set position at path start
            WayPoint firstWayPoint = _waypointPath.GetWayPoint(FIRST_WAYPOINT_INDEX);
            transform.position = firstWayPoint.transform.position;
            
            // Setup data
            _nextWayPointIndex = FIRST_WAYPOINT_INDEX + 1;
            _waypointCount = _waypointPath.GetWaypointCount();
        }

        private void Update()
        {
            Vector3 nextWaypointPosition = _waypointPath.GetWayPoint(_nextWayPointIndex).transform.position;
            
            // Move to next waypoint
            Vector3 direction = nextWaypointPosition - transform.position;
            Vector3 normalizedDirection = direction.normalized;
            transform.position += normalizedDirection * (_speed * Time.deltaTime);
            
            // If waypoint reached -> go to next waypoint
            if (IsAtWaypoint(nextWaypointPosition))
            {
                _nextWayPointIndex++;
            }

            // If path is over
            if (_nextWayPointIndex >= _waypointCount)
            {
                Destroy(this.gameObject);
            }
        }

        protected virtual bool IsAtWaypoint(Vector3 nextWaypointPosition)
        {
            float distanceToWaypoint = Vector3.Distance(transform.position, nextWaypointPosition);
            if (distanceToWaypoint < _distanceToStop)
            {
                return true;
            }

            return false;
        }

        public void SetPath(WaypointPath waypointPath)
        {
            _waypointPath = waypointPath;
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
