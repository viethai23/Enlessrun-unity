using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Yuki.NPlayer;

namespace Yuki.NEnemy
{
    public class AttackMeleeState : AttackState
    {
        public AttackMeleeState(Actor actor, string animName) : base(actor, animName)
        {
        }

        public override void Enter()
        {
            base.Enter();

            SoundManager.Instance.CreatePlayFXSound(enemy.Sound.Data.AttackFXSound);
        }

        protected override void OnAttack()
        {
            enemy.MeleeAttack.Attack(enemy.Data.AttackDamage);
        }

        public override void Exit()
        {
            base.Exit();

            SoundManager.Instance.StopFXSound(enemy.Sound.Data.AttackFXSound);
        }

    }
}
