using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yuki.NPlayer;

namespace Yuki.NEnemy
{
    public class HitState : EnemyState
    {
        public HitState(Actor actor, string animName) : base(actor, animName)
        {
        }

        public override void Enter()
        {
            base.Enter();

            SoundManager.Instance.CreatePlayFXSound(enemy.Sound.Data.HitFXSound, false);
            enemy.SetDangerousMark(false);
            enemy.Event.OnAnimationFinished += OnAnimationFinished;
        }

        private void OnAnimationFinished()
        {
            enemy.FSM.ChangeState(enemy.IdleState);
        }

        public override void Exit()
        {
            base.Exit();

            SoundManager.Instance.StopFXSound(enemy.Sound.Data.HitFXSound);
            enemy.Event.OnAnimationFinished -= OnAnimationFinished;
        }
    }
}
