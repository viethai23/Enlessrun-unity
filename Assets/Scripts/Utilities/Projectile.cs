using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Yuki
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] protected ProjectileData _data;
        [SerializeField] private Transform _groundCheck;
        [SerializeField] private Vector2 _groundCheckSize;
        [SerializeField] private LayerMask _whatIsGround;
        private float _fireTimer;
        public Rigidbody2D RB { get; private set; }

        public virtual void Awake() 
        {
            RB = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            _fireTimer += Time.deltaTime;

            if (_fireTimer >= _data.MaxExistTime || Physics2D.OverlapBox(_groundCheck.position, _groundCheckSize, 0, _whatIsGround))
            {
                Destroy(gameObject);
            }
        }

        public virtual void OnTriggerEnter2D(Collider2D collision)
        {
            
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
