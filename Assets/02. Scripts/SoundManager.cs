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
    public AudioClip fishSplashClip;

    public AudioClip oliverClip;
    public AudioClip sophieClip;
    public AudioClip rexClip;
    public AudioClip davidClip;


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
        if (!bgmSource.isPlaying)
        {
            PlayBGM(bgmClip);
        }
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

    public void PlayFishSplashSFX()
    {
        sfxSource.PlayOneShot(fishSplashClip);
    }
    
    public void PlayOliverSFX()
    {
        sfxSource.PlayOneShot(oliverClip);
    }
    
    public void PlaySophieSFX()
    {
        sfxSource.PlayOneShot(sophieClip);
    }
    
    public void PlayRexSFX()
    {
        sfxSource.PlayOneShot(rexClip);
    }

    public void PlayDavidSFX()
    {
        sfxSource.PlayOneShot(davidClip);
    }

}
