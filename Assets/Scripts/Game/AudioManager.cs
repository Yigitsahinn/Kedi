using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource whisperSource;

    public AudioClip music;
    public AudioClip whisper;

    private void Start()
    {
        musicSource.clip = music;
        musicSource.Play();
        whisperSource.clip = whisper;
        whisperSource.Play();
    }

    public void PlayWhisper()
    {
        whisperSource.clip = whisper;
        whisperSource.Play();
    }

    public void StopWhisper()
    {
        whisperSource.clip = whisper;
        whisperSource.Pause();
    }
}
