using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SchoolAdventure.Games.Lab.Dialogue
{
    public class LabDialogueTriggerPY : MonoBehaviour
    {
        [Header("Visual anim")]
        [SerializeField] private GameObject visualAnim;
        [Header("Visual Cue")]
        [SerializeField] private GameObject visualCue;

        [Header("Ink Json")]
        [SerializeField] private TextAsset inkJSON;

        [SerializeField] private GameObject _doorGame;
        private LabDialogueManager ins;


        private bool playerInRange;
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
            StartCoroutine(Flippy());
        }

        // Update is called once per frame
        void Update()
        {
            if (playerInRange && !ins.dialogueIsPlaying)
            {
                visualCue.SetActive(true);
                if (InputManager.GetInstance().GetInteractPressed())
                {
                    LabDialogueManager.GetInstance().EnterDialogueMode(inkJSON);

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
        private IEnumerator jpp()
        {
            yield return new WaitForSeconds(2f);
            _doorGame.SetActive(true);
        }
        private IEnumerator Flippy()
        {
            while (true)
            {
                SpriteRenderer sr = visualAnim.GetComponent<SpriteRenderer>();
                sr.flipX = (sr.flipX) ? false : true;
                yield return new WaitForSeconds(1f);
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
    }
}