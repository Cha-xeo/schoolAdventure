using SchoolAdventure.Gameplay.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SchoolAdventure.Games.Langues.Quizz
{
    public class QuizzLangueMusic : MonoBehaviour
    {
        [SerializeField] MusicHandlerV2 musicHandler;

        private void Start()
        {
            musicHandler.PlayMusic(Gameplay.Audio.MusicType.MainMenu);
        }

        public void OnGameScene()
        {
            musicHandler.PlayMusic(Gameplay.Audio.MusicType.InGame1);
        }
    }
}
