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

            _detectingPlayerStartTime = Time.time;
            enemy.SetDangerousMark(true);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if(!isExitingState)
            {
                if(CheckIfDectectingPlayerEnd())
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
            }
        }

        private bool CheckIfDectectingPlayerEnd() => Time.time >= _detectingPlayerStartTime + enemy.Data.DetectingPlayerTime;
    }
}
