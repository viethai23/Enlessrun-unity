using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Yuki.NPlayer
{
    public class AttackState : PlayerState
    {
        private bool _isGrounded;
        private float _attackStartTime = -100;
        public AttackState(Actor actor, string animName) : base(actor, animName)
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

            SoundManager.Instance.CreatePlayFXSound(player.Sound.Data.AttackFXSound);
            player.Input.UseAttackInput();
            player.Event.OnAnimationFinished += OnAnimationFinished;
            player.Event.OnAttack += OnAttack;
            _attackStartTime = Time.time;
        }

        private void OnAttack()
        {
            player.RangeAttack.Attack(player.Data.AttackDamage);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if(!isExitingState)
            {
                player.Movement.SetVelocityX(player.Data.MoveSpeed);
            }
        }

        private void OnAnimationFinished()
        {
            if(_isGrounded)
            {
                player.FSM.ChangeState(player.RunState);
            }
            else
            {
                player.FSM.ChangeState(player.FallState);
            }
        }

        public bool CanAttack() => Time.time >= _attackStartTime + player.Data.AttackCooldown;

        public override void Exit()
        {
            base.Exit();

            SoundManager.Instance.StopFXSound(player.Sound.Data.AttackFXSound);

            player.Event.OnAnimationFinished -= OnAnimationFinished;
            player.Event.OnAttack -= OnAttack;
        }
    }
}
