using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Yuki.NPlayer
{
    public class PlayerProjectile : Projectile
    {
        public event Action<GameObject> OnHitEnemy;
        private bool _isHitEnemy;
        public override void Awake()
        {
            base.Awake();

            RB.velocity = Vector2.right * _data.Speed;
        }

        public override void OnTriggerEnter2D(Collider2D collision)
        {
            base.OnTriggerEnter2D(collision);

            if(!_isHitEnemy)
            {
                if (collision.gameObject.CompareTag("Enemy"))
                {
                    _isHitEnemy = true;
                    OnHitEnemy?.Invoke(collision.gameObject);
                    Destroy(gameObject);
                }
            }
        }

    }
}
