using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Yuki.NEnemy
{
    public class DetectingPlayerState : EnemyState
    {
        private float _detectingPlayerStartTime;
        public DetectingPlayerState(Actor actor, string animName) : base(actor, animName)
        {
        }

        public override void Enter()
        {
            base.Enter();

            enemy.SetDangerousMark(true);
            enemy.PlayerDetecting.OnPlayerDetectingFinished += OnPlayerDetectingFinished;
            _detectingPlayerStartTime = Time.time;
        }

        private void OnPlayerDetectingFinished()
        {
            enemy.SetDangerousMark(false);
            if (enemy.Data.CanMeleeAttack && enemy.AttackMeleeState.CanAttack())
            {
                enemy.FSM.ChangeState(enemy.AttackMeleeState);
            }
            else if (enemy.Data.CanRangeAttack && enemy.AttackRangeState.CanAttack())
            {
                enemy.FSM.ChangeState(enemy.AttackRangeState);
            }
        }

        public override void Exit()
        {
            base.Exit();

            enemy.PlayerDetecting.OnPlayerDetectingFinished -= OnPlayerDetectingFinished;
        }

    }
}
