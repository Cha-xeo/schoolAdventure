using SchoolAdventure.Audio;
using SchoolAdventure.Gameplay.Audio;
using UnityEngine;

namespace SchoolAdventure.Games.Maze
{
    public class MazeMusic : MonoBehaviour
    {
        [SerializeField] MusicHandlerV2 musicHandler;

        private void Start()
        {
            SoundManagerV2.Instance.StopMusic();
            musicHandler.PlayMusic(Gameplay.Audio.MusicType.MainMenu);
        }

        public void OnGameScene()
        {
            musicHandler.PlayMusic(Gameplay.Audio.MusicType.InGame1);
        }
    }
}
