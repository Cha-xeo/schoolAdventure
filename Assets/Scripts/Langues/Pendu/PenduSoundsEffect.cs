using SchoolAdventure.Gameplay.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SchoolAdventure.Games.Langues.Pendu
{
    public class PenduSoundsEffect : MonoBehaviour
    {
        [SerializeField] SoundEffectHandler _effectHandler;
        public void PlaySounds(string name)
        {
            _effectHandler.PlaySoundEffect(name);
        }
    }
}
