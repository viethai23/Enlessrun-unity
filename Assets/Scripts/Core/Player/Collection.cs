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
        [SerializeField] private SoulCollection _soulCollection;
        [SerializeField] private DamageNumber _floatingSoulNumber;

        private void Start()
        {
            _inventory = _core.GetCoreComponent<Inventory>();

            _soulCollection.OnUIChange += _inventory.IncreaseSoulValue;

        }

        private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Soul"))
            {
                _soulCollection.AddSoul(collision.transform.position, 1);
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
