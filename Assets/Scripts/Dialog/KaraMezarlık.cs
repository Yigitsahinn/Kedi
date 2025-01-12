using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;
using DG.Tweening;


public class KaraMezarlýk : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject interactionIndicator;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] UnityEngine.UI.Button option1Button;
    [SerializeField] UnityEngine.UI.Button option2Button;
    [SerializeField] UnityEngine.UI.Button option3Button;
    [SerializeField] private MovementScript playerAnim;


    private bool isPlayerNear = false;
    public bool karakolGorev = false;
    private int dialogueStage = 0;
    private Animator animator;

    void Start()
    {
        interactionIndicator.SetActive(false);
        dialoguePanel.SetActive(false);


        option1Button.onClick.AddListener(() => PlayerChoiceKara(1));
        option2Button.onClick.AddListener(() => PlayerChoiceKara(2));
        option3Button.onClick.AddListener(() => PlayerChoiceKara(3));
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
            option1Button.GetComponentInChildren<TMP_Text>().text = "Meriç’in iþ yerine neden döndüðünü biliyor musun?";
            option2Button.GetComponentInChildren<TMP_Text>().text = "Sence Meriç'in düþmaný olabilir mi?";
            option3Button.GetComponentInChildren<TMP_Text>().text = "O gece garip bir þey fark ettin mi?";
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
                dialogueText.text = "Bak, ben de bilmiyorum, ama Meriç’in bir derdi olduðunu sezmiþtim. O gece neden iþ yerine döndüðünü kimse anlamadý. Belki bir þeyini unuttu diye düþündük ama... Tekir, sen de bilirsin, o saatte merkezde bulunmak tehlikelidir.\r\n";
                option1Button.GetComponentInChildren<TMP_Text>().text = "Tehlikeli mi? Ne demek istiyorsun?";
                option3Button.gameObject.SetActive(false);
                option2Button.gameObject.SetActive(false);

            }
            else if (choice == 2)
            {
               dialogueText.text = "Bazen duyduðu bir isim hakkýnda endiþelendiðini biliyorum, ama kim olduðunu asla söylemedi. Tekir, belki ona yeterince yakýn olsaydýk bunu öðrenebilirdik, ama o bu sýrlarý kendiyle götürdü.\r\n";
                option2Button.GetComponentInChildren<TMP_Text>().text = "Peki ya son zamanlarda, þüphe duyduðu biri var mýydý? Ya da ona zarar vermek isteyen?\r\n";
                option1Button.gameObject.SetActive(false);
                option3Button.gameObject.SetActive(false);
            }
            else if (choice == 3)
            {
                dialogueText.text = "Belki... iþin içinde baþka kediler de vardý. Bu konuda çok soru sorma, Tekir. Bu mesele ne kadar kurcalanýrsa baþýmýza bela olabilir.\r\n";
                option3Button.GetComponentInChildren<TMP_Text>().text = "Kara, baþýmýza bela olmasýndan korkacak mýyýz? Meriç’i kaybettik. Gerçek ne olursa olsun, ben öðrenmek zorundayým.\r\n";
                option1Button.gameObject.SetActive(false);
                option2Button.gameObject.SetActive(false);
                karakolGorev = true;
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
                dialogueText.text = "Bir kedi o saatte yalnýz kalmaktan hoþlanmaz, ama Meriç geri döndü. Kimseyle paylaþmadýðý bir þey mi vardý bilmiyorum. Belki de sana anlatýrdý… ama artýk onu bilemeyeceðiz.\r\n";
                
                
                option1Button.GetComponentInChildren<TMP_Text>().text = "Meriç’in iþ yerine neden döndüðünü biliyor musun?";
                option2Button.GetComponentInChildren<TMP_Text>().text = "Sence Meriç'in düþmaný olabilir mi?”";
                option3Button.GetComponentInChildren<TMP_Text>().text = "O gece garip bir þey fark ettin mi?";
                
                
                option1Button.gameObject.SetActive(true);
                option2Button.gameObject.SetActive(true);
                option3Button.gameObject.SetActive(true);
            }
            else if (choice == 2)
            {
                dialogueText.text = "Meriç'in düþmaný? Bilmem, Tekir. Meriç düþman kazanacak bir kedi deðildi, ama bazen geçmiþinden gelen sorunlarla boðuþurdu. Bu da onun durgun ve düþünceli görünmesine neden olurdu.\r\n";
                
                
                option1Button.GetComponentInChildren<TMP_Text>().text = "Meriç’in iþ yerine neden döndüðünü biliyor musun?";
                option2Button.GetComponentInChildren<TMP_Text>().text = "Sence Meriç'in düþmaný olabilir mi?”";
                option3Button.GetComponentInChildren<TMP_Text>().text = "O gece garip bir þey fark ettin mi?";


                option1Button.gameObject.SetActive(true);
                option2Button.gameObject.SetActive(true);
                option3Button.gameObject.SetActive(true);
            }
            else if (choice == 3)
            {
                dialogueText.text = "O gece, birkaç kez iþ yerinin ýþýklarýnýn açýlýp kapandýðýný duydum. Belki orada deðildim ama gözümden bir þey kaçmaz. Anladýn mý?\r\n";
                

                option1Button.GetComponentInChildren<TMP_Text>().text = "Meriç’in iþ yerine neden döndüðünü biliyor musun?";
                option2Button.GetComponentInChildren<TMP_Text>().text = "Sence Meriç'in düþmaný olabilir mi?”";
                option3Button.GetComponentInChildren<TMP_Text>().text = "O gece garip bir þey fark ettin mi?";


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
