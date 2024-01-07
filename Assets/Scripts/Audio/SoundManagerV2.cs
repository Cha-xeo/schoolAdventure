using SchoolAdventure.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SchoolAdventure.Audio
{
    public class SoundManagerV2 : MonoBehaviour
    {
        public static SoundManagerV2 Instance { get; private set; }

        [SerializeField]
        AudioSource _musicSource, _effectsSource;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
                _effectsSource.volume = ClientPrefs.GetEffectVolume();
                _musicSource.volume = ClientPrefs.GetMusicVolume();
                AudioListener.volume = ClientPrefs.GetMasterVolume();
                SceneManager.activeSceneChanged += StopAllSounds;
            }
            else
                Destroy(gameObject);
        }

        public void PlaySound(AudioClip clip)
        {
            _effectsSource.PlayOneShot(clip);
        }

        public void PlayMusic(AudioClip clip)
        {
            //StopMusic();
            _musicSource.clip = clip;
            _musicSource.Play();
        }

        public void ContinueMusic()
        {
            _musicSource.Play();
        }
        public void StopMusic()
        {
            _musicSource.Stop();
        }

        public void StopEffectsSound()
        {
            _effectsSource.Stop();
        }

        public void StopAllSounds()
        {
            _musicSource.Stop();
            _effectsSource.Stop();
        }

        /// <summary>
        /// Automatically called on scene change
        /// </summary>
        /// <param name="current"></param>
        /// <param name="next"></param>
        public void StopAllSounds(Scene current, Scene next)
        {
            _musicSource.Stop();
            _effectsSource.Stop();
        }

        public void ChangeMasterVolume(float value)
        {
            ClientPrefs.SetMasterVolume(value);
            AudioListener.volume = value;
        }

        public void ChangeMusicVolume(float value)
        {
            ClientPrefs.SetMusicVolume(value);
            _musicSource.volume = value;
        }

        public void ChangeEffectsVolume(float value)
        {
            ClientPrefs.SetEffectVolume(value);
            _effectsSource.volume = value;
        }

        public float GetMusicVolume()
        {
            return _musicSource.volume;
        }
        public float GetEffectsVolume()
        {
            return _effectsSource.volume;
        }
        public float GetMasterVolume()
        {
            return AudioListener.volume;
        }
    }
}