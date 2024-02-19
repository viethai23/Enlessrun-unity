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

            enemy.Event.OnAnimationFinished -= OnAnimationFinished;
        }
    }
}
