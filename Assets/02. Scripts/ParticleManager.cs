// ParticleManager.cs
using System.Collections;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public ParticleManager Instance { get; private set; }
    public ParticleSystem diggingParticle;
    public ParticleSystem wateringParticle;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayDustParticle(ParticleSystem particle, float duration)
    {
        particle.Play();
        StartCoroutine(StopParticleAfterSeconds(particle, duration));
    }

    private IEnumerator StopParticleAfterSeconds(ParticleSystem particle, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        particle.Stop();
    }
}
