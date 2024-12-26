using TMPro;
using UnityEngine;

public class Suspect : MonoBehaviour
{
    [SerializeField] private string suspectName;
    [SerializeField] private TMP_Text text;


    private void Start()
    {
        text.SetText(suspectName);
    }
    public void EliminateSuspect()
    {
        gameObject.SetActive(false);
    }


    public string getSuspectName() => suspectName;

}
