using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yuki.NEnemy
{
    public class IdleState : EnemyState
    {
        public IdleState(Actor actor, string animName) : base(actor, animName)
        {
        }

        public override void Enter()
        {
            base.Enter();

            enemy.PlayerDetecting.OnPlayerDetecting += OnPlayerDetecting;
        }

        private void OnPlayerDetecting()
        {
            enemy.FSM.ChangeState(enemy.DetectingPlayerState);
        }

        public override void Exit()
        {
            base.Exit();

            enemy.PlayerDetecting.OnPlayerDetecting -= OnPlayerDetecting;
        }
    }
}
