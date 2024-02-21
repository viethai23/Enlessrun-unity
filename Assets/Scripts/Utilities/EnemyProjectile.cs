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
        private GameObject _player;
        public event Action<GameObject> OnHitPlayer;
        [SerializeField] private Vector2 _direction;

        public override void Awake()
        {
            base.Awake();

            //_player = GameObject.FindGameObjectWithTag("Player");

            //Vector3 direction = _player.transform.position - transform.position;
            //RB.velocity = new Vector2(direction.x, direction.y).normalized * _data.Speed;

            //float rotation = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
            //transform.rotation = Quaternion.Euler(0, 0, rotation);
            RB.velocity = _direction.normalized * _data.Speed;
            Debug.Log(Mathf.Atan2(_direction.x, _direction.y) * Mathf.Rad2Deg);
            transform.rotation = Quaternion.Euler(0, 0, 180.0f + Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg);

        }

        public override void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.CompareTag("Player"))
            {
                Debug.Log(collision.transform.name);
                OnHitPlayer?.Invoke(collision.gameObject);
                Destroy(gameObject);
            }
            else if(collision.gameObject.CompareTag("PlayerProjectile"))
            {
                Destroy(gameObject);
            }
        }
    }
}
