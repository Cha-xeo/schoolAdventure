using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SchoolAdventure.Games.Lab.Dialogue
{
    public class LabDoor : MonoBehaviour
    {
        [Header("Visual Cue")]
        [SerializeField] private GameObject visualCue;

        [Header("Ink Json")]
        [SerializeField] private TextAsset inkJSON;

        private LabDialogueManager ins;

        private bool playerInRange;
        [SerializeField] private GameObject _doorGame;

        // private float a = 0;

        private void Awake()
        {
            playerInRange = false;
            visualCue.SetActive(false);
        }
        // Start is called before the first frame update
        void Start()
        {
            ins = LabDialogueManager.GetInstance();
        }

        // Update is called once per frame
        void Update()
        {
            if (playerInRange && !ins.dialogueIsPlaying)
            {
                visualCue.SetActive(true);
                if (InputManager.GetInstance().GetInteractPressed())
                {
                    ins.EnterDialogueMode(inkJSON);
                }
            }
            else if (playerInRange)
            {
                if ((bool)ins.currentStory.variablesState["exit"])
                {
                    ins.currentStory.variablesState["exit"] = false;
                    // non
                    StartCoroutine(jpp());
                }
            }
            else
            {
                visualCue.SetActive(false);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(Constants.TAG_PLAYER)) playerInRange = true;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(Constants.TAG_PLAYER)) playerInRange = false;

        }

        private IEnumerator jpp()
        {
            yield return new WaitForSeconds(2f);
            _doorGame.SetActive(true);
        }
    }
}