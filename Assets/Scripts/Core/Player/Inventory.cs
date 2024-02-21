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
            _uiController.SetCoinValue(_coinValue);
        }

        public void IncreaseCoinValue(int v)
        {
            _coinValue += v;
            _uiController.SetCoinValue(_coinValue);
        }

        public void AddWeapon(PlayerProjectile projectile)
        {
            if(_weapons.Contains(projectile))
            {
                return;
            } 
            _weapons.Add(projectile);
        }

        public void ChangeWeapon(int weaponIndex)
        {
            if(weaponIndex >= 0 && weaponIndex < _weapons.Count)
            {
                _currentWeapon = weaponIndex;
            }
        }

        public PlayerProjectile GetCurrentWeapon() => _weapons[_currentWeapon];
    }
}
