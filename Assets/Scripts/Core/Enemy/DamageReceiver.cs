using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yuki.NEnemy
{
    public class DamageReceiver : CoreComp, IDamageable
    {
        private Stats _stats;
        public Stats Stats
        {
            get => _stats ? _stats : _core.GetCoreComponent<Stats>();
        }
        public event Action OnTakeDamage;
        public void Damage(float damage)
        {
            Stats.DecreaseHealth(damage);
            OnTakeDamage?.Invoke();
        }
    }
}
