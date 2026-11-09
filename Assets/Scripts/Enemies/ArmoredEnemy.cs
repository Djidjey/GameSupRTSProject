using UnityEngine;

namespace GS
{
    public class ArmoredEnemy : Enemy
    {
        [Header("Armor")]
        [SerializeField][Range(0.1f, 0.75f)] private float _armorPercentage;

        public override void TakeDamage(int damage)
        {
            damage = Mathf.FloorToInt(damage * _armorPercentage);
            
            base.TakeDamage(damage);
        }
    }
}
