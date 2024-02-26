using DamageNumbersPro;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yuki.NEnemy
{
    public class DamageReceiver : CoreComp, IDamageable
    {
        [SerializeField] private DamageNumber _floatingDamageNumber;
        private Stats _stats;

        public Collider2D Collider { get; private set; }
        public event Action OnTakeDamage;

        public override void Awake()
        {
            base.Awake();

            Collider = GetComponent<Collider2D>();
        }

        private void Start()
        {
            _stats = _core.GetCoreComponent<Stats>();

        }

        public void Damage(float damage)
        {
            if(_stats.CurrentHealth > 0)
            {
                DamageNumber floatingDamageNumberObject = Instantiate(_floatingDamageNumber, new Vector2(Collider.bounds.center.x, Collider.bounds.max.y), Quaternion.identity);
                floatingDamageNumberObject.number = damage;
                _stats.DecreaseHealth(damage);
                OnTakeDamage?.Invoke();
            }
        }

        public void DisableCollider()
        {
            Collider.enabled = false;
        }
    }
}
