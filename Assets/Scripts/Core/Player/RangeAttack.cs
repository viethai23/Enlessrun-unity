using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Yuki.NEnemy;

namespace Yuki.NPlayer
{
    public class RangeAttack : CoreComp
    {
        [SerializeField] private PlayerProjectile _projectile;
        [SerializeField] private Transform _projectileFirePos;
        private float _attackDamage;

        private void OnHitEnemy(GameObject enemy)
        {
            if (enemy.GetComponent<NEnemy.DamageReceiver>() != null)
            {
                enemy.GetComponent<NEnemy.DamageReceiver>().Damage(_attackDamage);
            }
            else
            {
            }
        }

        public void Attack(float damage)
        {
            PlayerProjectile projectilePrefab = Instantiate(_projectile, _projectileFirePos.position, Quaternion.identity);
            projectilePrefab.OnHitEnemy += OnHitEnemy;
            _attackDamage = damage;
        }
    }
}
