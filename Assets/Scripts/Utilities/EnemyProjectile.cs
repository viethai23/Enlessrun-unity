using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Yuki.NEnemy
{
    public class EnemyProjectile : Projectile
    {
        public event Action<GameObject> OnHitPlayer;
        [SerializeField] private Vector2 _direction;

        public override void Awake()
        {
            base.Awake();

            RB.velocity = _direction.normalized * _data.Speed;
            transform.rotation = Quaternion.Euler(0, 0, 180.0f + Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg);

        }

        public override void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.CompareTag("Player"))
            {
                Vector2 positionHit = new Vector2(_bounds.max.x, UnityEngine.Random.Range(_bounds.min.y, _bounds.max.y));
                Instantiate(_data.DamageCollisionVFX, positionHit, Quaternion.identity);
                OnHitPlayer?.Invoke(collision.gameObject);
                Destroy(gameObject);
            }
            else if(collision.gameObject.CompareTag("PlayerProjectile"))
            {
                RB.velocity = -_direction.normalized * _data.Speed;
                transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg);
            }
        }
    }
}
