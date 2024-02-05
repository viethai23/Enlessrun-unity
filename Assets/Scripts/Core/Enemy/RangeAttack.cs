using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Yuki.NPlayer;

namespace Yuki.NEnemy
{
    public class RangeAttack : CoreComp
    {
        [SerializeField] private EnemyProjectile _projectile;
        [SerializeField] private Transform _projectileFirePos;
        private float _attackDamage;

        private void OnHitPlayer(GameObject player)
        {
            if(player.GetComponent<NPlayer.DamageReceiver>() != null)
            {
                player.GetComponent<NPlayer.DamageReceiver>().Damage(_attackDamage);
            }
        }

        public void Attack(float damage)
        {
            EnemyProjectile enemyProjectile = Instantiate(_projectile, _projectileFirePos.position, Quaternion.identity);
            enemyProjectile.OnHitPlayer += OnHitPlayer;
            _attackDamage = damage;
        }

    }
}
