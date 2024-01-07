using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace SchoolAdventure.Games.Sudoku
{
    public class TimerSudoku : MonoBehaviour
    {
        public static TimerSudoku instance;
        public static float TimeLeft = 0;
        public bool TimerOn = false;
        public Text TimerText;

        private void Awake()
        {
            instance = this;
        }

        void Start()
        {
            updateTimer(TimeLeft);
        }

        void Update()
        {
            if (TimerOn)
            {
                TimeLeft += Time.deltaTime;
                updateTimer(TimeLeft);
            }
        }

        void updateTimer(float currentTime)
        {
            currentTime += 1;

            float minutes = Mathf.FloorToInt(currentTime / 60);
            float seconds = Mathf.FloorToInt(currentTime % 60);

            TimerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
        }

        void freezeTimer()
        {
            TimerOn = false;
        }
    }

}