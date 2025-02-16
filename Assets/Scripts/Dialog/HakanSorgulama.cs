using DG.Tweening;
using TMPro;
using UnityEngine;

public class HakanSorgulama : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject interactionIndicator;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] UnityEngine.UI.Button option1Button;


    public bool hakan = false;

    private bool isPlayerNear = false;
    private int dialogueStage = 0;

    void Start()
    {
        interactionIndicator.SetActive(false);
        dialoguePanel.SetActive(false);


        option1Button.onClick.AddListener(() => PlayerChoiceKara(1));
        //option2Button.onClick.AddListener(() => PlayerChoiceKara(2));
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
            
        }

        player.transform.DOMove(new Vector3(5, (float)14.45, 0), 2f);
        player.transform.rotation = Quaternion.Euler(0, 40, 0);
    }

    void PlayerChoiceKara(int choice)
    {
        if (dialogueStage == 0)
        {
            if (choice == 1)
            {
                dialogueText.text = "Ne yapýyordum? Hadi bakalým, hadi sor! Neredeydim, seni mi ilgilendiriyor? Yapma Tekir, bunlarý burada bana sormak ne demek? Beni sorguya çekiyorsan... Kendi iþimi kendim yaparým. Senin burada olman benimle alakalý deðil, doðruyu söylemiyorsun, deðil mi? Neden benimle \r\nuðraþýyorsun?";
                option1Button.GetComponentInChildren<TMP_Text>().text = "Beni þüpheli mi sanýyorsun Hakan? Eðer gerçekten bir þey saklýyorsan, söyle. Geceyi nasýl geçirdin? \r\nNeredeydin?";


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
                dialogueText.text = "Bir dakika, ne dediðini bir daha duydum? Ben burada sana hesap mý vereceðim? Bunu yapmaya hakkým var mý, Tekir? Ne dersen de, artýk beni böyle sorgulamanýn anlamý yok. Zaten baþka bir yere gitmek istiyorum. Yalnýz \r\nbýrak beni!";


                option1Button.GetComponentInChildren<TMP_Text>().text = " O gece neredeydin?";

                option1Button.gameObject.SetActive(true);

            }
           

            dialogueStage = 0;
            hakan = true;

          
        }
    }

}
