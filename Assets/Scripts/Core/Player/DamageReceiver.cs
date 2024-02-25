using DamageNumbersPro;
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
        [SerializeField] private DamageNumber _floatingDamageNumber;
        private bool _canDamage;
        public bool CanDamage { get => _canDamage; set => _canDamage = value; }
        private Stats _stats;
        public Collider2D Collider { get; private set; }
        public event Action OnTakeDamage;

        public override void Awake()
        {
            base.Awake();

            Collider = GetComponent<Collider2D>();
            _canDamage = true;
        }

        private void Start()
        {
            _stats = _core.GetCoreComponent<Stats>();
        }

        public void Damage(float damage)
        {
            if(_canDamage)
            {
                if(_stats.CurrentHealth > 0)
                {
                    DamageNumber floatingDamageNumberObject = Instantiate(_floatingDamageNumber, new Vector2(Collider.bounds.center.x, Collider.bounds.max.y), Quaternion.identity);
                    floatingDamageNumberObject.number = damage;
                }
                
                _stats.DecreaseHealth(damage);
                OnTakeDamage?.Invoke();
            }
        }
    }
}
