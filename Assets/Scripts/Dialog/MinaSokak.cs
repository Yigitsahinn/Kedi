using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MinaSokak : MonoBehaviour
{
    [SerializeField] GameObject interactionIndicator;
    [SerializeField] GameObject dialoguePanel;
    [SerializeField] GameObject uygarPanel;
    [SerializeField] GameObject uygarText;
    [SerializeField] TMP_Text dialogueText;
    [SerializeField] Button option1Button;
    [SerializeField] Button option2Button;
    [SerializeField] Button option3Button;

    private bool isPlayerNear = false;
    private int dialogueStage = 0;
    GameManager gameManager;

    private void Awake()
    {
        gameManager = GetComponent<GameManager>();
    }
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
        dialogueText.text = "Tekir: Mina, Meriç’in ölümüyle ilgili bazý sorularým var. Onu en iyi tanýyanlardan birisin, bu konuda bana yardýmcý olabilir misin?\r\n" +
            "Mina: (Hüzünlü bir ifadeyle) Tabii ki, Tekir. Bu durumda elimden ne gelirse yaparým… Meriç hak ettiði þekilde anýlmalý.";
        if (dialogueStage == 0)
        {
            option1Button.GetComponentInChildren<TMP_Text>().text = "Son zamanlarda Meriç’in garip davrandýðýný fark ettin mi?";
            option2Button.GetComponentInChildren<TMP_Text>().text = "Meriç’in düþmaný olabilecek biri var mýydý?";
            option3Button.GetComponentInChildren<TMP_Text>().text = "Meriç’in özel bir þeyini biliyor musun? Günlük gibi bir þey tuttuðunu fark ettin mi?";
        }
        
    }

    void PlayerChoiceMina(int choice)
    {
        if (dialogueStage == 0)
        {
            if (choice == 1)
            {
                dialogueText.text = "Þimdi düþününce, evet... Son haftalarda biraz dalgýndý. Ama bana bir þey anlatmadý. Belki iþ stresi... Çok sýk görüþemiyorduk, ama bir þeylerin onu rahatsýz ettiði belliydi.\r\n";
                

            }
            else if (choice == 2)
            {
                dialogueText.text = "Meriç genelde insanlarla iyi geçinirdi. Ama son zamanlarda bir telefon konuþmasýna denk geldim. Birine sinirli bir þekilde baðýrýyordu, ama kim olduðunu bilmiyorum. Ondan sonra sessizleþmiþti… Belki bu önemli bir þeydir. Belki Uygar bir þey biliyordur Meriç'le uzun zamandýr arkadaþlar.";
                uygarPanel.SetActive(true);
                uygarText.SetActive(true);

            }
            else if (choice == 3)
            {
                dialogueText.text = "Aslýnda… Evet. Çok sevdiði küçük bir not defteri vardý. Çoðu zaman yanýnda taþýdýðýný bilirim. Ýçine sadece önemli þeyleri yazdýðýný söylerdi. Ama nerede olduðunu bilmiyorum. Belki evinde ya da karakolda olabilir.\r\n";

            }

            // Yeni seçenekleri göster
            //option1Button.GetComponentInChildren<TMP_Text>().text = "Tehlikeli mi? Ne demek istiyorsun?";
            //option2Button.GetComponentInChildren<TMP_Text>().text = "Peki ya son zamanlarda, þüphe duyduðu biri var mýydý? Ya da ona zarar vermek isteyen?\r\n";
            //option3Button.GetComponentInChildren<TMP_Text>().text = "Kara, baþýmýza bela olmasýndan korkacak mýyýz? Meriç’i kaybettik. Gerçek ne olursa olsun, ben öðrenmek zorundayým.\r\n";
            //dialogueStage = 1;
        }
        else if (dialogueStage == 1)
        {
            if (choice == 1)
            {
                dialogueText.text = "Belki denedi, ama hep kaçamak cevaplar verirdi. Üzerinde büyük bir yük taþýyor gibiydi, Tekir. Ama ona ne olduðunu bilmeden ben de yardým edemedim.\r\n";
                option1Button.GetComponentInChildren<TMP_Text>().text = "Meriç son zamanlarda garip davranýyor muydu?";
                option2Button.GetComponentInChildren<TMP_Text>().text = "O gece neden iþ yerine geri döndü, fikrin var mý?";
                option3Button.GetComponentInChildren<TMP_Text>().text = "Meriç’in düþmaný olabilecek biri var mýydý?";
                option1Button.gameObject.SetActive(true);
                option2Button.gameObject.SetActive(true);
                option3Button.gameObject.SetActive(true);
            }
            else if (choice == 2)
            {
                dialogueText.text = ": Evet, ama ne olduðunu sordum. Sadece, “Bir þey unuttum,” dedi. Halbuki biliyorum, o hiçbir þeyini unutan bir kedi deðildi.\r\n";
                option1Button.GetComponentInChildren<TMP_Text>().text = "Meriç son zamanlarda garip davranýyor muydu?";
                option2Button.GetComponentInChildren<TMP_Text>().text = "O gece neden iþ yerine geri döndü, fikrin var mý?";
                option3Button.GetComponentInChildren<TMP_Text>().text = "Meriç’in düþmaný olabilecek biri var mýydý?";
                option1Button.gameObject.SetActive(true);
                option2Button.gameObject.SetActive(true);
                option3Button.gameObject.SetActive(true);
            }
            else if (choice == 3)
            {
                dialogueText.text = "Tekir, ne bulursan bul, lütfen bana da anlat. Gerçek ne olursa olsun, bilmek istiyorum.\r\n";
                option1Button.GetComponentInChildren<TMP_Text>().text = "Meriç son zamanlarda garip davranýyor muydu?";
                option2Button.GetComponentInChildren<TMP_Text>().text = "O gece neden iþ yerine geri döndü, fikrin var mý?";
                option3Button.GetComponentInChildren<TMP_Text>().text = "Meriç’in düþmaný olabilecek biri var mýydý?";
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
