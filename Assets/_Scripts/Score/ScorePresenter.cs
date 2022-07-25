using TMPro;
using UnityEngine;

public class ScorePresenter : MonoBehaviour
{
    private int _currentScore;
    [SerializeField] private TMP_Text _commonScore;
    [SerializeField] private TMP_Text _highScore;
    [SerializeField] private TMP_Text _endScore;

    private void Start()
    {
        _highScore.text = SaveSystem.GetHighScore().ToString();
    }
    public void AddScorePoint(int addScore)
    {
        _currentScore += addScore;
        _commonScore.text = _currentScore.ToString();
    }
    public int GetScore()
    {
        return _currentScore;
    }
    public void SetEndScore()
    {
        _endScore.text = _currentScore.ToString();
    }
}
