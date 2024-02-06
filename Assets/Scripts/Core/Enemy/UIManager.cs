using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Yuki.NEnemy
{
    public class UIManager : CoreComp
    {
        [SerializeField] private LongIconBarTool healthBar;

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
