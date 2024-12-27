using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneChange : MonoBehaviour
{
    [SerializeField] private GameObject map;
    private void Update()
    {
        if (Input.GetKey(KeyCode.M))
        {
            map.SetActive(true);
        }
        if (Input.GetKey(KeyCode.Escape)) 
        {
            map.SetActive(false);
        }

    }
    public void MinaSokak()
    {
        SceneManager.LoadScene(2);
        map.SetActive(false);
    }
    public void ArifSokak()
    {
        SceneManager.LoadScene(3);
        map.SetActive(false);
    }
}
