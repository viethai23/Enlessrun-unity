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

            player.Movement.SetVelocityZero();
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
    }
}
