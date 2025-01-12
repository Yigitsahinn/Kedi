using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ArkadaşKafe : MonoBehaviour
{
    [SerializeField] GameObject interactionIndicator;
    [SerializeField] GameObject dialoguePanel;
    [SerializeField] TMP_Text dialogueText;
    [SerializeField] Button option1Button;
    [SerializeField] Button option2Button;
    [SerializeField] Button option3Button;
    [SerializeField] Button option4Button;
    public ItemData item;

    private bool isPlayerNear = false;
    private int dialogueStage = 0;

    void Start()
    {
        interactionIndicator.SetActive(false);
        dialoguePanel.SetActive(false);


        option1Button.onClick.AddListener(() => PlayerChoiceKara(1));
        option2Button.onClick.AddListener(() => PlayerChoiceKara(2));
        option3Button.onClick.AddListener(() => PlayerChoiceKara(3));
        option3Button.onClick.AddListener(() => PlayerChoiceKara(4));
    }

    void Update()
    {

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
    public void Close()
    {
        dialoguePanel.SetActive(false);
    }
    public void ShowDialogue()
    {
        interactionIndicator.SetActive(false);
        dialoguePanel.SetActive(true);
        if (dialogueStage == 0)
        {
            dialogueText.text = "Tekir: Meriç’in ölümünden önce seninle sık sık görüştüğünü biliyorum. Bana yardımcı olabilecek bir şeyler söyleyebilir misin?\r\n" +
                "Bak Tekir, Meriç benim dostumdu. Onun başına gelenleri duyunca şok oldum, ama fazla bir şey bilmiyorum. Yine de elimden geldiğince yardımcı olmaya çalışırım.\r\n";
            option1Button.GetComponentInChildren<TMP_Text>().text = "Birisi Meriç’i tehdit etmiş olabilir. Bu konuda bir şey duydun mu?\r\n";
            option2Button.GetComponentInChildren<TMP_Text>().text = "Meriç neden son zamanlarda gergindi? Sence bir şeyden mi korkuyordu?";
            option3Button.GetComponentInChildren<TMP_Text>().text = "O telefonda ne konuştuğunu hatırlıyor musun? Belki bir ipucu yakalayabiliriz.\r\n";
        }
    }

    void PlayerChoiceKara(int choice)
    {
        if (dialogueStage == 0)
        {
            if (choice == 1)
            {
                dialogueText.text = "Açık konuşayım, evet, bir şey duydum. Birkaç hafta önce Meriç, karakoldan biriyle telefonda kavga ediyordu. Ses tonu gerçekten sertti. Ama kim olduğunu söylemedi. O sırada sormadım, çünkü Meriç genelde böyle şeyleri kendi çözmek isterdi.\r\n";

            }
            else if (choice == 2)
            {
                dialogueText.text = "O gece bana garip bir şey söyledi. “Eğer bir şey olursa, bana güvenebilirsin,” dedi. Ne demek istediğini tam anlamadım, ama birinin ona zarar vermesinden endişe ettiği belliydi. Ama bunun kiminle ilgili olduğunu asla söylemedi.\r\n";
            }
            else if (choice == 3)
            {
                dialogueText.text = "Tekir, ben de o konuşmayı tam anlamadım. Sadece “Bu böyle gitmez, ya sen ya ben!” gibi bir şey dediğini hatırlıyorum. Kimle konuştuğunu bilmiyorum. Meriç sonrasında konuşmayı kapatıp bir süre sessiz kaldı.\r\n";
                option3Button.GetComponentInChildren<TMP_Text>().text = "Bak, dostum, Meriç hepimize değer verirdi. Eğer bana bir şey saklıyorsan, bunu bilmek zorundayım. %45";
                option1Button.gameObject.SetActive(false);
                option2Button.gameObject.SetActive(false);
            }
            
                dialogueStage = 1;
        }
        else if (dialogueStage == 1)
        {
            if (choice == 3)
            {
                int roll = Random.Range(1, 11);
                if (roll < 11)
                {
                    dialogueText.text = "Tamam, tamam… Son konuşmamızda bir şey söyledi. Karakoldaki gri tüylü bir kediyle ilgiliydi. İsim vermedi ama açıkça ona güvenmediğini belli etti. Daha fazlasını bilmiyorum.\r\n";
                    InventoryManager.Instance.AddItem(item);
                    //dialogueText.text = "Tekir, sana söyledim işte! Daha fazlasını bilmiyorum. Beni sıkıştırmayı bırak!\r\n";
                }
                //else
                //{
                //    dialogueText.text = "Tamam, tamam… Son konuşmamızda bir şey söyledi. Karakoldaki gri tüylü bir kediyle ilgiliydi. İsim vermedi ama açıkça ona güvenmediğini belli etti. Daha fazlasını bilmiyorum.\r\n";
                //    InventoryManager.Instance.AddItem(item);
                //}

                option4Button.GetComponentInChildren<TMP_Text>().text = "Meriç’in ölümüyle ilgili gerçeği bulacağım. Eğer başka bir şey hatırlarsan, bana haber ver.\r\n";


                option1Button.gameObject.SetActive(false);
                option2Button.gameObject.SetActive(false);
                option3Button.gameObject.SetActive(false);
                option4Button.gameObject.SetActive(true);

                if (choice == 4) 
                {                    
                  dialoguePanel.gameObject.SetActive(false);
                }
            }

            

            //option1Button.gameObject.SetActive(false);
            //option2Button.gameObject.SetActive(false);
            //option3Button.gameObject.SetActive(false);


           
        }
    }
}

