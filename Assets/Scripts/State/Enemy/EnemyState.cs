using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yuki.NEnemy
{
    public class EnemyState : State
    {
        protected Enemy enemy;

        public EnemyState(Actor actor, string animName) : base(actor, animName)
        {
            if(actor is Enemy)
            {
                enemy = (Enemy)actor;
            }
        }

    }
}
