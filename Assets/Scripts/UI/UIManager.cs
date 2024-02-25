using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Yuki
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject _element;
        [SerializeField] private AudioClip _clickFXSound;

        public void Active()
        {
            _element.SetActive(true);
        }

        public void Deactive()
        {
            _element.SetActive(false); 
        }

        public void PlaySoundClick()
        {
            SoundManager.Instance.PlayOneshotFXSound(_clickFXSound);
        }
    }
}
