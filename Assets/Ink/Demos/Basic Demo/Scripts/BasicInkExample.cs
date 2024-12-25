using System;
using Ink.Runtime;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// This is a super bare bones example of how to play and display a ink story in Unity.
public class BasicInkExample : MonoBehaviour {
    public static event Action<Story> OnCreateStory;
    [SerializeField] private TextAsset inkJSONAsset;
    [SerializeField] public Story story;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject interactPanel;
	[SerializeField] private GameObject npcIcon;
    [SerializeField] private TextMeshProUGUI textPrefab;
    [SerializeField] private Button buttonPrefab;

	private bool isPlayerNear = false;

	//private void Awake()
	//{
	//	ShowDialog();
	//}
	//private void Update()
	//{
	//	if (isPlayerNear && Input.GetMouseButtonDown(0))
	//	{
	//		interactPanel.SetActive(false);
	//		ShowDialog();
	//	}
	//}
	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			isPlayerNear = true;
			interactPanel.SetActive(true);
		}
	}
	void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player"))
		{
            RemoveChildren();
            interactPanel.SetActive(false);
            npcIcon.SetActive(false);
            panel.SetActive(false);
        }
	}
	public void ShowDialog()
	{
		interactPanel.SetActive(false);
		panel.SetActive(true);
        RemoveChildren();
        StartStory();
		npcIcon.SetActive(true);
    }
	// Creates a new Story object with the compiled story which we can then play!
	void StartStory () {
		story = new Story (inkJSONAsset.text);
        if(OnCreateStory != null) OnCreateStory(story);
		RefreshView();
	}
	
	// This is the main function called every time the story changes. It does a few things:
	// Destroys all the old content and choices.
	// Continues over all the lines of text, then displays all the choices. If there are no choices, the story is finished!
	void RefreshView () {
		// Remove all the UI on screen
		RemoveChildren ();
		
		// Read all the content until we can't continue any more
		while (story.canContinue) {
			// Continue gets the next line of the story
			string text = story.Continue ();
			// This removes any white space from the text.
			text = text.Trim();
			// Display the text on screen!
			CreateContentView(text);
		}

		// Display all the choices, if there are any!
		if(story.currentChoices.Count > 0) {
			for (int i = 0; i < story.currentChoices.Count; i++) {
				Choice choice = story.currentChoices [i];
				Button button = CreateChoiceView (choice.text.Trim ());
				// Tell the button what to do when we press it
				button.onClick.AddListener (delegate {
					OnClickChoiceButton (choice);
				});
			}
		}
		// If we've read all the content and there's no choices, the story is finished!
		else {
			Button choice = CreateChoiceView("End of story.\nRestart?");
			choice.onClick.AddListener(delegate{
				StartStory();
			});
		}
	}

	// When we click the choice button, tell the story to choose that choice!
	void OnClickChoiceButton (Choice choice) {
		story.ChooseChoiceIndex (choice.index);
		RefreshView();
	}

	// Creates a textbox showing the the line of text
	void CreateContentView (string text) {
        TextMeshProUGUI storyText = Instantiate(textPrefab) as TextMeshProUGUI;
		storyText.text = text;
		storyText.transform.SetParent (panel.transform, false);
	}

	// Creates a button showing the choice text
	Button CreateChoiceView (string text) {
		// Creates the button from a prefab
		Button choice = Instantiate (buttonPrefab) as Button;
		choice.transform.SetParent (panel.transform, false);
		
		// Gets the text from the button prefab
		TextMeshProUGUI choiceText = choice.GetComponentInChildren<TextMeshProUGUI>();
		choiceText.text = text;

		// Make the button expand to fit the text
		VerticalLayoutGroup layoutGroup = choice.GetComponent <VerticalLayoutGroup> ();
		layoutGroup.childForceExpandHeight = false;

		return choice;
	}

	// Destroys all the children of this gameobject (all the UI)
	void RemoveChildren () {
		int childCount = panel.transform.childCount;
		for (int i = childCount - 1; i >= 0; --i) {
			Destroy (panel.transform.GetChild (i).gameObject);
		}
	}

	
}
