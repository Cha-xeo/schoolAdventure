using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

namespace SchoolAdventure.Games.Geographie.ZouzouGeo
{
    public class TimeManager : MonoBehaviour
    {
        public static TimeManager instance;
        static public float TimeLeft = 250;
        public bool TimerOn = false;
        public TMP_Text TimerText;

        private void Awake()
        {
            instance = this;
        }
        void Start()
        {
            TimerOn = true;
        }

        void Update()
        {
            if (TimerOn)
            {
                if (ScoreManager.score == 6)
                {
                    TimerOn = false;
                }
                if (TimeLeft > 0)
                {
                    if (ScoreManager.score != 6)
                        TimeLeft -= Time.deltaTime;
                    updateTimer(TimeLeft);
                }
                else
                {
                    TimeLeft = 0;
                    TimerOn = false;
                    SceneManager.LoadScene("EndMenu");
                }
            }
        }

        void updateTimer(float currentTime)
        {
            currentTime += 1;

            float minutes = Mathf.FloorToInt(currentTime / 60);
            float seconds = Mathf.FloorToInt(currentTime % 60);

            TimerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
        }
        public void addTime()
        {
            TimeLeft = TimeLeft + 5.0f;
        }

        public void removeTime()
        {
            TimeLeft = TimeLeft - 1.0f;
        }
    }
}