using UnityEngine;
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
    }
}