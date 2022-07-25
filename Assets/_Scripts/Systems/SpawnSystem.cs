using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnSystem : MonoBehaviour
{
    [SerializeField] private BallPoolControl _ballPoolControl;
    public float SpawnTimerMin;
    public float SpawnTimerMax;
    private bool _spawning;
    
    private void OnEnable()
    {
        Timer.ActionStartGame += SpawnObject;
        Timer.ActionEndGame += StopSpawn;
    }
    private void OnDestroy()
    {
        Timer.ActionEndGame -= StopSpawn;
        Timer.ActionStartGame -= SpawnObject;
    }
    private void SpawnObject()
    {
        _spawning = true;
        StartCoroutine(SpawnTimer());
    }
    private void StopSpawn()
    {
        _spawning = false;
    }
    private IEnumerator SpawnTimer()
    {
        while (_spawning)
        {
            _ballPoolControl.CreateFromPoolAction();
            yield return new WaitForSeconds(Random.Range(SpawnTimerMin, SpawnTimerMax));
        }
    }
}
