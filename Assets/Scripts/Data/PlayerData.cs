using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Yuki
{
    [CreateAssetMenu(fileName = "Player", menuName = "Data/Player")]
    public class PlayerData : Data
    {
        [SerializeField] private float _defaultGravity = 5.0f;
        [SerializeField] private float _jumpForce = 12.0f;
        [SerializeField] private int _amountOfJumps = 2;
        [SerializeField] private float _fallGravity = 8.0f;
        [SerializeField] private float _maxFallSpeed = 18.0f;
        [SerializeField] private float _fastFallGravityMutiplier = 2.0f;
        [SerializeField] private float _maxFastFallSpeed = 30.0f;
        [SerializeField] private float _coyoteTime = 0.2f;
        [SerializeField] private float _dashSpeed = 8.0f;
        [SerializeField] private float _dashDuration = 0.5f;
        [SerializeField] private float _dashCooldown = 0.2f;

        public float DefaultGravity => _defaultGravity;
        public float JumpForce => _jumpForce;
        public float FallGravity => _fallGravity;
        public int AmountOfJumps => _amountOfJumps;
        public float MaxFallSpeed => _maxFallSpeed;
        public float FastFallGravityMutiplier => _fastFallGravityMutiplier;
        public float MaxFastFallSpeed => _maxFastFallSpeed;
        public float CoyoteTime => _coyoteTime;
        public float DashSpeed => _dashSpeed;
        public float DashDuration => _dashDuration;
        public float DashCooldown => _dashCooldown;
    }
}
