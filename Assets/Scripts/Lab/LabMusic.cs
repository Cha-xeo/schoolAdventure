using SchoolAdventure.Gameplay.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.InputSystem;
using UnityEngine;

namespace SchoolAdventure.Games.Lab
{
    public class LabMusic : MonoBehaviour
    {
        [SerializeField] MusicHandlerV2 musicHandler;

        private void Start()
        {
            musicHandler.PlayMusic(Gameplay.Audio.MusicType.MainMenu);
        }

        public void OnGameScene(int type)
        {
            musicHandler.PlayMusic((Gameplay.Audio.MusicType)type);
        }
    }
}