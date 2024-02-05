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
            enemy.RangeAttack.Attack(enemy.Data.AttackDamage);
        }
    }
}
