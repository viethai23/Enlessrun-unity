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
        [SerializeField] private float _distanceToNextLevel;
        [SerializeField] private float _offsetToIncreaseDistance;
        private int _level; public int Level => _level;
        public static GameManager Instance;

        private float _currentDistanceToNextLevel;

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
            Init();
        }

        private void Update()
        {
            CheckIfNextLevel();
            _currentDistanceToNextLevel += Time.deltaTime;
            Debug.Log(_currentDistanceToNextLevel);
        }

        private void Init()
        {
            _level = 1;
            SoundManager.Instance.CreatePlayBGSound(BGSound[_level - 1]);
        }


        private void CheckIfNextLevel()
        {
            if (_currentDistanceToNextLevel >= _distanceToNextLevel)
            {
                NextLevel();
            }
        }


        public void NextLevel()
        {
            _level++;
            _currentDistanceToNextLevel = 0;
            _distanceToNextLevel += _offsetToIncreaseDistance * _level / 10;
            Debug.Log("Level " + _level);
        }
    }
}
