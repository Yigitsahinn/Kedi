using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MinaMezarlık : MonoBehaviour
{
    [SerializeField] GameObject interactionIndicator;
    [SerializeField] GameObject dialoguePanel;
    [SerializeField] TMP_Text dialogueText;
    [SerializeField] Button option1Button;
    //[SerializeField] Button option2Button;
    //[SerializeField] Button option3Button;

    private bool isPlayerNear = false;
    public bool minaGorev = false;
    private int dialogueStage = 0;
    public void Close()
    {
        dialoguePanel.SetActive(false);
    }
    void Start()
    {
        interactionIndicator.SetActive(false);
        dialoguePanel.SetActive(false);


        option1Button.onClick.AddListener(() => PlayerChoiceMina(1));
        //option2Button.onClick.AddListener(() => PlayerChoiceMina(2));
        //option3Button.onClick.AddListener(() => PlayerChoiceMina(3));
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
            dialogueText.text = "Tekir eşimi yeni kaybettim konuşacak durumda değilim. Git başımdan.";
            minaGorev = true;
            option1Button.GetComponentInChildren<TMP_Text>().text = "Özür dilerim Mina, haklısın. Seni yalnız bırakayım";
            //option2Button.GetComponentInChildren<TMP_Text>().text = "O gece neden iş yerine geri döndü, fikrin var mı?";
            //option3Button.GetComponentInChildren<TMP_Text>().text = "Meriç’in düşmanı olabilecek biri var mıydı?";
        }
    }

    void PlayerChoiceMina(int choice)
    {
        if (dialogueStage == 0)
        {
            if (choice == 1)
            {
               
            }

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
