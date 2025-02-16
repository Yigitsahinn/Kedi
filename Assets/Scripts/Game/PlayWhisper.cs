using UnityEngine;

public class PlayWhisper : MonoBehaviour
{
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = FindAnyObjectByType<AudioManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        audioManager.PlayWhisper();
    }
}
