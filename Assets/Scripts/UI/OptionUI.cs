using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Yuki
{
    public class OptionUI : UIManager
    {
        [SerializeField] private Slider _BGSlider;
        [SerializeField] private Slider _FXSlider;

        private void Start()
        {
            _BGSlider.value = SoundManager.Instance.BGVol;
            _FXSlider.value = SoundManager.Instance.FXVol;
        }

        public void ChangeBGSound()
        {
            SoundManager.Instance.ChangeVolumeBGMusic(_BGSlider.value);
        }

        public void ChangeFXSound()
        {
            SoundManager.Instance.ChangeVolumeFXMusic(_FXSlider.value);
        }

        public void QuitGameplay()
        {
            SceneManager.LoadScene(0);
        }
    }
}
