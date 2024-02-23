using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yuki.NEnemy
{
    public class AttackRangeState : AttackState
    {
        public AttackRangeState(Actor actor, string animName) : base(actor, animName)
        {
        }

        protected override void OnAttack()
        {
            SoundManager.Instance.CreatePlayFXSound(enemy.Sound.Data.AttackFXSound);
            enemy.RangeAttack.Attack(enemy.Data.AttackDamage);
        }

        public override void Exit()
        {
            base.Exit();

            SoundManager.Instance.StopFXSound(enemy.Sound.Data.AttackFXSound);
        }
    }
}
