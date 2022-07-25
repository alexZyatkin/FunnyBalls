using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallView : MonoBehaviour
{
    [SerializeField] private List<Material> _ballMaterial;
    private Renderer _rend;

    private void Awake()
    {
        _rend = GetComponent<Renderer>();
    }

    [Button]
    public void SetBallMaterial(GameObject obj)
    {
        _rend = obj.GetComponent<Renderer>();
        int rand = Random.Range(0, _ballMaterial.Count);
        _rend.material = _ballMaterial[rand];

        // _rend.material.HasProperty("Transparent") = 3001;
    }
}
