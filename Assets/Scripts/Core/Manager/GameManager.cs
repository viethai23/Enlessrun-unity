using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Yuki
{
    public class GameManager : MonoBehaviour
    {
        private int _level; public int Level => _level;
        public static GameManager Instance;

        private void Awake()
        {
            if(Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
            }
            _level = 1;
        }

        public void NextLevel()
        {
            _level++;
        }
    }
}
