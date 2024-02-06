using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

namespace Yuki.NPlayer
{
    public class DamageReceiver : CoreComp, IDamageable
    {
        private bool _canDamage;
        public bool CanDamage { get => _canDamage; set => _canDamage = value; }
        private Stats _stats;
        public event Action OnTakeDamage;

        public override void Awake()
        {
            base.Awake();

            _stats = _core.GetCoreComponent<Stats>();
            _canDamage = true;
        }
        public void Damage(float damage)
        {
            Debug.Log("Player is attacked!");
            if(_canDamage)
            {
                _stats.DecreaseHealth(damage);
                OnTakeDamage?.Invoke();
            }
        }
    }
}
