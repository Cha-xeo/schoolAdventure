using SchoolAdventure.Gameplay.Audio;
using System;
using UnityEngine;

namespace SchoolAdventure.Games.Science.Audio
{
    public class SnakeMusic : MonoBehaviour
    {
        [SerializeField] MusicHandlerV2 musicHandler;

        private void Start()
        {
            musicHandler.PlayMusic(Gameplay.Audio.MusicType.MainMenu);
        }
    }
}
