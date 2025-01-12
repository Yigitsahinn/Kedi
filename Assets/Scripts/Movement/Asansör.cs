using UnityEngine;

public class Asansör : MonoBehaviour
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
        player.transform.position = new Vector3(-13, (float)7.45, 0);
    }

}
