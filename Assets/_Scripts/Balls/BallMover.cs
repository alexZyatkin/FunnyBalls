using UnityEngine;
using System;
using MarchingBytes;

public class BallMover : MonoBehaviour
{
    public float MoveSpeed;

    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * MoveSpeed * Timer.SpeedMultiply);
        if (transform.position.z >= 15f)
        {
            EasyObjectPool.instance.ReturnObjectToPool(gameObject);
            Debug.Log("RETURN BALL");
        }
    }
}
