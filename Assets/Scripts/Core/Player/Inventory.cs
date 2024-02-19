using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Yuki.NPlayer
{
    public class Inventory : CoreComp
    {
        [SerializeField] private float _startCoinValue;
        [SerializeField] private float _maxWeapon;
        [SerializeField] private List<PlayerProjectile> _weapons;
        private float _coinValue;
        private int _currentWeapon;

        private UI _uiController;
        public event Action OnCoinNotEnough;
        
        private void Start()
        {
            _uiController = _core.GetCoreComponent<UI>();
            Init();
        }

        private void Init()
        {
            _coinValue = _startCoinValue;
            _currentWeapon = 0;
            _uiController.ChangeWeapon(_weapons[_currentWeapon].gameObject.GetComponent<SpriteRenderer>().sprite, _currentWeapon);
            _uiController.SetCoinValue(_coinValue);
        }

        public void IncreaseCoinValue(int v)
        {
            _coinValue += v;
            _uiController.SetCoinValue(_coinValue);
        }

        public void DecreaseCoinValue(int v)
        {
            if(_coinValue < v)
            {
                OnCoinNotEnough?.Invoke();
            }
            else
            {
                _coinValue -= v;
                _uiController.SetCoinValue(_coinValue);
            }
        }

        public void AddWeapon(PlayerProjectile projectile)
        {
            if(_weapons.Contains(projectile) || _weapons.Count >= _maxWeapon)
            {
                return;
            } 
            _weapons.Add(projectile);
            _uiController.ChangeWeapon(_weapons[_weapons.Count - 1].gameObject.GetComponent<SpriteRenderer>().sprite, _weapons.Count - 1);
        }

        public void ChangeWeapon(int weaponIndex)
        {
            if(weaponIndex >= 0 && weaponIndex < _weapons.Count)
            {
                _currentWeapon = weaponIndex;
                _uiController.ChangeWeapon(_weapons[_currentWeapon].gameObject.GetComponent<SpriteRenderer>().sprite, _currentWeapon);
            }
        }

        public PlayerProjectile GetCurrentWeapon() => _weapons[_currentWeapon];
    }
}
