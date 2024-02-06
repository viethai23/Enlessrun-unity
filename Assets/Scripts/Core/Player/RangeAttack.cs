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
        [SerializeField] private Transform _projectileFirePos;
        private float _attackDamage;

        private Inventory _inventory;

        private void Start()
        {
            _inventory = _core.GetCoreComponent<Inventory>();
        }

        private void OnHitEnemy(GameObject enemy, float damageAdd)
        {
            enemy.GetComponent<NEnemy.DamageReceiver>().Damage(_attackDamage + damageAdd);
        }

        public void Attack(float damage)
        {
            PlayerProjectile projectilePrefab = Instantiate(_inventory.GetCurrentWeapon(), _projectileFirePos.position, Quaternion.identity);
            projectilePrefab.OnHitEnemy += OnHitEnemy;
            _attackDamage = damage;
        }
    }
}
