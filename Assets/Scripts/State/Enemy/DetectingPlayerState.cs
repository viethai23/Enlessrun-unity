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

            SoundManager.Instance.CreatePlayFXSound(enemy.Sound.Data.DetectingPlayerFXSound, false);
            enemy.SetDangerousMark(true);
            _detectingPlayerStartTime = Time.time;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if(!isExitingState)
            {
                if(CheckIfPlayerDetectingFinished())
                {
                    OnPlayerDetectingFinished();
                }
            }
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

        private bool CheckIfPlayerDetectingFinished() => Time.time > _detectingPlayerStartTime + enemy.Data.MaxDetectTime;

        public override void Exit()
        {
            base.Exit();

            SoundManager.Instance.StopFXSound(enemy.Sound.Data.DetectingPlayerFXSound);
        }
    }
}
