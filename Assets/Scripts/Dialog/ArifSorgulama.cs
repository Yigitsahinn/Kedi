using DG.Tweening;
using TMPro;
using UnityEngine;

public class ArifSorgulama : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject interactionIndicator;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] UnityEngine.UI.Button option1Button;
    [SerializeField] UnityEngine.UI.Button option2Button;
    
    public bool arif = false;

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

        player.transform.DOMove(new Vector3(5, (float)0.45, 0), 2f);
        player.transform.rotation = Quaternion.Euler(0, 40, 0);
    }

    void PlayerChoiceKara(int choice)
    {
        if (dialogueStage == 0)
        {
            if (choice == 1)
            {
                dialogueText.text = "O gece vardiyadaydým. Zaten sabaha kadar çalýþtým. Çalýþtýðým saatler boyunca sürekli kameralar var. \r\nBir sorun yok, her þey kayýtlý. Hem, benden baþka kimse yoktu ofiste.";
                option1Button.GetComponentInChildren<TMP_Text>().text = "Kameralar olduðu için mi bu kadar rahatsýn?";
            
                option2Button.gameObject.SetActive(false);

            }
            else if (choice == 2)
            {
                dialogueText.text = "Meriç’i hep iþ yerinde görürdüm. Pek fazla sosyal hayatý yoktu, hep iþini yapardý. Bir gün benden telefon numarasýný istemiþti, ama hiç kullanmadýk.";
                option2Button.GetComponentInChildren<TMP_Text>().text = "Meriçle fazla samimi deðildin yani.";
                option1Button.gameObject.SetActive(false);
                
            }
           

            // Yeni seçenekleri göster
            //option1Button.GetComponentInChildren<TMP_Text>().text = "Tehlikeli mi? Ne demek istiyorsun?";
            //option2Button.GetComponentInChildren<TMP_Text>().text = "Peki ya son zamanlarda, þüphe duyduðu biri var mýydý? Ya da ona zarar vermek isteyen?\r\n";
            //option3Button.GetComponentInChildren<TMP_Text>().text = "Kara, baþýmýza bela olmasýndan korkacak mýyýz? Meriç’i kaybettik. Gerçek ne olursa olsun, ben öðrenmek zorundayým.\r\n";
            dialogueStage = 1;
        }
        else if (dialogueStage == 1)
        {
            if (choice == 1)
            {
                dialogueText.text = "Bak Tekir, ben suçlu deðilim. Meriç benim için her zaman bir iþ arkadaþýydý, fazla kiþisel bir bað \r\nkurmadýk. O yüzden, söylediklerimle yanlýþ anlaþýldým sanýrým.";


                option1Button.GetComponentInChildren<TMP_Text>().text = " O gece neredeydin?";
                option2Button.GetComponentInChildren<TMP_Text>().text = "Meriç ile aranýz nasýldý? ";



                option1Button.gameObject.SetActive(true);
                option2Button.gameObject.SetActive(true);
               
            }
            else if (choice == 2)
            {
                dialogueText.text = "Gerçekten Meriç’i seviyorum ama bu kadar iþ odaklýydý ki, ona bir þey söylemek... Gerçekten anlamadým.";


                option1Button.GetComponentInChildren<TMP_Text>().text = " O gece neredeydin?";
                option2Button.GetComponentInChildren<TMP_Text>().text = "Meriç ile aranýz nasýldý? ";



                option1Button.gameObject.SetActive(true);
                option2Button.gameObject.SetActive(true);
                
            }

            dialogueStage = 0;
            arif = true;

            //option1Button.gameObject.SetActive(false);
            //option2Button.gameObject.SetActive(false);
            //option3Button.gameObject.SetActive(false);


            //StartCoroutine(CloseDialogueAfterDelay(3f));
        }
    }

   

}
