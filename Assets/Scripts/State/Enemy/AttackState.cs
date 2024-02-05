﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Yuki.NEnemy
{
    public class AttackState : EnemyState
    {
        private float _attackStartTime = -100;
        public AttackState(Actor actor, string animName) : base(actor, animName)
        {
        }

        public override void Enter()
        {
            base.Enter();

            enemy.Event.OnAnimationFinished += OnAnimationFinished;
            enemy.Event.OnAttack += OnAttack;
            _attackStartTime = Time.time;
        }

        private void OnAnimationFinished()
        {
            ChangeToNormalState();
        }

        protected virtual void OnAttack() { }

        protected void ChangeToNormalState()
        {
            if (enemy.Data.CanMove)
            {
                enemy.FSM.ChangeState(enemy.MoveState);
            }
            else
            {
                enemy.FSM.ChangeState(enemy.IdleState);
            }
        }

        public bool CanAttack() => Time.time >= _attackStartTime + enemy.Data.AttackCooldown;

        public override void Exit()
        {
            base.Exit();

            enemy.Event.OnAnimationFinished -= OnAnimationFinished;
            enemy.Event.OnAttack -= OnAttack;
        }
    }
}
