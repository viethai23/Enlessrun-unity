using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace Yuki
{
    public class GameOverUI : UIManager
    {
        public static GameOverUI Instance;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                Instance = this;
            }
        }

        public void GameOver()
        {
            Time.timeScale = 0;
            GameManager.Instance.GameOver();
            Active();
        }

        public void PlayAgain()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            SoundManager.Instance.DisableBGMusic();
        }

        public void QuitGameplay()
        {
            SceneManager.LoadScene(0);
        }
    }
}
