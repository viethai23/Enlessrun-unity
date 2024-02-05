using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yuki.NEnemy
{
    public class IdleState : NormalState
    {
        public IdleState(Actor actor, string animName) : base(actor, animName)
        {
        }

    }
}
