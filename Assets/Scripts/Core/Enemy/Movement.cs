using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Yuki.NEnemy
{
    public class Movement : CoreComp
    {
        [SerializeField] private float _moveRange;
        private Vector2 _originPosition;
        private int _facingDirection; public int FacingDirection => _facingDirection;
        private Vector2 _destinationPosition;

        public override void Awake()
        {
            base.Awake();

            _originPosition = transform.position;
            _facingDirection = 1;
            _destinationPosition = _originPosition + new Vector2(_moveRange, 0) * _facingDirection;
        }

        public void Move(float speed)
        {
            transform.position = Vector2.MoveTowards(transform.position, _destinationPosition, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, _destinationPosition) < 0.2f)
            {
                Flip();
            }
        }

        private void Flip()
        {
            _facingDirection *= -1;
            transform.Rotate(0, 180, 0);
            _destinationPosition = _originPosition + new Vector2(_moveRange, 0) * _facingDirection;
        }


#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(_originPosition - new Vector2(_moveRange, 0), _originPosition + new Vector2(_moveRange, 0));
        }
#endif
    }
}
