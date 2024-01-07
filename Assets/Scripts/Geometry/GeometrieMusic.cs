using SchoolAdventure.Audio;
using SchoolAdventure.Gameplay.Audio;
using UnityEngine;

namespace SchoolAdventure.Games.Geometrie.music
{
    public class GeometrieMusic : MonoBehaviour
    {
        [SerializeField] MusicHandlerV2 musicHandler;

        private void Start()
        {
            SoundManagerV2.Instance.StopMusic();
            musicHandler.PlayMusic(Gameplay.Audio.MusicType.MainMenu);
        }

        public void OnGameScene()
        {
            Debug.Log(Gameplay.Audio.MusicType.InGame1.ToString());
            musicHandler.PlayMusic(Gameplay.Audio.MusicType.InGame1);
        }
    }
}