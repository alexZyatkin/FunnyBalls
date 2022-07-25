using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    private const string HIGHSCORE = "Highscore";
    private ScorePresenter _scorePresenter;

    private void Start()
    {
        _scorePresenter = GetComponent<ScorePresenter>();
        if(!PlayerPrefs.HasKey(HIGHSCORE))
            PlayerPrefs.SetInt(HIGHSCORE, 0);
    }
    public void SaveHighscore()
    {
        if(_scorePresenter.GetScore() >= PlayerPrefs.GetInt(HIGHSCORE))
            PlayerPrefs.SetInt(HIGHSCORE, _scorePresenter.GetScore());
    }
    public static int GetHighScore()
    {
        return PlayerPrefs.GetInt(HIGHSCORE);
    }
}
