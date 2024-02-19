using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Yuki.NEnemy
{
    public class Sound : CoreComp
    {
        [SerializeField] private EnemySoundData _data;
        public EnemySoundData Data => _data;
    }
}
