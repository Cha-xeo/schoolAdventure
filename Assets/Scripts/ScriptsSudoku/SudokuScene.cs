using SchoolAdventure.Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SchoolAdventure.Games.Sudoku
{
    public class SudokuScene : MonoBehaviour
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
        public void toMenu()
        {
            SceneManager.LoadScene("SudokuMenu");
        }
        public void toGame()
        {
            //LiveSudoku.errors = 0;
            TimerSudoku.TimeLeft = 0;
            SceneManager.LoadScene("Sudoku");
        }

        public void toLeave()
        {
            Application.Quit();
        }
    }
}