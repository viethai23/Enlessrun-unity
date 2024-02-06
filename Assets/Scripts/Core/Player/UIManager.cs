using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Yuki.NPlayer
{
    public class UIManager : CoreComp
    {
        [SerializeField] private MultipleIconValueBarTool healthBar;

        public void SetCurrentHealth(float v)
        {
            healthBar.SetNowValue(v);
        }

        public void SetMaxHealth(float v)
        {
            healthBar.SetMaxValue(v);
        }
    }
}
