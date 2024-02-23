using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Yuki
{
    [CreateAssetMenu(fileName = "PlayerProjectileData", menuName = "Data/Projectile/Player")]
    public class PlayerProjectileData : ProjectileData
    {
        [SerializeField] private GameObject _weaponCollisionVFX;
        [SerializeField] private AudioClip _weaponCollisionSound;

        public GameObject WeaponCollisionVFX => _weaponCollisionVFX;
        public AudioClip WeaponCollisionSound => _weaponCollisionSound;
    }
}
