using UnityEngine;
using UnityEngine.UI;

namespace SchoolAdventure.Audio
{
    public class UiAudioVolume : MonoBehaviour
    {
        [SerializeField] Slider _musicSlider, _effectSlider, _masterSlider;
        private void OnEnable()
        {
            _musicSlider.value = SchoolAdventure.Audio.SoundManager.Instance.GetMusicVolume();
            _effectSlider.value = SchoolAdventure.Audio.SoundManager.Instance.GetEffectsVolume();
            _masterSlider.value = SchoolAdventure.Audio.SoundManager.Instance.GetMasterVolume();
        }

        public void EffectVolume()
        {
            SchoolAdventure.Audio.SoundManager.Instance.ChangeMusicVolume(_effectSlider.value);
        }
        public void MusicVolume()
        {
            SchoolAdventure.Audio.SoundManager.Instance.ChangeEffectsVolume(_musicSlider.value);
        }
        public void MasterVolume()
        {
            SchoolAdventure.Audio.SoundManager.Instance.ChangeMasterVolume(_masterSlider.value);
        }
    }
}