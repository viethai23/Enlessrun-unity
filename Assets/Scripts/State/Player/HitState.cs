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

            SoundManager.Instance.CreatePlayFXSound(player.Sound.Data.HitFXSound);

            player.Movement.SetVelocityX(0);
            //player.Movement.SetGravity(player.Data.FallGravity * player.Data.FastFallGravityMutiplier * 100);
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

            SoundManager.Instance.StopFXSound(player.Sound.Data.HitFXSound);

            player.Event.OnAnimationFinished -= OnAnimationFinished;
        }
    }
}
