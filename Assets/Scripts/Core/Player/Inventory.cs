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
        [SerializeField] private float _startSoulValue;
        [SerializeField] private List<PlayerProjectile> _weapons;
        [SerializeField] private GameObject _upgradeWeaponVFX;
        private float _soulValue;
        private int _currentWeapon;
        private float _soulRequireToUpdateWeapon = 50;
        private float _soulCollectTopUpdateWeapon = 0;

        private UI _ui;
        private Sound _sound;
        
        private void Start()
        {
            _ui = _core.GetCoreComponent<UI>();
            _sound = _core.GetCoreComponent<Sound>();
            Init();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            CheckUpgradeWeapon();
            _ui.ChangeIcon(_currentWeapon);
        }

        private void Init()
        {
            UpdateSoulRequire();
            _soulValue = _startSoulValue;
            _currentWeapon = 0;
            _ui.SetCoinValue(_soulValue);
        }

        public void IncreaseSoulValue(int v)
        {
            _soulValue += v;
            _soulCollectTopUpdateWeapon += v;
            _ui.SetCoinValue(_soulValue);
        }

        private void UpdateSoulRequire()
        {
            if (_currentWeapon >= 11)
            {
                _soulRequireToUpdateWeapon = 1000;
            }
            else if (_currentWeapon >= 7)
            {
                _soulRequireToUpdateWeapon = 500;
            }
            else if (_currentWeapon >= 3)
            {
                _soulRequireToUpdateWeapon = 100;
            }
            else
            {
                _soulRequireToUpdateWeapon = 50;
            }
        }

        private void CheckUpgradeWeapon()
        {
            while(_soulCollectTopUpdateWeapon >= _soulRequireToUpdateWeapon)
            {
                _soulCollectTopUpdateWeapon -= _soulRequireToUpdateWeapon;
                UpgradeWeapon();
                UpdateSoulRequire();
                Debug.Log(_soulRequireToUpdateWeapon);
            }
        }

        public void UpgradeWeapon()
        {
            if (_currentWeapon < _weapons.Count - 1)
            {
                SoundManager.Instance.PlayOneshotFXSound(_sound.Data.UpgradeWeaponFXSound, 0.5f);
                GameObject upgradeGO = Instantiate(_upgradeWeaponVFX, transform.position, Quaternion.identity);
                upgradeGO.transform.parent = transform;
                _currentWeapon++;
            }
        }

        public void DegradeWeapon()
        {
            if (_currentWeapon > 0)
            {
                _currentWeapon--;
            }
        }

        public PlayerProjectile GetCurrentWeapon() => _weapons[_currentWeapon];
    }
}
