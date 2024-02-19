using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Yuki
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager Instance;

        [SerializeField] private AudioSource BGMusic;
        [SerializeField] private AudioSource FXMusic;
        [SerializeField] [Range(0, 1)] private float FXVol, BGVol;

        private Dictionary<string, AudioSource> FXDict;
        private Dictionary<string, AudioSource> BGDict;


        private void Awake()
        {
            if(Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                DontDestroyOnLoad(this);
                Instance = this;
            }

            FXDict = new Dictionary<string, AudioSource>();
            BGDict = new Dictionary<string, AudioSource>();
        }

        static void CopyProperties(AudioSource sourceToCopyFrom, AudioSource newSource, AudioClip aClip, float vol)
        {
            newSource.clip = aClip;
            newSource.volume = vol;
            newSource.pitch = sourceToCopyFrom.pitch;
            newSource.panStereo = sourceToCopyFrom.panStereo;
            newSource.spatialBlend = sourceToCopyFrom.spatialBlend;
            newSource.reverbZoneMix = sourceToCopyFrom.reverbZoneMix;
            newSource.dopplerLevel = sourceToCopyFrom.dopplerLevel;
            newSource.spread = sourceToCopyFrom.spread;
            newSource.minDistance = sourceToCopyFrom.minDistance;
            newSource.maxDistance = sourceToCopyFrom.maxDistance;
            newSource.playOnAwake = sourceToCopyFrom.playOnAwake;
            newSource.loop = sourceToCopyFrom.loop;
            newSource.rolloffMode = sourceToCopyFrom.rolloffMode;
            newSource.outputAudioMixerGroup = sourceToCopyFrom.outputAudioMixerGroup;
        }

        public void CreatePlayFXSound(AudioClip aClip)
        {
            CreateFXSound(aClip);
            PlayFXSound(aClip);
        }

        public void CreatePlayBGSound(AudioClip aClip)
        {
            CreateBGSound(aClip);
            PlayBGSound(aClip);
        }

        private void CreateFXSound(AudioClip aClip)
        {
            if (!FXDict.ContainsKey(aClip.name))
            {
                GameObject obj = new GameObject(aClip.name);
                obj.transform.position = Vector3.zero;
                obj.AddComponent<AudioSource>();
                FXDict[aClip.name] = obj.GetComponent<AudioSource>();
                FXDict[aClip.name].gameObject.SetActive(false);
                CopyProperties(BGMusic, FXDict[aClip.name], aClip, FXVol);
                DontDestroyOnLoad(obj);
            }
        }

        private void CreateBGSound(AudioClip aClip)
        {
            if (!BGDict.ContainsKey(aClip.name))
            {
                Debug.Log(BGVol);
                GameObject obj = new GameObject(aClip.name);
                obj.transform.position = Vector3.zero;
                obj.AddComponent<AudioSource>();
                BGDict[aClip.name] = obj.GetComponent<AudioSource>();
                BGDict[aClip.name].gameObject.SetActive(false);
                CopyProperties(BGMusic, BGDict[aClip.name], aClip, BGVol);
                DontDestroyOnLoad(obj);
            }
        }

        public void PlayOneshotFXSound(AudioClip aClip, float volumnScale)
        {
            if(FXVol > 0)
            {
                FXMusic.PlayOneShot(aClip, volumnScale);
            }
        }

        private void PlayFXSound(AudioClip aClip)
        {
            if(FXVol > 0)
            {
                FXDict[aClip.name].gameObject.SetActive(true);
                FXDict[aClip.name].volume = FXVol;

                if (!FXDict[aClip.name].isPlaying)
                {
                    FXDict[aClip.name].Play();
                }

                if(Time.timeScale == 0)
                {
                    FXDict[aClip.name].Pause();
                }
            }
        }

        private void PlayBGSound(AudioClip aClip)
        {
            if (BGVol > 0)
            {
                Debug.Log(BGVol);
                BGDict[aClip.name].gameObject.SetActive(true);
                BGDict[aClip.name].volume = BGVol;

                if (!BGDict[aClip.name].isPlaying)
                {
                    BGDict[aClip.name].Play();
                }

                if (Time.timeScale == 0)
                {
                    BGDict[aClip.name].Pause();
                }
            }
        }

        public void StopFXSound(AudioClip aClip)
        {
            if(FXDict != null)
            {
                if(FXDict.ContainsKey(aClip.name))
                {
                    FXDict[aClip.name].Stop();
                    FXDict[aClip.name].gameObject.SetActive(false);
                }
            }
        }

        public void StopBGSound(AudioClip aClip)
        {
            if (BGDict != null)
            {
                if (BGDict.ContainsKey(aClip.name))
                {
                    BGDict[aClip.name].Stop();
                    BGDict[aClip.name].gameObject.SetActive(false);
                }
            }
        }

        #region SOUND SETTING
        public void PauseAllMusic()
        {
            foreach (AudioSource audioSource in FXDict.Values) 
            {
                if(audioSource.gameObject.activeSelf)
                {
                    audioSource.Pause();
                }
            }

            foreach (AudioSource audioSource in BGDict.Values)
            {
                if (audioSource.gameObject.activeSelf)
                {
                    audioSource.Pause();
                }
            }
        }

        public bool ContinuePlayAllMusic()
        {
            bool check = false;
            if(BGVol > 0)
            {
                foreach (AudioSource audioSource in BGDict.Values)
                {
                    if (audioSource.gameObject.activeSelf)
                    {
                        check = true;
                        if(!audioSource.isPlaying)
                        {
                            audioSource.Play();
                        }
                    }
                }
            }
            else
            {
                foreach (AudioSource audioSource in BGDict.Values)
                {
                    if (audioSource.gameObject.activeSelf)
                    {
                        audioSource.Stop();
                    }
                }
            }

            if (FXVol > 0)
            {
                foreach (AudioSource audioSource in FXDict.Values)
                {
                    if (audioSource.gameObject.activeSelf)
                    {
                        check = true;
                        if (!audioSource.isPlaying)
                        {
                            audioSource.Play();
                        }
                    }
                }
            }
            else
            {
                foreach (AudioSource audioSource in FXDict.Values)
                {
                    if (audioSource.gameObject.activeSelf)
                    {
                        audioSource.Stop();
                    }
                }
            }

            return check;
        }

        public void DisableAllMusic()
        {
            foreach (AudioSource audioSource in FXDict.Values)
            {
                if(audioSource.gameObject.activeSelf)
                {
                    audioSource.Stop();
                    audioSource.gameObject.SetActive(false);
                }
            }

            foreach (AudioSource audioSource in BGDict.Values)
            {
                if (audioSource.gameObject.activeSelf)
                {
                    audioSource.Stop();
                    audioSource.gameObject.SetActive(false);
                }
            }
        }

        public void DisableBGMusic()
        {
            foreach (AudioSource audioSource in BGDict.Values)
            {
                if (audioSource.gameObject.activeSelf)
                {
                    audioSource.Stop();
                    audioSource.gameObject.SetActive(false);
                }
            }
        }

        public void DisableFXMusic()
        {
            FXVol = 0;
        }

        public void EnableFXGMusic()
        {
            FXVol = 1;
        }

        public void ChangeVolumeBGMusic(float value)
        {
            BGVol = value;
            foreach (AudioSource audioSource in BGDict.Values)
            {
                audioSource.volume = value;
            }
        }

        public void ChangeVolumeFXMusic(float value)
        {
            FXVol = value;
            foreach (AudioSource audioSource in FXDict.Values)
            {
                audioSource.volume = value;
            }
        }

        #endregion
    }
}
