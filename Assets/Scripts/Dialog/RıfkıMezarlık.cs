using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RıfkıMezarlık : MonoBehaviour
{
    [SerializeField] GameObject interactionIndicator;
    [SerializeField] GameObject dialoguePanel;
    [SerializeField] TMP_Text dialogueText;
    [SerializeField] Button option1Button;
    [SerializeField] Button option2Button;
    [SerializeField] Button option3Button;

    private bool isPlayerNear = false;
    private int dialogueStage = 0;

    void Start()
    {
        interactionIndicator.SetActive(false);
        dialoguePanel.SetActive(false);


        option1Button.onClick.AddListener(() => PlayerChoiceRıfkı(1));
        option2Button.onClick.AddListener(() => PlayerChoiceRıfkı(2));
        option3Button.onClick.AddListener(() => PlayerChoiceRıfkı(3));
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

    public void ShowDialogue()
    {
        interactionIndicator.SetActive(false);
        dialoguePanel.SetActive(true);
        if (dialogueStage == 0)
        {
            option1Button.GetComponentInChildren<TMP_Text>().text = "Son zamanlarda Meriç’i gergin gördün mü?";
            option2Button.GetComponentInChildren<TMP_Text>().text = "O gece iş yerinde ışık yandığını söylemiştin, başka bir şey fark ettin mi?";
            option3Button.GetComponentInChildren<TMP_Text>().text = "Meriç’in düşmanı olabileceğini düşünüyor musun?";
        }
    }

    void PlayerChoiceRıfkı(int choice)
    {
        if (dialogueStage == 0)
        {
            if (choice == 1)
            {
                dialogueText.text = "Evet, Tekir. Son zamanlarda çok sıkıntılıydı. Sanki bir şeyden kaçıyordu. Neyin peşindeydi, bilmiyorum ama yüzündeki o ifadeyi görmek bile içimi burkuyordu.\r\n";
                option1Button.GetComponentInChildren<TMP_Text>().text = "Peki, hiç seninle bir şeyler paylaştı mı? Belki dertleşmek istemiştir.\r\n";
                option3Button.gameObject.SetActive(false);
                option2Button.gameObject.SetActive(false);

            }
            else if (choice == 2)
            {
                dialogueText.text = "Şey... aslında o gece bir gölge fark ettim, iş yerinin arkasında. Belki başka bir kediydi, ya da sadece gözüm yanıldı. Ama o saatte orada olmaması gerekirdi.\r\n";
                option2Button.GetComponentInChildren<TMP_Text>().text = "Bir gölge mi? Tanıdık biri miydi?\r\n";
                option1Button.gameObject.SetActive(false);
                option3Button.gameObject.SetActive(false);
            }
            else if (choice == 3)
            {
                dialogueText.text = "Düşman mı? Hayır, ama Meriç her zaman tehlikeli işlerle uğraşırdı, belki de biriyle sorun yaşamıştır.";
                option3Button.GetComponentInChildren<TMP_Text>().text = "Meriç’i bu kadar tedirgin edecek ne olabilir ki? Bir tehdit mi aldığını düşünüyor musun?\r\n";
                option1Button.gameObject.SetActive(false);
                option2Button.gameObject.SetActive(false);
            }

            // Yeni seçenekleri göster
            //option1Button.GetComponentInChildren<TMP_Text>().text = "Tehlikeli mi? Ne demek istiyorsun?";
            //option2Button.GetComponentInChildren<TMP_Text>().text = "Peki ya son zamanlarda, şüphe duyduğu biri var mıydı? Ya da ona zarar vermek isteyen?\r\n";
            //option3Button.GetComponentInChildren<TMP_Text>().text = "Kara, başımıza bela olmasından korkacak mıyız? Meriç’i kaybettik. Gerçek ne olursa olsun, ben öğrenmek zorundayım.\r\n";
            dialogueStage = 1;
        }
        else if (dialogueStage == 1)
        {
            if (choice == 1)
            {
                dialogueText.text = "Birkaç defa denedim, ama hep sustu. 'Sen işine bak Rıfkı' derdi. Belki seni aramak istemiştir, kim bilir...\r\n";

                option1Button.GetComponentInChildren<TMP_Text>().text = "Son zamanlarda Meriç’i gergin gördün mü?";
                option2Button.GetComponentInChildren<TMP_Text>().text = "O gece iş yerinde ışık yandığını söylemiştin, başka bir şey fark ettin mi?";
                option3Button.GetComponentInChildren<TMP_Text>().text = "Meriç’in düşmanı olabileceğini düşünüyor musun?";

                option1Button.gameObject.SetActive(true);
                option2Button.gameObject.SetActive(true);
                option3Button.gameObject.SetActive(true);
            }
            else if (choice == 2)
            {
                dialogueText.text = "Net göremedim, sadece bir anlık bir harekettir belki... ama tüylerim diken diken oldu, Tekir. Oraya geri dönmesi için hiçbir neden yoktu.\r\n";

                option1Button.GetComponentInChildren<TMP_Text>().text = "Son zamanlarda Meriç’i gergin gördün mü?";
                option2Button.GetComponentInChildren<TMP_Text>().text = "O gece iş yerinde ışık yandığını söylemiştin, başka bir şey fark ettin mi?";
                option3Button.GetComponentInChildren<TMP_Text>().text = "Meriç’in düşmanı olabileceğini düşünüyor musun?";

                option1Button.gameObject.SetActive(true);
                option2Button.gameObject.SetActive(true);
                option3Button.gameObject.SetActive(true);
            }
            else if (choice == 3)
            {
                dialogueText.text = "Bilmem, ama bazı şeyleri bize anlatmadığı ortada. Belki de sana anlatmak isterdi. Sen onun dostuydun, Tekir.\r\n";

                option1Button.GetComponentInChildren<TMP_Text>().text = "Son zamanlarda Meriç’i gergin gördün mü?";
                option2Button.GetComponentInChildren<TMP_Text>().text = "O gece iş yerinde ışık yandığını söylemiştin, başka bir şey fark ettin mi?";
                option3Button.GetComponentInChildren<TMP_Text>().text = "Meriç’in düşmanı olabileceğini düşünüyor musun?";

                option1Button.gameObject.SetActive(true);
                option2Button.gameObject.SetActive(true);
                option3Button.gameObject.SetActive(true);
            }

            dialogueStage = 0;

            //option1Button.gameObject.SetActive(false);
            //option2Button.gameObject.SetActive(false);
            //option3Button.gameObject.SetActive(false);


            //StartCoroutine(CloseDialogueAfterDelay(3f));
        }
    }

    //IEnumerator CloseDialogueAfterDelay(float delay)
    //{
    //    yield return new WaitForSeconds(delay);
    //    dialoguePanel.SetActive(false);
    //    option1Button.gameObject.SetActive(true);
    //    option2Button.gameObject.SetActive(true);
    //    dialogueStage = 0;
    //}

}
