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

    MinaMezarlęk minaMezarlęk;
    KaraMezarlęk karaMezarlęk;

    private void Awake()
    {
        karaMezarlęk = FindAnyObjectByType<KaraMezarlęk>();
        minaMezarlęk = FindAnyObjectByType<MinaMezarlęk>();
    }
    private void Update()
    {
        if(minaMezarlęk.minaGorev == true)
        {
            mapButton.SetActive(true);
            minagorevText.SetActive(true);
        }
        if(karaMezarlęk.karakolGorev == true)
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
