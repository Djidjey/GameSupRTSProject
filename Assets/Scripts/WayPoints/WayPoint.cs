using System;
using UnityEngine;

namespace GS
{
    public class WayPoint : MonoBehaviour
    {
        private void Start()
        {
        }

        private void Update()
        {

        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, 0.5f);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(transform.position, 1.0f);
        }
    }
}