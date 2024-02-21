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

    }
}
