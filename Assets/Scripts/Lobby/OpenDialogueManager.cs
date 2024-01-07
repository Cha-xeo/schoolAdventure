using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using SchoolAdventure.Input;
using UnityEngine.SceneManagement;
using SchoolAdventure.AplicationController;
using UnityEngine.Diagnostics;

public class OpenDialogueManager : MonoBehaviour
{
    private float _timer = 0.0f;
    [SerializeField] private float _submitSpeed;
    [Header("Audio")]
    public AudioClip soundEffect;
   // [SerializeField] private Transform camTransform;
    [Header("Params")]
    [SerializeField] private float typingSpeed = 0.04f;
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
     [SerializeField] private GameObject continueIcon;

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;
    private static OpenDialogueManager instance;
    private bool canContinueToNextLine = false;
    private Coroutine displayLineCoroutine;

    public Story currentStory;
    public PlayerController _player;
    public bool dialogueIsPlaying {get; private set; }

    public VectorValue playerStorage;
    public LobbyIndicator lb;


    private void Awake() {
        instance = this;
    }

    public static OpenDialogueManager GetInstance()
    {
        return (instance) ? instance : null;
    }
    // Start is called before the first frame update
    void Start()
    {
        if (AplicationController.Instance.isQuitLobby == true) {
            AplicationController.Instance.isQuitLobby = false;
        }
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);

        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!dialogueIsPlaying) return;
        if (InputManager.GetInstance().GetInteractPressed()) {StartCoroutine(ExitDialogueMode()); return; }
        if (canContinueToNextLine && currentStory.currentChoices.Count == 0 && InputManager.GetInstance().GetSubmitPressed()) ContinueStory();
    }

    public void EnterDialogueMode(TextAsset inJSON)
    {

        SchoolAdventure.Success.SuccessHandler.Instance.UnlockAchievment(5);
        currentStory = new Story(inJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

        currentStory.BindExternalFunction("changeScene", (string sceneName) => {
            //modification du start
            AplicationController.Instance.isQuitLobby = true;
            playerStorage.initialValue = new Vector2(_player.transform.position.x, _player.transform.position.y);
            foreach ((string, int) item in AplicationController.Instance.GameList)
            {
                if (sceneName.CompareTo(item.Item1) == 0)
                {
                    SchoolAdventure.Utils.StaticUtils.LoadGame(sceneName, item.Item2);
                    break;
                }
            }
        });

        currentStory.BindExternalFunction("changeTarget", (string targetName) => {
            //modification du start
            lb.ChangeTargetByName(targetName);
        });


        currentStory.BindExternalFunction("newQuest", (int iter) => {
            StartCoroutine(_player.AddQuest(iter));
        });
        ContinueStory();
    }
    private IEnumerator ExitDialogueMode()
    {
        yield return new WaitForSeconds(0.2f);
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }


    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
             if (displayLineCoroutine != null) 
            {
                StopCoroutine(displayLineCoroutine);
            }
            displayLineCoroutine = StartCoroutine(DisplayLine(currentStory.Continue()));

            // dialogueText.text = currentStory.Continue();
            // DisplayChoices();

        }else{
            StartCoroutine(ExitDialogueMode());
        }
    }

    private IEnumerator DisplayLine(string line) 
    {
        // set the text to the full line, but set the visible characters to 0
        dialogueText.text = line;
        dialogueText.maxVisibleCharacters = 0;
        // hide items while text is typing
        continueIcon.SetActive(false);
        HideChoices();
        canContinueToNextLine = false;

        bool isAddingRichTextTag = false;

        // display each letter one at a time
        foreach (char letter in line.ToCharArray())
        {

            // if the submit button is pressed, finish up displaying the line right away
            if (InputManager.GetInstance().GetSubmitPressed() && _timer + _submitSpeed < Time.time) 
            {
                dialogueText.maxVisibleCharacters = line.Length;
                _timer = Time.time;
                break;
            }

            // check for rich text tag, if found, add it without waiting
            if (letter == '<' || isAddingRichTextTag) 
            {
                isAddingRichTextTag = true;
                if (letter == '>')
                {
                    isAddingRichTextTag = false;
                }
            }
            // if not rich text, add the next letter and wait a small time
            else 
            {
                SoundManager.Instance.PlaySound(soundEffect);
                dialogueText.maxVisibleCharacters++;
                yield return new WaitForSeconds(typingSpeed);
            }
        }

        // actions to take after the entire line has finished displaying
        continueIcon.SetActive(true);
        DisplayChoices();
        canContinueToNextLine = true;
    }


    private void HideChoices() 
    {
        foreach (GameObject choiceButton in choices) 
        {
            choiceButton.SetActive(false);
        }
    }
    private void DisplayChoices()
    {
        List<Choice> currentChoices= currentStory.currentChoices;
        // error handling too big

        int index = 0;
        foreach (Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }
        // hide remaining
         for (int i = index; i < choices.Length; i++) 
        {
            choices[i].gameObject.SetActive(false);
        }
        StartCoroutine(SelectFirstChoice());
    }

    private IEnumerator SelectFirstChoice(){
        EventSystem.current.SetSelectedGameObject(null);
        //Debug.Log("aled");
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }

    public void MakeChoice(int index)
    {
        if (canContinueToNextLine)
        {
            currentStory.ChooseChoiceIndex(index);
            ContinueStory();
        }
    }
}
