using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Yuki.NPlayer
{
    public class FallState : InAirState
    {
        private float _coyoteTimeStart;
        
        public FallState(Actor actor, string animName) : base(actor, animName)
        {
        }

        public override void Enter()
        {
            base.Enter();

            player.Movement.SetGravity(player.Data.FallGravity);
            _coyoteTimeStart = Time.time;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (!isExitingState)
            {
                CheckCoyoteTime();
                player.Movement.SetVelocityY(Mathf.Max(player.Movement.CurrentVelocity.y, -player.Data.MaxFallSpeed));

                if (_attackInput && player.AttackState.CanAttack())
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
                else if (_yInput < 0)
                {
                    player.FSM.ChangeState(player.QuickFallState);
                }
            }
        }

        private void CheckCoyoteTime()
        {
            if (Time.time > _coyoteTimeStart + player.Data.CoyoteTime)
            {
                player.JumpState.DecreaseAmountOfJump();
            }
        }
    }
}
