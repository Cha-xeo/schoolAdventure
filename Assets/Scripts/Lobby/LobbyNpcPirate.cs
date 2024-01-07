using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LobbyNpcPirate : MonoBehaviour
{
    [Header("Visual anim")]
    [SerializeField] private GameObject visualAnim;
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;
    
    [Header("Ink Json")]
    [SerializeField] private TextAsset inkJSON;


    private bool playerInRange;
    // private float a = 0;

    private void Awake() {
        playerInRange = false;
        visualCue.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
       // StartCoroutine(Flippy());
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange && !LabDialogueManager.GetInstance().dialogueIsPlaying){
            visualCue.SetActive(true);
            if (InputManager.GetInstance().GetInteractPressed()){
                LabDialogueManager.GetInstance().EnterDialogueMode(inkJSON);
                
            }
        }else{
            visualCue.SetActive(false);
        }
    }


    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag(Constants.TAG_PLAYER)) playerInRange = true;
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag(Constants.TAG_PLAYER)) playerInRange = false;
        
    }
}
