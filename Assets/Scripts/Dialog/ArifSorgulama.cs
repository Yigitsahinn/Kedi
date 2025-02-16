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
            option2Button.GetComponentInChildren<TMP_Text>().text = "Meri� ile aran�z nas�ld�? ";
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
                dialogueText.text = "O gece vardiyadayd�m. Zaten sabaha kadar �al��t�m. �al��t���m saatler boyunca s�rekli kameralar var. \r\nBir sorun yok, her �ey kay�tl�. Hem, benden ba�ka kimse yoktu ofiste.";
                option1Button.GetComponentInChildren<TMP_Text>().text = "Kameralar oldu�u i�in mi bu kadar rahats�n?";
            
                option2Button.gameObject.SetActive(false);

            }
            else if (choice == 2)
            {
                dialogueText.text = "Meri�i hep i� yerinde g�r�rd�m. Pek fazla sosyal hayat� yoktu, hep i�ini yapard�. Bir g�n benden telefon numaras�n� istemi�ti, ama hi� kullanmad�k.";
                option2Button.GetComponentInChildren<TMP_Text>().text = "Meri�le fazla samimi de�ildin yani.";
                option1Button.gameObject.SetActive(false);
                
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
                dialogueText.text = "Bak Tekir, ben su�lu de�ilim. Meri� benim i�in her zaman bir i� arkada��yd�, fazla ki�isel bir ba� \r\nkurmad�k. O y�zden, s�ylediklerimle yanl�� anla��ld�m san�r�m.";


                option1Button.GetComponentInChildren<TMP_Text>().text = " O gece neredeydin?";
                option2Button.GetComponentInChildren<TMP_Text>().text = "Meri� ile aran�z nas�ld�? ";



                option1Button.gameObject.SetActive(true);
                option2Button.gameObject.SetActive(true);
               
            }
            else if (choice == 2)
            {
                dialogueText.text = "Ger�ekten Meri�i seviyorum ama bu kadar i� odakl�yd� ki, ona bir �ey s�ylemek... Ger�ekten anlamad�m.";


                option1Button.GetComponentInChildren<TMP_Text>().text = " O gece neredeydin?";
                option2Button.GetComponentInChildren<TMP_Text>().text = "Meri� ile aran�z nas�ld�? ";



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
