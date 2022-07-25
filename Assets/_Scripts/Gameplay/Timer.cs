using System;
using TMPro;
using UnityEngine;
public class Timer : MonoBehaviour
{
    public float timeRemaining;
    public float timeUpSpeed;
    private bool _timerIsRunning = false;
    public TMP_Text timeText;
    public static event Action ActionEndGame;
    public static event Action ActionStartGame;
    public static float SpeedMultiply;
    private float _maxSpeedMultiply = 1.2f;

    void Update()
    {
        if (_timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
                timeUpSpeed += Time.deltaTime;
                IncreaseSpeedMultiply(timeUpSpeed);
            }
            else
            {
                timeRemaining = 0;
                _timerIsRunning = false;
                ActionEndGame?.Invoke();
            }
        }
    }
    private void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void IncreaseSpeedMultiply(float timeUp)
    {
        SpeedMultiply = Mathf.Lerp(1, _maxSpeedMultiply, timeUp / timeRemaining);
    }
    public void StartTimer()
    {
        _timerIsRunning = true;
        ActionStartGame?.Invoke();
    }
    
}