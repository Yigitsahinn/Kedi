using UnityEngine;

public class StopWhisper : MonoBehaviour
{

    AudioManager audioManager;
    private void Awake()
    {
        audioManager = FindAnyObjectByType<AudioManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        audioManager.StopWhisper();
    }
}
