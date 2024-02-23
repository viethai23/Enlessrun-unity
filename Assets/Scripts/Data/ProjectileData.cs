using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Yuki
{
    [CreateAssetMenu(fileName = "ProjectileData", menuName = "Data/Projectile/Enemy")]
    public class ProjectileData : ScriptableObject
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _maxExistTime;
        [SerializeField] private float _damageAdd;
        [SerializeField] private GameObject _damageCollisionVFX;

        public float Speed => _speed;
        public float MaxExistTime => _maxExistTime;
        public float DamageAdd => _damageAdd;
        public GameObject DamageCollisionVFX => _damageCollisionVFX;
    }
}
