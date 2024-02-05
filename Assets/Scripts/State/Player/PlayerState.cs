using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.SocialPlatforms.Impl;

namespace Yuki.NPlayer
{
    public class PlayerState : State
    {
        protected Player player;

        public PlayerState(Actor actor, string animName) : base(actor, animName)
        {
            if(actor is  Player)
            {
                player = (Player) actor;
            }
        }

        protected void PlaceAfterImage()
        {
            AfterImagePool.Instance.GetFromPool();
        }

    }
}
