using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private Canvas _viewStartGame;
    [SerializeField] private Canvas _viewEndGame;
    [SerializeField] private Canvas _viewGame;
    [SerializeField] private List<Canvas> _views;
    
    private void Start()
    {
        ActiveStartGameView();
    }
    private void CanvasesToogle(Canvas active)
    {
        foreach (Canvas canvas in _views)
        {
            canvas.enabled = false;
        }
        active.enabled = true;
    }
    [Button]
    public void ActiveStartGameView()
    {
        CanvasesToogle(_viewStartGame);
    }
    [Button]
    public void ActiveGameView()
    {
        CanvasesToogle(_viewGame);
    }
    [Button]
    public void ActiveEndView()
    {
        CanvasesToogle(_viewEndGame);
    }
}
