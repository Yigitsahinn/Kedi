using UnityEngine;

public class Asansörorta : MonoBehaviour
{

    [SerializeField] GameObject kat1Panel;
    [SerializeField] GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            kat1Panel.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            kat1Panel.SetActive(false);
        }
    }
    public void UstKat()
    {
        player.transform.position = new Vector3(-13, (float)14.45, 0);
    }

    public void AltKat()
    {
        player.transform.position = new Vector3(-13, (float)0.45, 0);
    }
}
