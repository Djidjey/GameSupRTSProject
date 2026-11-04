using UnityEngine;

namespace GS
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private Path _path;
        [SerializeField] private float _speed;
        [SerializeField] private float _distanceToStop;
        
        private int _nextWayPointIndex;
        private int _waypointCount;
        private const int FIRST_WAYPOINT_INDEX = 0;
        
        private void Start()
        {
            WayPoint firstWayPoint = _path.GetWayPoint(FIRST_WAYPOINT_INDEX);
            transform.position = firstWayPoint.transform.position;
            
            _nextWayPointIndex = FIRST_WAYPOINT_INDEX + 1;

            _waypointCount = _path.GetWaypointCount();
        }

        private void Update()
        {
            Vector3 nextWaypointPosition = _path.GetWayPoint(_nextWayPointIndex).transform.position;
            
            // Move to next waypoint
            Vector3 direction = nextWaypointPosition - transform.position;
            Vector3 normalizedDirection = direction.normalized;
            transform.position += normalizedDirection * _speed * Time.deltaTime;
            
            // If waypoint reached -> go to next waypoint
            float distanceToWaypoint = Vector3.Distance(transform.position, nextWaypointPosition);
            if (distanceToWaypoint < _distanceToStop)
            {
                _nextWayPointIndex += 1;
            }
            
            // If path is over
            if (_nextWayPointIndex >= _waypointCount)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
