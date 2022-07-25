using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool IsGame;
    private UIController _uiController;
    private SaveSystem _saveSystem;
    private Timer _timer;
    private ScorePresenter _scorePresenter;
    [SerializeField] private BallPoolControl ballPoolControl;

    private void OnEnable()
    {
        Timer.ActionEndGame += EndGame;
    }
    private void OnDisable()
    {
        Timer.ActionEndGame -= EndGame;
    }
    private void Awake()
    {
        _uiController = GetComponent<UIController>();
        _saveSystem = GetComponent<SaveSystem>();
        _scorePresenter = GetComponent<ScorePresenter>();
        _timer = GetComponent<Timer>();
    }
    public void StartGame()
    {
        _uiController.ActiveGameView();
        _timer.StartTimer();
    }
    public void EndGame()
    {
        _uiController.ActiveEndView();
        _saveSystem.SaveHighscore();
        _scorePresenter.SetEndScore();
        ballPoolControl.ReturnAllToPoolAction();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
