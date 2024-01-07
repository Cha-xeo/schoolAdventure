using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TrouMathsTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    float currentTime = 0f;
    public float startingTime;
    float minutes;
    float seconds;

    void Start()
    {
        currentTime = startingTime;
        minutes = 0;
    }

    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        minutes = Mathf.Floor(currentTime/60);
        seconds = Mathf.RoundToInt(currentTime%60);
                
        if (seconds == 60) {
            seconds = 0;
            minutes++;
        }

        if (currentTime >= 0) {
            timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");            
        }
    }
}
