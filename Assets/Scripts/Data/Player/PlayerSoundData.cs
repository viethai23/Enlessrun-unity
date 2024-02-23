using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Yuki
{
    [CreateAssetMenu(fileName = "PlayerSound", menuName = "Data/Sound/Player")]
    public class PlayerSoundData : ScriptableObject
    {
        [SerializeField] private AudioClip _runFXSound;
        [SerializeField] private AudioClip _jumpFXSound;
        [SerializeField] private AudioClip _attackFXSound;
        [SerializeField] private AudioClip _hitFXSound;
        [SerializeField] private AudioClip _dashFXSound;
        [SerializeField] private AudioClip _fastFallFXSound;
        [SerializeField] private AudioClip _upgradeWeaponFXSound;

        public AudioClip RunFXSound => _runFXSound;
        public AudioClip JumpFXSound => _jumpFXSound;
        public AudioClip AttackFXSound => _attackFXSound;
        public AudioClip HitFXSound => _hitFXSound;
        public AudioClip DashFXSound => _dashFXSound;
        public AudioClip FastFallFXSound => _fastFallFXSound;
        public AudioClip UpgradeWeaponFXSound => _upgradeWeaponFXSound;
    }
}
