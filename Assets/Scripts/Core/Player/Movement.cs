using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Yuki.NPlayer
{
    public class Movement : CoreComp
    {
        public Rigidbody2D RB { get; private set; }

        public Vector2 CurrentVelocity { get; private set; }
        private Vector2 workspace;
        public bool CanSetVelocity;

        public override void Awake()
        {
            base.Awake();

            RB = GetComponentInParent<Rigidbody2D>();
            CanSetVelocity = true;
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            CurrentVelocity = RB.velocity;
        }

        public void SetVelocityZero()
        {
            workspace = Vector2.zero;
            SetFinalVelocity();
        }

        public void SetVelocityX(float velocity)
        {
            workspace.Set(velocity, CurrentVelocity.y);
            SetFinalVelocity();
        }

        public void SetVelocityY(float velocity)
        {
            workspace.Set(CurrentVelocity.x, velocity);
            SetFinalVelocity();
        }

        public void SetVelocity(Vector2 velocity)
        {
            workspace.Set(velocity.x, velocity.y);
            SetFinalVelocity();
        }

        public void SetGravity(float gravity)
        {
            RB.gravityScale = gravity;
        }

        private void SetFinalVelocity()
        {
            if (CanSetVelocity)
            {
                RB.velocity = workspace;
                CurrentVelocity = workspace;
            }
        }
    }
}
