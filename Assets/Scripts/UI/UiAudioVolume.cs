using UnityEngine;
using UnityEngine.UI;

namespace SchoolAdventure.Gameplay.Audio
{
    public class UiAudioVolume : MonoBehaviour
    {
        [SerializeField] Slider _musicSlider, _effectSlider, _masterSlider;
        private void OnEnable()
        {
            _musicSlider.value = SchoolAdventure.Audio.SoundManagerV2.Instance.GetMusicVolume();
            _effectSlider.value = SchoolAdventure.Audio.SoundManagerV2.Instance.GetEffectsVolume();
            _masterSlider.value = SchoolAdventure.Audio.SoundManagerV2.Instance.GetMasterVolume();
        }

        public void EffectVolume()
        {
            SchoolAdventure.Audio.SoundManagerV2.Instance.ChangeEffectsVolume(_effectSlider.value);
        }
        public void MusicVolume()
        {
            SchoolAdventure.Audio.SoundManagerV2.Instance.ChangeMusicVolume(_musicSlider.value);
        }
        public void MasterVolume()
        {
            SchoolAdventure.Audio.SoundManagerV2.Instance.ChangeMasterVolume(_masterSlider.value);
        }
    }
}
