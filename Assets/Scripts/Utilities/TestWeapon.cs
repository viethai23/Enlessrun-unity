using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Yuki
{
    public class TestWeapon : MonoBehaviour
    {
        [SerializeField] private int _inputSoul;

        public void UpdateSoulValue()
        {
            NPlayer.Player.Instance.Inventory.IncreaseSoulValue(_inputSoul);
        }
    }
}
