using DG.Tweening;
using TMPro;
using UnityEngine;

public class SedaSorgulama : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject interactionIndicator;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] UnityEngine.UI.Button option1Button;
    [SerializeField] UnityEngine.UI.Button option2Button;

    public bool seda = false;

    private bool isPlayerNear = false;
    private int dialogueStage = 0;

    void Start()
    {
        interactionIndicator.SetActive(false);
        dialoguePanel.SetActive(false);


        option1Button.onClick.AddListener(() => PlayerChoiceKara(1));
        option2Button.onClick.AddListener(() => PlayerChoiceKara(2));
        //option3Button.onClick.AddListener(() => PlayerChoiceKara(3));
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            dialoguePanel.SetActive(false);
            player.transform.rotation = Quaternion.Euler(0, 90, 0);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
            interactionIndicator.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            interactionIndicator.SetActive(false);
            dialoguePanel.SetActive(false);
        }
    }

    public void ShowDialogue()
    {
        interactionIndicator.SetActive(false);
        dialoguePanel.SetActive(true);
        if (dialogueStage == 0)
        {
            option1Button.GetComponentInChildren<TMP_Text>().text = " O gece neredeydin?";
            option2Button.GetComponentInChildren<TMP_Text>().text = "Meri� ile aran�z nas�ld�? ";
        }

        player.transform.DOMove(new Vector3(5, (float)7.45, 0), 2f);
        player.transform.rotation = Quaternion.Euler(0, 40, 0);
    }

    void PlayerChoiceKara(int choice)
    {
        if (dialogueStage == 0)
        {
            if (choice == 1)
            {
                dialogueText.text = "Ger�ekten, ben... bir �ey yapmad�m, Tekir. �nan bana. Sadece Meri�le anla�mazl�k ya�ad�k, ama bu... bu \r\n�ld�rmekle alakal� de�ildi. Hi�bir �ey de yapmad�m.";
                option1Button.GetComponentInChildren<TMP_Text>().text = " O gece neredeydin?";
                option2Button.GetComponentInChildren<TMP_Text>().text = "Meri� ile aran�z nas�ld�? ";
            }
            else if (choice == 2)
            {
                dialogueText.text = "Aram�z �ok da iyi de�ildi. Baz� i�ler konusunda birbirimizi hi� anlamazd�k. Ama... birini �ld�rmek... Asla. \r\nGer�ekten. Onu �ld�rmedim, Meri�i seviyorum, kimseye zarar vermek istemem.";
                option1Button.GetComponentInChildren<TMP_Text>().text = " O gece neredeydin?";
                option2Button.GetComponentInChildren<TMP_Text>().text = "Meri� ile aran�z nas�ld�? ";
            }

            dialogueStage = 0;
            seda = true;
        }
        //else if (dialogueStage == 1)
        //{
        //    if (choice == 1)
        //    {
        //        dialogueText.text = "Bak Tekir, ben su�lu de�ilim. Meri� benim i�in her zaman bir i� arkada��yd�, fazla ki�isel bir ba� \r\nkurmad�k. O y�zden, s�ylediklerimle yanl�� anla��ld�m san�r�m.";


        //        option1Button.GetComponentInChildren<TMP_Text>().text = " O gece neredeydin?";
        //        option2Button.GetComponentInChildren<TMP_Text>().text = "Meri� ile aran�z nas�ld�? ";



        //        option1Button.gameObject.SetActive(true);
        //        option2Button.gameObject.SetActive(true);

        //    }
        //    else if (choice == 2)
        //    {
        //        dialogueText.text = "Ger�ekten Meri�i seviyorum ama bu kadar i� odakl�yd� ki, ona bir �ey s�ylemek... Ger�ekten anlamad�m.";


        //        option1Button.GetComponentInChildren<TMP_Text>().text = " O gece neredeydin?";
        //        option2Button.GetComponentInChildren<TMP_Text>().text = "Meri� ile aran�z nas�ld�? ";



        //        option1Button.gameObject.SetActive(true);
        //        option2Button.gameObject.SetActive(true);

        //    }

            //dialogueStage = 0;
            //seda = true;

            
        //}
    }

}
