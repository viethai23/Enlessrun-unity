using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Yuki
{
    public class LoadGameUI : UIManager
    {
        [SerializeField] private TMP_Text text;
        [SerializeField] private List<AudioClip> _countdownFXSound = new List<AudioClip>();

        private void Start()
        {
            SoundManager.Instance.DisableBGMusic();
            Active();
            StartCoroutine(LoadStartGame());
        }

        IEnumerator LoadStartGame()
        {
            for(int i = 0; i < 4; i++) 
            {
                SoundManager.Instance.PlayOneshotFXSound(_countdownFXSound[i]);
                if (i == 3)
                {
                    text.SetText("GO !");
                }
                else
                {
                    text.SetText(3 - i + "");
                }
                yield return new WaitForSeconds(1);
            }
            Deactive();
            GameManager.Instance.StartGame();
            
        }
    }
}
