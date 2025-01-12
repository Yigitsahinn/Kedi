using UnityEngine;

public class GorevSıl : MonoBehaviour
{
    [SerializeField] GameObject karakolText;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(karakolText);
        }
    }
}
