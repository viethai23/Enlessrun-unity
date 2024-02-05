using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Yuki.NPlayer
{
    public class CollisionSenses : CoreComp
    {
        [SerializeField] private Transform _groundCheck;
        [SerializeField] private Vector2 _groundCheckSize;
        [SerializeField] private LayerMask _whatIsGround;

        public bool Grounded
        {
            get => _groundCheck ? Physics2D.OverlapBox(_groundCheck.position, _groundCheckSize, 0, _whatIsGround) : false;
        }

#if UNITY_EDITOR
        protected virtual void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(_groundCheck.position, _groundCheckSize);
        }
    }
#endif
}
