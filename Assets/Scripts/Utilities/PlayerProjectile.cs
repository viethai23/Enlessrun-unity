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
        public event Action<GameObject, float> OnHitEnemy;
        private bool _isHitEnemy;
        private PlayerProjectileData _playerData;
        

        public override void Awake()
        {
            base.Awake();

            
            _playerData = (PlayerProjectileData)_data;
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
                    Vector2 positionHit = new Vector2(_bounds.max.x, UnityEngine.Random.Range(_bounds.min.y, _bounds.max.y));
                    Instantiate(_playerData.DamageCollisionVFX, positionHit, Quaternion.identity);
                    OnHitEnemy?.Invoke(collision.gameObject, _playerData.DamageAdd);
                    Destroy(gameObject);
                }
                else if(collision.gameObject.CompareTag("EnemyProjectile"))
                {
                    SoundManager.Instance.PlayOneshotFXSound(_playerData.WeaponCollisionSound, 1);
                    Instantiate(_playerData.WeaponCollisionVFX, transform.position, Quaternion.identity);
                    RB.velocity = Vector2.left * _data.Speed;
                }
            }
        }

    }
}
