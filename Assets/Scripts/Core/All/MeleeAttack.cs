using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Yuki
{
    public class MeleeAttack : CoreComp
    {
        [SerializeField] private Transform _meleeAttackCheck;
        [SerializeField] private Vector2 _meleeAttackCheckSize;
        [SerializeField] private LayerMask _whatIsDamageable;

        public void Attack(float damage)
        {
            Collider2D[] colliders = Physics2D.OverlapBoxAll(_meleeAttackCheck.position, _meleeAttackCheckSize, 0, _whatIsDamageable);

            foreach (Collider2D item in colliders)
            {
                if (item.TryGetComponent(out IDamageable damageable))
                {
                    damageable.Damage(damage);
                }
            }
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(_meleeAttackCheck.position, _meleeAttackCheckSize);
        }
#endif
    }
}
