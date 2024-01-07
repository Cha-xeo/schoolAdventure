using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WordmapTimer : MonoBehaviour
{
    public WordmapGameData currentGameData;
    public TextMeshProUGUI timerText;

    private float _timeLeft;
    private float _minutes;
    private float _seconds;
    private float _oneSecondDown;
    private bool _timeOut;
    private bool _stopTimer;

    void Start()
    {
        _stopTimer = false;
        _timeOut = false;
        _timeLeft = currentGameData.selectedBoardData.timeInSeconds;
        _oneSecondDown = _timeLeft - 1f;

        WordmapGameEvents.OnBoardCompleted += StopTimer;
        WordmapGameEvents.OnUnlockNextCategory += StopTimer;
    }

    private void OnDisable()
    {
        WordmapGameEvents.OnBoardCompleted -= StopTimer;
        WordmapGameEvents.OnUnlockNextCategory -= StopTimer;
    }

    public void StopTimer()
    {
        _stopTimer = true;
    }

    void Update()
    {
        if (_stopTimer == false) {
            _timeLeft -= Time.deltaTime;
        }
        
        if (_timeLeft <= _oneSecondDown) {
            _oneSecondDown -= _timeLeft - 1f;
        }
    }

    void OnGUI()
    {
        if (_timeOut == false) {
            if (_timeLeft > 0) {
                _minutes = Mathf.Floor(_timeLeft/60);
                _seconds = Mathf.RoundToInt(_timeLeft%60);
                
                if (_seconds == 60) {
                    _seconds = 0;
                    _minutes++;
                }

                timerText.text = _minutes.ToString("00") + ":" + _seconds.ToString("00");
            } else {
                _stopTimer = true;
                ActivateGameOverGUI();
            }
        } 
    }

    private void ActivateGameOverGUI()
    {
        WordmapGameEvents.GameOverMethod();
        _timeOut = true;
    }
}
