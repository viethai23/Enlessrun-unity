using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Yuki.NPlayer
{
    public class InAirState : PlayerState
    {
        protected bool _jumpInput;
        protected bool _dashInput;
        protected bool _isGrounded;
        protected bool _attackInput;
        protected float _yInput;
        public InAirState(Actor actor, string animName) : base(actor, animName)
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

            CheckInput();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if(!isExitingState)
            {
                CheckInput();

                if (_isGrounded)
                {
                    player.FSM.ChangeState(player.RunState);
                }
            }
        }

        private void CheckInput()
        {
            _jumpInput = player.Input.JumpInput;
            _dashInput = player.Input.DashInput;
            _attackInput = player.Input.AttackInput;
            _yInput = player.Input.MovementInput.y;
        }
    }
}
