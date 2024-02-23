using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Yuki.NPlayer
{
    public class QuickFallState : InAirState
    {
        public QuickFallState(Actor actor, string animName) : base(actor, animName)
        {
        }

        public override void Enter()
        {
            base.Enter();

            SoundManager.Instance.CreatePlayFXSound(player.Sound.Data.FastFallFXSound, false);

            //player.Movement.SetVelocityX(player.Data.MoveSpeed);
            player.Movement.SetGravity(player.Data.DefaultGravity * player.Data.FastFallGravityMutiplier);
        }
                                            
        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if(!isExitingState)
            {
                player.Movement.SetVelocityY(Mathf.Max(player.Movement.CurrentVelocity.y, -player.Data.MaxFastFallSpeed));
                PlaceAfterImage();
            }
        }

        public override void Exit()
        {
            base.Exit();

            SoundManager.Instance.StopFXSound(player.Sound.Data.FastFallFXSound);

        }
    }
}
