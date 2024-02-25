using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Yuki
{
    public class StartUI : UIManager
    {
        private void Start()
        {
            Time.timeScale = 1;
            GameManager.Instance.StartScene();
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
