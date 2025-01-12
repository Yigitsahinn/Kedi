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
            option2Button.GetComponentInChildren<TMP_Text>().text = "Meriç ile aranýz nasýldý? ";
        }

        player.transform.DOMove(new Vector3(5, (float)-1.45, 0), 2f);
        player.transform.rotation = Quaternion.Euler(0, 40, 0);
    }

    void PlayerChoiceKara(int choice)
    {
        if (dialogueStage == 0)
        {
            if (choice == 1)
            {
                dialogueText.text = "Gerçekten, ben... bir þey yapmadým, Tekir. Ýnan bana. Sadece Meriç’le anlaþmazlýk yaþadýk, ama bu... bu \r\nöldürmekle alakalý deðildi. Hiçbir þey de yapmadým.";
                option1Button.GetComponentInChildren<TMP_Text>().text = " O gece neredeydin?";
                option2Button.GetComponentInChildren<TMP_Text>().text = "Meriç ile aranýz nasýldý? ";
            }
            else if (choice == 2)
            {
                dialogueText.text = "Aramýz çok da iyi deðildi. Bazý iþler konusunda birbirimizi hiç anlamazdýk. Ama... birini öldürmek... Asla. \r\nGerçekten. Onu öldürmedim, Meriç’i seviyorum, kimseye zarar vermek istemem.";
                option1Button.GetComponentInChildren<TMP_Text>().text = " O gece neredeydin?";
                option2Button.GetComponentInChildren<TMP_Text>().text = "Meriç ile aranýz nasýldý? ";
            }

            dialogueStage = 0;
            seda = true;
        }
        //else if (dialogueStage == 1)
        //{
        //    if (choice == 1)
        //    {
        //        dialogueText.text = "Bak Tekir, ben suçlu deðilim. Meriç benim için her zaman bir iþ arkadaþýydý, fazla kiþisel bir bað \r\nkurmadýk. O yüzden, söylediklerimle yanlýþ anlaþýldým sanýrým.";


        //        option1Button.GetComponentInChildren<TMP_Text>().text = " O gece neredeydin?";
        //        option2Button.GetComponentInChildren<TMP_Text>().text = "Meriç ile aranýz nasýldý? ";



        //        option1Button.gameObject.SetActive(true);
        //        option2Button.gameObject.SetActive(true);

        //    }
        //    else if (choice == 2)
        //    {
        //        dialogueText.text = "Gerçekten Meriç’i seviyorum ama bu kadar iþ odaklýydý ki, ona bir þey söylemek... Gerçekten anlamadým.";


        //        option1Button.GetComponentInChildren<TMP_Text>().text = " O gece neredeydin?";
        //        option2Button.GetComponentInChildren<TMP_Text>().text = "Meriç ile aranýz nasýldý? ";



        //        option1Button.gameObject.SetActive(true);
        //        option2Button.gameObject.SetActive(true);

        //    }

            //dialogueStage = 0;
            //seda = true;

            
        //}
    }

}
