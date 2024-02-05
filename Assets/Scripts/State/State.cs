using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yuki
{
    public class State : MonoBehaviour
    {
        protected Actor actor;
        private string _animName;
        protected bool isExitingState;


        public State(Actor actor, string animName)
        {
            this.actor = actor;
            _animName = animName;
        }

        public virtual void Enter()
        {
            DoCheck();
            actor.Anim.SetBool(_animName, true);
            isExitingState = false;
        }

        public virtual void Exit()
        {
            actor.Anim.SetBool(_animName, false);
            isExitingState = true;
        }

        public virtual void LogicUpdate() { }

        public virtual void PhysicUpdate()
        {
            DoCheck();
        }

        public virtual void DoCheck() { }
    }
}
