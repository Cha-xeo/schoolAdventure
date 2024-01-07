using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using SchoolAdventure.Input;
using SchoolAdventure.Audio;
using SchoolAdventure.Success;

public class LabDialogueManager : MonoBehaviour
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
        private static LabDialogueManager instance;
        private bool canContinueToNextLine = false;
        private Coroutine displayLineCoroutine;

        public Story currentStory;
        public bool dialogueIsPlaying { get; private set; }

        private void Awake()
        {
            instance = this;
        }

        public static LabDialogueManager GetInstance()
        {
            return (instance) ? instance : null;
        }
        // Start is called before the first frame update
        void Start()
        {
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
            if (InputManager.GetInstance().GetInteractPressed()) { StartCoroutine(ExitDialogueMode()); return; }
            if (canContinueToNextLine && currentStory.currentChoices.Count == 0 && InputManager.GetInstance().GetSubmitPressed()) ContinueStory();
        }

        public void EnterDialogueMode(TextAsset inJSON)
        {
            currentStory = new Story(inJSON.text);
            dialogueIsPlaying = true;
            dialoguePanel.SetActive(true);
            currentStory.BindExternalFunction("LabEnd", (int money) =>
            {
                Debug.Log("You gained: "+money);
                SuccessHandler.Instance.UnlockAchievment(36);
                if (money >= 100) 
                {
                    SuccessHandler.Instance.UnlockAchievment(43);
                }
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

            }
            else
            {
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
                    SoundManagerV2.Instance.PlaySound(soundEffect);
                    //SoundManager.Instance.PlaySound(soundEffect);
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
            List<Choice> currentChoices = currentStory.currentChoices;
            // error handling too big
            if (currentChoices.Count <= 0) return;
            //_choosing = true;
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

        private IEnumerator SelectFirstChoice()
        {
            EventSystem.current.SetSelectedGameObject(null);
            yield return new WaitForEndOfFrame();
            EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
        }

        public void MakeChoice(int index)
        {
            if (canContinueToNextLine)
            {
                currentStory.ChooseChoiceIndex(index);
                //ContinueStory();
            }
        }
    }