using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEffect : MonoBehaviour
{
    [SerializeField] private Material _material1;
    [SerializeField] private Material _material2;
    [SerializeField] private float _duration = 2.0f;
    private Renderer _rend;

    void Start()
    {
        _rend = GetComponent<Renderer>();
        _rend.materials[1] = _material1;
    }

    void Update()
    {
        float lerp = Mathf.PingPong(Time.time, _duration) / _duration;
        _rend.materials[1].Lerp(_material1, _material2, lerp);
        transform.Rotate(0f, Random.Range(3f, 7f), 0f, Space.Self);
    }
}
