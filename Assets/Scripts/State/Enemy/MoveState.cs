using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yuki.NEnemy;

namespace Yuki
{
    public class MoveState : EnemyState
    {
        public MoveState(Actor actor, string animName) : base(actor, animName)
        {
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if(!isExitingState)
            {
                enemy.Movement.Move(enemy.Data.MoveSpeed);
            }
        }
    }
}
