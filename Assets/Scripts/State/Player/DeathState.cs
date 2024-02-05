using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Yuki.NPlayer
{
    public class DeathState : PlayerState
    {
        public DeathState(Actor actor, string animName) : base(actor, animName)
        {
        }

        public override void Enter()
        {
            base.Enter();

            Debug.Log("Player die state");
            player.Movement.SetVelocityZero();
            
        }
    }
}
