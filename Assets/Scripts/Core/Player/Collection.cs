using DamageNumbersPro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Yuki.NPlayer
{
    public class Collection : CoreComp
    {
        private Inventory _inventory;
        private Stats _stats;
        private Sound _sound;
        [SerializeField] private SoulCollection _soulCollection;
        [SerializeField] private DamageNumber _floatingSoulNumber;

        private void Start()
        {
            _inventory = _core.GetCoreComponent<Inventory>();
            _stats = _core.GetCoreComponent<Stats>();
            _sound = _core.GetCoreComponent<Sound>();

            _soulCollection.OnUIChange += _inventory.IncreaseSoulValue;

        }

        private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
        {
            if (collision.gameObject.CompareTag(Collectable.Soul.ToString()))
            {
                _soulCollection.AddSoul(collision.transform.position, 1);
                Destroy(collision.gameObject);
            }
            else if(collision.gameObject.CompareTag(Collectable.Life.ToString()))
            {
                _stats.IncreaseHealth(1);
                SoundManager.Instance.PlayOneshotFXSound(_sound.Data.HealingFXSound);
                Destroy(collision.gameObject);
            }
        }

        public void AddSoul(Vector3 position, int amount, Vector2 collectPosition)
        {
            DamageNumber floatingDamageNumberObject = Instantiate(_floatingSoulNumber, collectPosition, Quaternion.identity);
            floatingDamageNumberObject.number = amount;
            _soulCollection.AddSoul(position, amount, false);
        }

        private void OnDisable()
        {
            _soulCollection.OnUIChange -= _inventory.IncreaseSoulValue;
        }
    }
}
