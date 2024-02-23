
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Yuki
{
    [Serializable]
    public struct CooldownSkill
    {
        public Image skillImage;
        public float skillCooldown;
        public bool isCooldown;
    }
}
