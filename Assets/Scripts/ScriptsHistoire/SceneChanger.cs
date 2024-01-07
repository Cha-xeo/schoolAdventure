using SchoolAdventure.Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SchoolAdventure.Games.Histoire
{
    public class SceneChanger : MonoBehaviour
    {
        [SerializeField] AudioClip MusicTrack;

        public void PlaySound(AudioClip clip)
        {
            SoundManagerV2.Instance.PlaySound(clip);
        }


        private void Start()
        {
            if (MusicTrack)
            {
                SoundManagerV2.Instance.PlayMusic(MusicTrack);
            }
        }
        public void toGame()
        {
            ScoreManagerHist.score = 0;
            SceneManager.LoadScene("GameHist");
        }

        public void toLeave()
        {
            ScoreManagerHist.score = 0;
            Application.Quit();
        }
    }
}