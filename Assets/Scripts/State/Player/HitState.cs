using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yuki.NPlayer
{
    public class HitState : PlayerState
    {
        private bool _isGrounded;
        public HitState(Actor actor, string animName) : base(actor, animName)
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

            player.Event.OnAnimationFinished += OnAnimationFinished;
        }

        private void OnAnimationFinished()
        {
            if (_isGrounded)
            {
                player.FSM.ChangeState(player.RunState);
            }
            else
            {
                player.FSM.ChangeState(player.FallState);
            }
        }
        
        public override void Exit()
        {
            base.Exit();

            player.Event.OnAnimationFinished -= OnAnimationFinished;
        }
    }
}
