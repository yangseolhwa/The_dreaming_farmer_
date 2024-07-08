using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public AudioMixer audioMixer;

    private const string MasterVolumeParam = "MasterVolume";
    private const string BGMVolumeParam = "BGMVolume";
    private const string SFXVolumeParam = "SFXVolume";

    private const string MasterVolumePrefKey = "MasterVolume";
    private const string BGMVolumePrefKey = "BGMVolume";
    private const string SFXVolumePrefKey = "SFXVolume";

    public Slider masterSlider;
    public Slider bgmSlider;
    public Slider sfxSlider;

    private void Start()
    {
        float masterVolume = PlayerPrefs.GetFloat(MasterVolumePrefKey, 0.75f);
        float BgmVolume = PlayerPrefs.GetFloat(BGMVolumePrefKey, 0.75f);
        float sfxVolume = PlayerPrefs.GetFloat(SFXVolumePrefKey, 0.75f);

        masterSlider.value = masterVolume;
        bgmSlider.value = BgmVolume;
        sfxSlider.value = sfxVolume;

        ApplyVolumes();

        /*
        SetMasterVolume(masterSlider.value);
        SetBGMVolume(bgmSlider.value);
        SetSFXVolume(sfxSlider.value);
        */
    }

    private void ApplyVolumes()
    {
        SetMasterVolume(masterSlider.value);
        SetBGMVolume(bgmSlider.value);
        SetSFXVolume(sfxSlider.value);
    }


    private void OnEnable()
    {
        masterSlider.onValueChanged.AddListener(SetMasterVolume);
        bgmSlider.onValueChanged.AddListener(SetBGMVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    private void OnDisable()
    {
        masterSlider.onValueChanged.RemoveListener(SetMasterVolume);
        bgmSlider.onValueChanged.RemoveListener(SetBGMVolume);
        sfxSlider.onValueChanged.RemoveListener(SetSFXVolume);
    }

    private void SetMasterVolume(float value)
    {
        PlayerPrefs.SetFloat(MasterVolumePrefKey, value);
        audioMixer.SetFloat(MasterVolumeParam, Mathf.Log10(value) * 20);
    }

    private void SetBGMVolume(float value)
    {
        PlayerPrefs.SetFloat(BGMVolumePrefKey, value);
        audioMixer.SetFloat(BGMVolumeParam, Mathf.Log10(value) * 20);
    }

    private void SetSFXVolume(float value)
    {
        PlayerPrefs.SetFloat(SFXVolumePrefKey, value);
        audioMixer.SetFloat(SFXVolumeParam, Mathf.Log10(value) * 20);
    }

    public void ResetVolumes()
    {
        float defaultVolume = 0.75f;

        masterSlider.value = defaultVolume;
        bgmSlider.value = defaultVolume;
        sfxSlider.value = defaultVolume;

        ApplyVolumes();

        PlayerPrefs.SetFloat(MasterVolumePrefKey, defaultVolume);
        PlayerPrefs.SetFloat(BGMVolumePrefKey, defaultVolume);
        PlayerPrefs.SetFloat(SFXVolumePrefKey, defaultVolume);
        PlayerPrefs.Save();
    }
}
