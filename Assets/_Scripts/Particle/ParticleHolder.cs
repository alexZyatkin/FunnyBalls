using UnityEngine;

public class ParticleHolder : MonoBehaviour
{
    public ParticleSystem[] effects;
    ParticlePool particlePool;

    void Start()
    {
        particlePool = new ParticlePool(effects[0], effects[1], 5);
    }

    public void PlayParticle(ParticleType particleType, Vector3 particlePos)
    {
        ParticleSystem particleToPlay = particlePool.GetAvailabeParticle(particleType);

        if (particleToPlay != null)
        {
            if (particleToPlay.isPlaying)
                particleToPlay.Stop();

            particleToPlay.transform.position = particlePos;
            particleToPlay.Play();
        }

    }
}