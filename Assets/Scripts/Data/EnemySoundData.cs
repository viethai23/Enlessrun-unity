using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Yuki
{
    [CreateAssetMenu(fileName = "Enemy", menuName = "Data/Sound/Enemy")]
    public class EnemySoundData : ScriptableObject
    {
        [SerializeField] private AudioClip _attackFXSound;
        [SerializeField] private AudioClip _deathFXSound;
        [SerializeField] private AudioClip _hitFXSound;
        [SerializeField] private AudioClip _detectingPlayerFXSound;

        public AudioClip AttackFXSound => _attackFXSound;
        public AudioClip DeathFXSound => _deathFXSound;
        public AudioClip HitFXSound => _hitFXSound;
        public AudioClip DetectingPlayerFXSound => _detectingPlayerFXSound;
    }
}
