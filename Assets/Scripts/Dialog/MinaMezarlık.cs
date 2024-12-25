using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MinaMezarlık : MonoBehaviour
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


        option1Button.onClick.AddListener(() => PlayerChoiceMina(1));
        option2Button.onClick.AddListener(() => PlayerChoiceMina(2));
        option3Button.onClick.AddListener(() => PlayerChoiceMina(3));
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
            option1Button.GetComponentInChildren<TMP_Text>().text = "Meriç son zamanlarda garip davranıyor muydu?";
            option2Button.GetComponentInChildren<TMP_Text>().text = "O gece neden iş yerine geri döndü, fikrin var mı?";
            option3Button.GetComponentInChildren<TMP_Text>().text = "Meriç’in düşmanı olabilecek biri var mıydı?";
        }
    }

    void PlayerChoiceMina(int choice)
    {
        if (dialogueStage == 0)
        {
            if (choice == 1)
            {
                dialogueText.text = "Evet, Tekir. Son günlerde çok dalgındı. Geceleri geç saatlerde eve geliyordu, hiç kimseye anlatmadığı bir şeyler vardı.\r\n";
                option1Button.GetComponentInChildren<TMP_Text>().text = "Hiç bir şey söylemedi mi? Belki seninle konuşmak istemiştir.\r\n";
                option3Button.gameObject.SetActive(false);
                option2Button.gameObject.SetActive(false);

            }
            else if (choice == 2)
            {
                dialogueText.text = "O gece biraz huzursuzdu, ama neden olduğunu hiç anlamadım. Gece yarısı ansızın kalktı, bana da hiçbir şey söylemedi.";
                option2Button.GetComponentInChildren<TMP_Text>().text = "Normalde böyle bir şey yapmazdı değil mi? Onun için iş yerine bu saatte dönmek çok alışılmadık.\r\n";
                option1Button.gameObject.SetActive(false);
                option3Button.gameObject.SetActive(false);
            }
            else if (choice == 3)
            {
                dialogueText.text = "Meriç’in düşmanı mı? Bilmiyorum, Tekir, ama bazı şeyler saklıydı benden. Ona zarar vermek isteyen biri... belki de geçmişinden gelen sorunları vardı. O kendine güvenirdi, ama kim bilebilir…\r\n";
                option3Button.GetComponentInChildren<TMP_Text>().text = "Belki de dostları dışında, başkalarından korkuyordu.\r\n";
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
                dialogueText.text = "Belki denedi, ama hep kaçamak cevaplar verirdi. Üzerinde büyük bir yük taşıyor gibiydi, Tekir. Ama ona ne olduğunu bilmeden ben de yardım edemedim.\r\n";
                option1Button.GetComponentInChildren<TMP_Text>().text = "Meriç son zamanlarda garip davranıyor muydu?";
                option2Button.GetComponentInChildren<TMP_Text>().text = "O gece neden iş yerine geri döndü, fikrin var mı?";
                option3Button.GetComponentInChildren<TMP_Text>().text = "Meriç’in düşmanı olabilecek biri var mıydı?";
                option1Button.gameObject.SetActive(true);
                option2Button.gameObject.SetActive(true);
                option3Button.gameObject.SetActive(true);
            }
            else if (choice == 2)
            {
                dialogueText.text = ": Evet, ama ne olduğunu sordum. Sadece, “Bir şey unuttum,” dedi. Halbuki biliyorum, o hiçbir şeyini unutan bir kedi değildi.\r\n";
                option1Button.GetComponentInChildren<TMP_Text>().text = "Meriç son zamanlarda garip davranıyor muydu?";
                option2Button.GetComponentInChildren<TMP_Text>().text = "O gece neden iş yerine geri döndü, fikrin var mı?";
                option3Button.GetComponentInChildren<TMP_Text>().text = "Meriç’in düşmanı olabilecek biri var mıydı?";
                option1Button.gameObject.SetActive(true);
                option2Button.gameObject.SetActive(true);
                option3Button.gameObject.SetActive(true);
            }
            else if (choice == 3)
            {
                dialogueText.text = "Tekir, ne bulursan bul, lütfen bana da anlat. Gerçek ne olursa olsun, bilmek istiyorum.\r\n";
                option1Button.GetComponentInChildren<TMP_Text>().text = "Meriç son zamanlarda garip davranıyor muydu?";
                option2Button.GetComponentInChildren<TMP_Text>().text = "O gece neden iş yerine geri döndü, fikrin var mı?";
                option3Button.GetComponentInChildren<TMP_Text>().text = "Meriç’in düşmanı olabilecek biri var mıydı?";
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
