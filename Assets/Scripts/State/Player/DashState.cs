using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Yuki.NPlayer
{
    public class PlayerDashState : PlayerState
    {
        private float _dashStartTime;
        private float _lastDashTime = -100f;
        private bool _isGrounded;

        public PlayerDashState(Actor actor, string animName) : base(actor, animName)
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

            player.Input.UseDashInput();
            player.DamageReceiver.CanDamage = false;
            player.Movement.SetVelocityZero();
            player.Movement.SetGravity(0.0f);
            player.Movement.SetVelocityX(player.Data.DashSpeed);
            _dashStartTime = Time.time;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if(!isExitingState)
            {
                PlaceAfterImage();
                if(CheckIfFinishedDash())
                {
                    _lastDashTime = Time.time;
                    if(_isGrounded)
                    {
                        player.FSM.ChangeState(player.RunState);
                    }
                    else
                    {
                        player.FSM.ChangeState(player.FallState);
                    }
                }
            }
        }

        public override void Exit()
        {
            base.Exit();

            player.DamageReceiver.CanDamage = true;
        }

        private bool CheckIfFinishedDash() => Time.time >= _dashStartTime + player.Data.DashDuration;

        public bool CanDash() => Time.time >= _lastDashTime + player.Data.DashCooldown;
    }
}
