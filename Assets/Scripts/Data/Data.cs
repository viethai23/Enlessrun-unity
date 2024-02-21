using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Yuki
{
    public class Data : ScriptableObject
    {
        [SerializeField] private float _attackDamage = 1f;
        [SerializeField] private float _attackCooldown = 0.2f;

        public float AttackDamage => _attackDamage;
        public float AttackCooldown => _attackCooldown;
    }
}
