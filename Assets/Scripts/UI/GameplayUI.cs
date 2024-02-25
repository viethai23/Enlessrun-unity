using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Yuki
{
    public class GameplayUI : UIManager
    {
        [SerializeField] private Button _pauseButton;

        public void PauseGame()
        {
            _pauseButton.interactable = false;
            Time.timeScale = 0;
        }

        public void Continue()
        {
            _pauseButton.interactable = true;
            Time.timeScale = 1;
        }


    }
}
