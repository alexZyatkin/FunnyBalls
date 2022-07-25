using UnityEngine;
using System;

public enum ParticleType
{
    Ball,
    Bomb
}
public class ParticlePool
{
    int particleAmount;
    ParticleSystem[] BallParticle;
    ParticleSystem[] BombParticle;

    public ParticlePool(ParticleSystem normalPartPrefab, ParticleSystem tntPartPrefab, int amount)
    {
        particleAmount = amount;
        BallParticle = new ParticleSystem[particleAmount];
        BombParticle = new ParticleSystem[particleAmount];

        for (int i = 0; i < particleAmount; i++)
        {
            BallParticle[i] = GameObject.Instantiate(normalPartPrefab, Vector3.zero, Quaternion.identity) as ParticleSystem;
            BombParticle[i] = GameObject.Instantiate(tntPartPrefab, Vector3.zero, Quaternion.identity) as ParticleSystem;
        }
    }
    public ParticleSystem GetAvailabeParticle(ParticleType particleType)
    {
        ParticleSystem firstObject = null;

        if (particleType == ParticleType.Ball)
        {
            firstObject = BallParticle[0];
            ShiftUp(ParticleType.Ball);
        }
        else if (particleType == ParticleType.Bomb)
        {
            firstObject = BombParticle[0];
            ShiftUp(ParticleType.Bomb);
        }

        return firstObject;
    }

    public int GetAmount()
    {
        return particleAmount;
    }

    private void ShiftUp(ParticleType particleType)
    {
        ParticleSystem firstObject;

        if (particleType == ParticleType.Ball)
        {
            firstObject = BallParticle[0];
            Array.Copy(BallParticle, 1, BallParticle, 0, BallParticle.Length - 1);
            BallParticle[BallParticle.Length - 1] = firstObject;
        }
        else if (particleType == ParticleType.Bomb)
        {
            firstObject = BombParticle[0];
            Array.Copy(BombParticle, 1, BombParticle, 0, BombParticle.Length - 1);
            BombParticle[BombParticle.Length - 1] = firstObject;
        }
    }
}