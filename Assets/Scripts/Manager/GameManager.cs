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
        private int _level = 1; public int Level => _level;
        public static GameManager Instance;

        private float _currentDistanceToNextLevel;
        private int _soulValue = 1; public int SoulValue => _soulValue;
        private bool _startGame = false; public bool IsStartGame => _startGame;

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
            DontDestroyOnLoad(this);
            Application.targetFrameRate = 60;
            
        }

        private void Update()
        {
            if (_startGame)
            {
                CheckIfNextLevel();
                _currentDistanceToNextLevel += Time.deltaTime;
            }
        }

        private void Init()
        {
            ResetAll();
            SoundManager.Instance.CreatePlayBGSound(BGSound[UnityEngine.Random.Range(0, BGSound.Count)]);
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
            _soulValue += _level / 10;
        }

        public void StartGame()
        {
            Init();
            _startGame = true;
        }

        public void GameOver()
        {
            ResetAll();
        }

        public void StartScene()
        {
            SoundManager.Instance.DisableBGMusic();
            SoundManager.Instance.CreatePlayBGSound(BGSound[0]);
            ResetAll();
        }

        private void ResetAll()
        {
            _level = 1;
            _startGame = false;
            _currentDistanceToNextLevel = 0;
        }
    } 
}
