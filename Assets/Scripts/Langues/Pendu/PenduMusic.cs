using SchoolAdventure.Gameplay.Audio;
using System;
using UnityEngine;

namespace SchoolAdventure.Games.Langues.Pendu
{
    public class PenduMusic : MonoBehaviour
    {
        [SerializeField] MusicHandlerV2 musicHandler;

        private void Start()
        {
            musicHandler.PlayMusic(Gameplay.Audio.MusicType.MainMenu);
        }
    }
}
