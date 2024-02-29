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
        [SerializeField] private Transform _deathCheck;
        private Stats _stats;

        public bool Grounded
        {
            get => _groundCheck ? Physics2D.OverlapBox(_groundCheck.position, _groundCheckSize, 0, _whatIsGround) : false;
        }

        private void Start()
        {
            _stats = _core.GetCoreComponent<Stats>();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if(_groundCheck.transform.position.y < _deathCheck.transform.position.y)
            {
                _stats.DecreaseAllHealth();
            }
        }


        protected virtual void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(_groundCheck.position, _groundCheckSize);
        }
    }

}
