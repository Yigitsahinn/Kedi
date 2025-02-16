using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject sinematik;

    IEnumerator StartGame()
    {
        menuPanel.SetActive(false);
        sinematik.SetActive(true);
        yield return new WaitForSeconds(35f);

        SceneManager.LoadScene(1);
    }

    public void StartTheGame()
    {
        StartCoroutine(StartGame());
    }
}
