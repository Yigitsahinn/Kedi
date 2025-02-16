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
                dialogueText.text = "Ne yap�yordum? Hadi bakal�m, hadi sor! Neredeydim, seni mi ilgilendiriyor? Yapma Tekir, bunlar� burada bana sormak ne demek? Beni sorguya �ekiyorsan... Kendi i�imi kendim yapar�m. Senin burada olman benimle alakal� de�il, do�ruyu s�ylemiyorsun, de�il mi? Neden benimle \r\nu�ra��yorsun?";
                option1Button.GetComponentInChildren<TMP_Text>().text = "Beni ��pheli mi san�yorsun Hakan? E�er ger�ekten bir �ey sakl�yorsan, s�yle. Geceyi nas�l ge�irdin? \r\nNeredeydin?";


            }
            


            // Yeni se�enekleri g�ster
            //option1Button.GetComponentInChildren<TMP_Text>().text = "Tehlikeli mi? Ne demek istiyorsun?";
            //option2Button.GetComponentInChildren<TMP_Text>().text = "Peki ya son zamanlarda, ��phe duydu�u biri var m�yd�? Ya da ona zarar vermek isteyen?\r\n";
            //option3Button.GetComponentInChildren<TMP_Text>().text = "Kara, ba��m�za bela olmas�ndan korkacak m�y�z? Meri�i kaybettik. Ger�ek ne olursa olsun, ben ��renmek zorunday�m.\r\n";
            dialogueStage = 1;
        }
        else if (dialogueStage == 1)
        {
            if (choice == 1)
            {
                dialogueText.text = "Bir dakika, ne dedi�ini bir daha duydum? Ben burada sana hesap m� verece�im? Bunu yapmaya hakk�m var m�, Tekir? Ne dersen de, art�k beni b�yle sorgulaman�n anlam� yok. Zaten ba�ka bir yere gitmek istiyorum. Yaln�z \r\nb�rak beni!";


                option1Button.GetComponentInChildren<TMP_Text>().text = " O gece neredeydin?";

                option1Button.gameObject.SetActive(true);

            }
           

            dialogueStage = 0;
            hakan = true;

          
        }
    }

}
