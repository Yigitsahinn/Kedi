using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EnterBuilding : MonoBehaviour
{
    [SerializeField] private GameObject text;
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           text.SetActive(true);
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(2);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            text.SetActive(false);
        }
    }
}
