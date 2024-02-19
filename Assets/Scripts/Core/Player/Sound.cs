using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Yuki.NPlayer
{
    public class Sound : CoreComp
    {
        [SerializeField] private PlayerSoundData _data;

        public PlayerSoundData Data => _data;
    }
}
