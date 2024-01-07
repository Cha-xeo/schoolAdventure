using SchoolAdventure.Audio;
using SchoolAdventure.Gameplay.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SchoolAdventure.Games.Geographie.ZouzouGeo
{
    public class GeographieMusic : MonoBehaviour
    {

        [SerializeField] MusicHandlerV2 musicHandler;

        [SerializeField] AudioClip ClickSound;

        private void Start()
        {
            musicHandler.PlayMusic(Gameplay.Audio.MusicType.MainMenu);
        }

        public void OnButtonClick()
        {
            SoundManagerV2.Instance.PlaySound(ClickSound);
        }

        public void OnGameScene()
        {
            musicHandler.PlayMusic(Gameplay.Audio.MusicType.InGame1);
        }
    }
}
