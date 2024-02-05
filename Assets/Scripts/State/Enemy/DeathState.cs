using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Yuki.NEnemy
{
    public class DeathState : EnemyState
    {
        public DeathState(Actor actor, string animName) : base(actor, animName)
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
            Debug.Log("Enemy died");
            Destroy(enemy.gameObject);
        }

        public override void Exit()
        {
            base.Exit();

            enemy.Event.OnAnimationFinished -= OnAnimationFinished;
        }
    }
}
