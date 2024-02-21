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
        [SerializeField] private List<Collectable> _collectables;
        [SerializeField] private SoulCollection _coinCollection;

        private void Start()
        {
            _inventory = _core.GetCoreComponent<Inventory>();

            foreach(Collectable collectable in Enum.GetValues(typeof(Collectable)))
            {
                _collectables.Add(collectable);
            }

            if(_coinCollection.OnUIChange == null)
            {
                _coinCollection.OnUIChange += _inventory.IncreaseCoinValue;
            }
            
        }

        private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
        {
            foreach (Collectable collectable in _collectables)
            {
                if (collision.gameObject.CompareTag(collectable.ToString()))
                {
                    _coinCollection.AddCoin(collision.transform.position, (int)collectable);
                    Destroy(collision.gameObject);
                }
            }
        }

        public void AddCoin(Vector3 position, int amount)
        {
            _coinCollection.AddCoin(position, amount);
        }

        private void OnDisable()
        {
            if(_collectables.Count > 0)
            {
                _collectables.Clear();
            }
            if (_coinCollection.OnUIChange != null)
            {
                _coinCollection.OnUIChange -= _inventory.IncreaseCoinValue;
            }
        }
    }
}
