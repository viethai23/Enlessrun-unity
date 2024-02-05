using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Yuki.NPlayer
{
    public class Input : MonoBehaviour
    {
        [SerializeField] private float _inputHoldTime = 0.2f;
        public Vector2 MovementInput { get; private set; }
        public bool JumpInput { get; private set; }
        public bool DashInput { get; private set; }
        public bool AttackInput { get; private set; }
       
        private float _jumpInputStartTime;
        private float _dashInputStartTime;
        private float _attackInputStartTime;

        private void Update()
        {
            CheckJumpInputHoldTime();
            CheckDashInputHoldTime();
            CheckAttackInputHoldTime();
        }

        public void OnMoveInput(InputAction.CallbackContext context)
        {
            MovementInput = context.ReadValue<Vector2>();
        }

        public void OnJumpInput(InputAction.CallbackContext context)
        {
            if(context.started)
            {
                JumpInput = true;
                _jumpInputStartTime = Time.time;
            }
        }

        public void OnDashInput(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                DashInput = true;
                _dashInputStartTime = Time.time;
            }
        }

        public void OnAttackInput(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                AttackInput = true;
                _attackInputStartTime = Time.time;
            }
        }

        public void UseJumpInput() => JumpInput = false;
        public void UseDashInput() => DashInput = false;
        public void UseAttackInput() => AttackInput = false;

        private void CheckJumpInputHoldTime()
        {
            if(Time.time >= _jumpInputStartTime + _inputHoldTime)
            {
                JumpInput = false;
            }
        }

        private void CheckDashInputHoldTime()
        {
            if (Time.time >= _dashInputStartTime + _inputHoldTime)
            {
                DashInput = false;
            }
        }

        private void CheckAttackInputHoldTime()
        {
            if (Time.time >= _attackInputStartTime + _inputHoldTime)
            {
                AttackInput = false;
            }
        }
    }
}
