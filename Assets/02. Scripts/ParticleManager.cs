// ParticleManager.cs
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class ParticleManager : MonoBehaviour
{
    public static ParticleManager Instance { get; private set; }
    public ParticleSystem diggingParticle;
    public ParticleSystem wateringParticle;
    public ParticleSystem carrotParticle;

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

    public void PlayParticle(ParticleSystem particlePrefab, Vector3 position, float duration)
    {
        ParticleSystem particle = Instantiate(particlePrefab, position, Quaternion.identity);
        particle.Play();
        StartCoroutine(StopParticleAfterSeconds(particle, duration));
    }

    private IEnumerator StopParticleAfterSeconds(ParticleSystem particle, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        particle.Stop();
        Destroy(particle.gameObject, particle.main.startLifetime.constantMax);
    }
}
