using SchoolAdventure.Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SchoolAdventure.Games.Science.ColorSequence
{
    public class SceneManagerColors : MonoBehaviour
    {
        [SerializeField] AudioClip MusicTrack;
        private void Start()
        {
            if (MusicTrack)
            {
                SoundManagerV2.Instance.PlayMusic(MusicTrack);
            }
        }
        public void toGame()
        {
            SceneManager.LoadScene("ColorsGame");
            LivesManagerColors.lives = 3;
            ScoreManagerColors.score = 0;
        }

        public void toMenu()
        {
            SceneManager.LoadScene("MenuColors");
            ScoreManagerColors.score = 0;
        }

        public void toLeave()
        {
            Application.Quit();
        }
    }
}