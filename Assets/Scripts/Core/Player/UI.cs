using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Yuki.NPlayer
{
    public class UI : CoreComp
    {
        [SerializeField] private MultipleIconValueBarTool _healthBar;
        [SerializeField] private TMP_Text _coinValue;
        [SerializeField] private Transform _inventory;

        private Transform _currentWeapon;
        private Button _currentWeaponBorder;
        private Image _currentWeaponIcon;

        public void SetCurrentHealth(float v)
        {
            _healthBar.SetNowValue(v);
        }

        public void SetMaxHealth(float v)
        {
            _healthBar.SetMaxValue(v);
        }

        public void SetCoinValue(float v)
        {
            _coinValue.SetText(v + "");
        }

        public void ChangeWeapon(Sprite sp, int weaponIndex)
        {
            _currentWeapon = _inventory.GetChild(weaponIndex);
            _currentWeaponBorder = _currentWeapon.GetChild(1).GetComponent<Button>();
            _currentWeaponIcon = _currentWeapon.GetChild(1).GetChild(0).GetComponent<Image>();

            _currentWeaponBorder.image.color = Color.red;
            _currentWeaponIcon.sprite = sp;
        }
    }
}
