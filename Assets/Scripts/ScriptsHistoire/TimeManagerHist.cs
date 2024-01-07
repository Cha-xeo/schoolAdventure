using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace SchoolAdventure.Games.Histoire
{
    public class TimeManagerHist : MonoBehaviour
    {
        public static TimeManagerHist instance;
        static public float TimeLeft = 180;
        public bool TimerOn = false;
        public Text TimerText;

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
                    SceneManager.LoadScene("EndMenuLogo");
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
            TimeLeft = TimeLeft + 20.0f;
        }

        public void removeTime()
        {
            TimeLeft = TimeLeft - 1.0f;
        }
    }
}