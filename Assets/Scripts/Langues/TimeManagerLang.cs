using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

namespace SchoolAdventure.Games.Langues.Quizz
{
    public class TimeManagerLang : MonoBehaviour
    {
        public static TimeManagerLang instance;
        public float TimeLeft = 15;
        public bool TimerOn = false;
        public TMP_Text TimerText;
        public TutoQuizzLangues _tutoManager;

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
            if (_tutoManager.tuto == false) {
                if (TimerOn)
                {
                    if (TimeLeft > 0)
                    {
                        TimeLeft -= Time.deltaTime;
                        updateTimer(TimeLeft);
                    }
                    else
                    {
                        TimeLeft = 0;
                        TimerOn = false;
                    }
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
            TimeLeft = TimeLeft + 10.0f;
        }

        public void removeTime()
        {
            TimeLeft = TimeLeft - 1.0f;
        }

        public void resetTime()
        {
            TimeLeft = 15;
            TimerOn = true;
        }
    }
}