using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Yuki
{
    public class StartUI : UIManager
    {
        public UnityEvent FirstTimePlay;

        private void Start()
        {
            Time.timeScale = 1;
            GameManager.Instance.StartScene();
            if (!PlayerPrefs.HasKey("firstTime"))
            {
                PlayerPrefs.SetInt("firstTime", 1);
                FirstTimePlay?.Invoke();
            }
        }

        public void StartGame()
        {
            SceneManager.LoadScene(1);
            //GameManager.Instance.StartGame();
        }
        
        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
