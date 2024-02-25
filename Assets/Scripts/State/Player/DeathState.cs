using System;
using System.Collections;
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

            SoundManager.Instance.CreatePlayFXSound(player.Sound.Data.DeathFXSound, false);
            player.Movement.SetVelocityZero();
            player.Event.OnAnimationFinished += OnAnimationFinished;
        }

        private void OnAnimationFinished()
        {
            GameOverUI.Instance.GameOver();
        }

        public override void Exit()
        {
            base.Exit();

            player.Event.OnAnimationFinished -= OnAnimationFinished;
        }
    }
}
