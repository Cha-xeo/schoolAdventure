using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

namespace SchoolAdventure.Games.Science.ZouzouSnake
{
    public class TimeManagerSc : MonoBehaviour
    {
        public static TimeManagerSc instance;
        public float TimeLeft;
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
                if (TimeLeft > 0)
                {
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

        public void AddTime()
        {
            TimeLeft = TimeLeft + 1;
        }
    }
}