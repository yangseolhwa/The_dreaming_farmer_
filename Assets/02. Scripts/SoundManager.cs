using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [Header("Audio Sources")]
    public AudioSource bgmSource;
    public AudioSource sfxSource;

    [Header("Audio Clips")]
    public AudioClip bgmClip;
    public AudioClip footstepClip;
    public AudioClip jumpClip;
    public AudioClip diggingClip;
    public AudioClip wateringClip;
    public AudioClip fertilizerClip;

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

    void Start()
    {
        PlayBGM(bgmClip);
    }

    public void PlayBGM(AudioClip clip)
    {
        bgmSource.clip = clip;
        bgmSource.loop = true;
        bgmSource.Play();
    }

    public void PlayFootstepSFX()
    {
        sfxSource.PlayOneShot(footstepClip);
    }

    public void PlayJumpSFX()
    {
        sfxSource.PlayOneShot(jumpClip);
    }

    public void PlayDiggingSFX()
    {
        sfxSource.PlayOneShot(diggingClip);
    }

    public void PlayWateringSFX()
    {
        sfxSource.PlayOneShot(wateringClip);
    }

    public void PlayFertilizerSFX()
    {
        sfxSource.PlayOneShot(fertilizerClip);
    }
}
