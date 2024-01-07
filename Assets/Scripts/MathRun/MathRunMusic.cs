using SchoolAdventure.Audio;
using SchoolAdventure.Gameplay.Audio;
using System;
using UnityEngine;

namespace SchoolAdventure.Games.MathRun
{
    public class MathRunMusic : MonoBehaviour
    {
        [SerializeField] MusicHandlerV2 musicHandler;

        private void Start()
        {
            SoundManagerV2.Instance.StopMusic();
            musicHandler.PlayMusic(Gameplay.Audio.MusicType.MainMenu);
        }
    }
}
