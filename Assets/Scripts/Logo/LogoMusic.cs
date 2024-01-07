using SchoolAdventure.Audio;
using SchoolAdventure.Gameplay.Audio;
using UnityEngine;

namespace SchoolAdventure.Games.Langues.Logo
{
    public class LogoMusic : MonoBehaviour
    {
        [SerializeField] MusicHandlerV2 musicHandler;

        private void Start()
        {
            musicHandler.PlayMusic(Gameplay.Audio.MusicType.MainMenu);
        }
    }
}