using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class ScoreEffect : MonoBehaviour
{
    [SerializeField] private GameObject _ballScore;
    [SerializeField] private Vector3 _endScale;

    public void CreateScoreView(Vector3 pos, int score)
    {
        Vector3 instPos = new Vector3(pos.x, 1f, pos.z);
        var view = Instantiate(_ballScore, instPos, Quaternion.Euler(90f, 0f, 0f));
        TMP_Text scoreText = view.GetComponent<TextMeshPro>();
        
        scoreText.text = score > 0 ? $"+{score.ToString()}" : $"{score.ToString()}";
        
        view.transform.DOScale(_endScale, .8f);
        StartCoroutine(DeleteScoreView(view));
    }
    IEnumerator DeleteScoreView(GameObject view)
    {
        yield return new WaitForSeconds(1f);
        DestroyImmediate(view);
    }
}
