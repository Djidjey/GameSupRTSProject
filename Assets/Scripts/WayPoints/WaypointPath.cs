using System.Collections.Generic;
using UnityEngine;

namespace GS
{
    public class WaypointPath : MonoBehaviour
    {
        [SerializeField] private WayPoint[] _wayPoints;
        
        private void Start()
        {
            
        }

        private void Update()
        {
            
        }

        public WayPoint GetWayPoint(int index)
        {
            return _wayPoints[index];
        }

        private void OnDrawGizmos()
        {
            for (int i = 0; i < _wayPoints.Length - 1; i++)
            {
                Gizmos.DrawLine(_wayPoints[i].transform.position, _wayPoints[i + 1].transform.position);
            }
        }

        public int GetWaypointCount()
        {
            return _wayPoints.Length;
        }
    }
}
