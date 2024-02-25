using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yuki.NPlayer
{
    public class IdleState : PlayerState
    {
        public IdleState(Actor actor, string animName) : base(actor, animName)
        {
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if(!isExitingState)
            {
                if(GameManager.Instance.IsStartGame)
                {
                    player.FSM.ChangeState(player.RunState);
                }
            }
        }
    }
}
