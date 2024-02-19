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

        public AudioClip AttackFXSound => _attackFXSound;
        public AudioClip DeathFXSound => _deathFXSound;
    }
}
