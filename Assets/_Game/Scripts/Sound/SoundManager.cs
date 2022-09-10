using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] public AudioSource _musicSource;
    [SerializeField] private AudioSource _effectsSource;
    public static SoundManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlaySound(AudioClip clip)
    {
        _effectsSource.PlayOneShot(clip);
    }

    public void MuteAndUnmuteSound()
    {
        _musicSource.mute = !_musicSource.mute;
        _effectsSource.mute = !_effectsSource.mute;
    }

    public void IncrementPitch()
    {
        StartCoroutine(WaitBeforePitch());
        StartCoroutine(WaitAfterPitch());
    }

    public void ResetPitch()
    {
        _effectsSource.pitch = 1f;
    }

    private IEnumerator WaitAfterPitch()
    {
        yield return new WaitForSeconds(0.4f);
        SoundManager.Instance.ResetPitch();
    }

    private IEnumerator WaitBeforePitch()
    {
        yield return new WaitForSeconds(0.1f);
        _effectsSource.pitch += 0.2f;
    }
}