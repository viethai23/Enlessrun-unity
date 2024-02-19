using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Yuki.NPlayer
{
    public class JumpState : PlayerState
    {
        private int _amountOfJumpLeft;
        public int AmountOfJumpLeft => _amountOfJumpLeft;
        private float _yVelocity;
        private float _yInput;
        private bool _jumpInput;
        private bool _dashInput;
        private bool _attackInput;

        public JumpState(Actor actor, string animName) : base(actor, animName)
        {
        }

        public override void Enter()
        {
            base.Enter();

            SoundManager.Instance.CreatePlayFXSound(player.Sound.Data.JumpFXSound);
            player.Movement.SetGravity(player.Data.DefaultGravity);
            CheckInput();
            Jump();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (!isExitingState)
            {
                CheckInput();
                _yVelocity = player.Movement.CurrentVelocity.y;
                
                if (_attackInput && player.AttackState.CanAttack())
                {
                    player.FSM.ChangeState(player.AttackState);
                }
                else if (_jumpInput && CanJump())
                {
                    Jump();
                }
                else if (_dashInput && player.DashState.CanDash())
                {
                    player.FSM.ChangeState(player.DashState);
                }
                else if (_yVelocity < -0.01f)
                {
                    player.FSM.ChangeState(player.FallState);
                }
                else if(_yInput < 0)
                {
                    player.FSM.ChangeState(player.QuickFallState);
                }
            }
        }

        public override void Exit()
        {
            base.Exit();

            SoundManager.Instance.StopFXSound(player.Sound.Data.JumpFXSound);
        }

        private void CheckInput()
        {
            _yInput = player.Input.MovementInput.y;
            _attackInput = player.Input.AttackInput;
            _jumpInput = player.Input.JumpInput;
        }

        private void Jump()
        {
            player.Input.UseJumpInput();
            player.Movement.SetVelocity(new Vector2(player.Data.MoveSpeed, player.Data.JumpForce));
            _amountOfJumpLeft--;
        }

        public bool CanJump() => _amountOfJumpLeft > 0;

        public void DecreaseAmountOfJump() => _amountOfJumpLeft--;

        public void ResetAmountOfJump() => _amountOfJumpLeft = player.Data.AmountOfJumps;
    }
}
