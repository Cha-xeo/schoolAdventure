using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SchoolAdventure.Gameplay.Audio
{
    [System.Serializable]
    public class EffectTemplate
    {
        public String Name;
        public AudioClip Effect;

    }
    public class SoundEffectHandler : MonoBehaviour
    {
        [SerializeField] List<EffectTemplate> _effectTemplates;

        public void PlaySoundEffect(string name)
        {
            AudioClip clip = GetMusic(name);
            SchoolAdventure.Audio.SoundManagerV2.Instance.StopEffectsSound();
            SchoolAdventure.Audio.SoundManagerV2.Instance.PlaySound(clip);
        }
        public void PlaySoundEffect(int index)
        {
            AudioClip clip = GetMusic(index);
            SchoolAdventure.Audio.SoundManagerV2.Instance.StopEffectsSound();
            SchoolAdventure.Audio.SoundManagerV2.Instance.PlaySound(clip);
        }
        private AudioClip GetMusic(string name)
        {
            return _effectTemplates.FirstOrDefault(music => music.Name == name).Effect;
        }
        private AudioClip GetMusic(int index)
        {
            return _effectTemplates[index].Effect;
        }
    }
}
