using System.Collections;
using UnityEngine;
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance {  get; private set; }
    private AudioSource source;
    private AudioSource musicSource;
    private void Awake()
    {
        source = GetComponent<AudioSource>();
        musicSource = transform.GetChild(0).GetComponent<AudioSource>();
        
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }

        ChangeMusicVolume(0);
        ChangeSoundVolume(0);
    }
    public void PlaySound(AudioClip _sound)
    {
        source.PlayOneShot(_sound);
    }
    private void ChangeSoundSource(float baseVolume, string volumeName, float _change, AudioSource src)
    {
        float currentVolume = PlayerPrefs.GetFloat(volumeName, 1);
        currentVolume += _change;
        if (currentVolume < 0)
        {
            currentVolume = 1;
        }
        else if (currentVolume > 1)
        {
            currentVolume = 0;
        }

        float finalVolume = currentVolume * baseVolume;
        src.volume = finalVolume;

        PlayerPrefs.SetFloat(volumeName, currentVolume);
    }
    public void ChangeSoundVolume(float _change)
    {
        ChangeSoundSource(1, "soundVolume", _change, source);
    }
    public void ChangeMusicVolume(float _change)
    {
        ChangeSoundSource(0.3f, "musicVolume", _change, musicSource);
    }
}