using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject mapButton;
    [SerializeField] GameObject haritaPanel;
    [SerializeField] GameObject envanterPanel;
    [SerializeField] GameObject supheliPanel;
    [SerializeField] GameObject karakolText;
    [SerializeField] public GameObject minagorevText;

    MinaMezarlýk minaMezarlýk;
    KaraMezarlýk karaMezarlýk;

    private void Awake()
    {
        karaMezarlýk = FindAnyObjectByType<KaraMezarlýk>();
        minaMezarlýk = FindAnyObjectByType<MinaMezarlýk>();
    }
    private void Update()
    {
        if(minaMezarlýk.minaGorev == true)
        {
            mapButton.SetActive(true);
            minagorevText.SetActive(true);
        }
        if(karaMezarlýk.karakolGorev == true)
        {
            karakolText.SetActive(true);

        }
    }

    public void Harita()
    {
        haritaPanel.SetActive(true);
    }
    public void Envanter()
    {
        envanterPanel.SetActive(true);
    }
    public void Liste()
    {
        supheliPanel.SetActive(true);
    }
}
