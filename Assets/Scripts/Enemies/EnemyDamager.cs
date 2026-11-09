using System;
using UnityEngine;

namespace GS
{
    [RequireComponent(typeof(Collider))]
    public class EnemyDamager : MonoBehaviour
    {
        [SerializeField] private int _damagePoint;
        [SerializeField] private string _tag;

        private void Awake()
        {
            Collider collider = GetComponent<Collider>();
            collider.isTrigger = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log(other.gameObject.name);

            Enemy enemy = null;
            if (other.TryGetComponent(out enemy))
            {
                Debug.Log("Apply Damage");
                enemy.TakeDamage(_damagePoint);
            }
        }
    }
}
