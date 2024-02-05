using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Yuki.NPlayer
{
    public class RunState : PlayerState
    {
        private bool _isGrounded;
        private bool _jumpInput;
        private bool _dashInput;
        private bool _attackInput;
        public RunState(Actor actor, string animName) : base(actor, animName)
        {
        }

        public override void DoCheck()
        {
            base.DoCheck();

            _isGrounded = player.CollisionSenses.Grounded;
        }

        public override void Enter()
        {
            base.Enter();

            player.Movement.SetGravity(player.Data.DefaultGravity);
            player.JumpState.ResetAmountOfJump();
            CheckInput();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (!isExitingState)
            {
                CheckInput();
                player.Movement.SetVelocityX(player.Data.MoveSpeed);

                if(_attackInput && player.AttackState.CanAttack())
                {
                    player.FSM.ChangeState(player.AttackState);
                }
                else if (_jumpInput && player.JumpState.CanJump())
                {
                    player.FSM.ChangeState(player.JumpState);
                }
                else if (_dashInput && player.DashState.CanDash())
                {
                    player.FSM.ChangeState(player.DashState);
                }
                else if (!_isGrounded && player.Movement.CurrentVelocity.y < -0.01f)
                {
                    player.FSM.ChangeState(player.FallState);
                }
            }
        }

        private void CheckInput()
        {
            _jumpInput = player.Input.JumpInput;
            _dashInput = player.Input.DashInput;
            _attackInput = player.Input.AttackInput;
        }
    }
}
