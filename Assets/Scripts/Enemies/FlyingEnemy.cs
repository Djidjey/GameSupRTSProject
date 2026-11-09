using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

namespace GS
{
    public class FlyingEnemy : Enemy
    {
        [SerializeField] private float _yOffset;

        private void LateUpdate()
        {
            transform.position = new Vector3(transform.position.x, _yOffset, transform.position.z);
        }

        protected override bool IsAtWaypoint(Vector3 nextWaypointPosition)
        {
            return Vector2.Distance(new Vector2(transform.position.x, transform.position.z),
                new Vector2(nextWaypointPosition.x, nextWaypointPosition.z)) < _distanceToStop;
        }
    }
}