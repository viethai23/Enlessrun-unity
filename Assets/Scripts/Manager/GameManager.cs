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
        [SerializeField] private List<AudioClip> BGSound = new List<AudioClip>();
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
            SoundManager.Instance.CreatePlayBGSound(BGSound[_level - 1]);
        }

        public void NextLevel()
        {
            _level++;
        }
    }
}
