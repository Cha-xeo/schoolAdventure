using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;

public class PlayerController  : MonoBehaviour
{
    public float speed = 3.0f;
    
    public int maxHealth = 5;
    public float timeInvincible = 2.0f;

    public int health { get { return currentHealth; }}
    public int currentHealth;
    
    bool isInvincible;
    float invincibleTimer;
    
    Rigidbody2D rigidbody2d;
 
    Vector2 moveInput;

    public VectorValue startingPosition;
    Animator animator;
    
    Vector2 lookDirection = new Vector2(1,0);

    AudioSource audioSource;

    public string namee;

    private bool pirateSpoke = false;

    private bool firstStep = false;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        
        currentHealth = maxHealth;

        audioSource= GetComponent<AudioSource>();

            transform.position = startingPosition.initialValue;
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = InputManager.GetInstance().GetMoveDirection();
        
        // if (namee == "player"){
        //     horizontal  = Input.GetAxis("Horizontal");
        //     vertical  = Input.GetAxis("Vertical");
        // }else{
        //     horizontal  = Input.GetAxis("Horizontal_joy");
        //     vertical  = Input.GetAxis("Vertical_joy");
        // }
        
        // Vector2 move = new Vector2(horizontal, vertical);
        
        if(!Mathf.Approximately(moveInput.x, 0.0f) || !Mathf.Approximately(moveInput.y, 0.0f))
        {
            lookDirection.Set(moveInput.x, moveInput.y);
            lookDirection.Normalize();
        }
        
    
        
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }


        if (InputManager.GetInstance().GetSubmitPressed())
        {
            RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, lookDirection, 1.5f, LayerMask.GetMask("NPC"));
            if (hit.collider != null)
            {
                NonPlayerCharacter character = hit.collider.GetComponent<NonPlayerCharacter>();
                if (character != null)
                {
                    character.DisplayDialog();
                } 

                if (hit.transform.gameObject.tag == "Pirate") {
                    if (pirateSpoke == true) {
                        SceneManager.LoadScene("SampleScene");
                        pirateSpoke = false;
                    }
                    else {
                        StartCoroutine(AddQuest(1));
                        pirateSpoke = true;
                    }
                }

                else if (hit.transform.gameObject.tag == "NPC1") {
                        StartCoroutine(AddQuest(2));
                }
                 
            }
        }

        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", moveInput.magnitude);

        /*if (InputManager.GetInstance().GetSavePressed())
            SaveGame();
        if (InputManager.GetInstance().GetLoadPressed())
            LoadGame();*/
    }


    public IEnumerator AddQuest(int iter) {
        //for (int i = 0; i < iter; i++) {
            if (iter == 1) {
            QuestLog.AddQuest(getNextPirate());
            yield return new WaitForSeconds(3f);
        //}
            }

        if (iter == 2) {
            QuestLog.AddQuest(getNextNpc1());
            yield return new WaitForSeconds(3f);
        }
    }

    private Quest getNextPirate() {
        Quest q = new Quest();
        q.questName = "La course du pirate";
        q.questDescription = "Va trouver le vieux pirate pour lancer ton premier jeu.";
        q.expReward = Random.Range(100,1000);
        q.goldReward = Random.Range(5,20);
        q.questCategory = 0;
        q.objective = new Quest.Objective();
        q.objective.type = (Quest.Objective.Type)3;
        q.objective.amount = Random.Range(2,10);
        return q;
    }

    private Quest getNextNpc1() {
        Quest q = new Quest();
        q.questName = "Le frêre jumeau";
        q.questDescription = "Un étrange robot me demande de parler à son frere dans une taverne pas loin.";
        q.expReward = Random.Range(100,1000);
        q.goldReward = Random.Range(5,20);
        q.questCategory = 0;
        q.objective = new Quest.Objective();
        q.objective.type = (Quest.Objective.Type)2;
        q.objective.amount = Random.Range(2,10);
        return q;
    }

    
    /*private void SaveGame() {
        SaveData saveData = new SaveData();
        saveData.positions = new SaveData.Position[1];
        saveData.positions[0] = new SaveData.Position();
        saveData.positions[0].x = transform.position.x;
        saveData.positions[0].y = transform.position.y;
        //saveData.positions[0].scene = SceneManager.GetActiveScene().name;
        SaveManager.SaveGameState(saveData);
        Debug.Log("Game Saved!"); 
        Debug.Log("Awake:" + SceneManager.GetActiveScene().name);
    }

    private void LoadGame() {
        SaveData saveData = SaveManager.LoadGameState();
        if(saveData != null) {
            transform.position = new Vector2(saveData.positions[0].x, saveData.positions[0].y);
            Debug.Log("Game Loaded!");
            //SceneManager.LoadScene(saveData.positions[0].scene);
        }
    }*/
    
    void FixedUpdate()
    {
        if (OpenDialogueManager.GetInstance().dialogueIsPlaying) return;

        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * moveInput.x * Time.deltaTime;
        position.y = position.y + speed * moveInput.y * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
    
            if (isInvincible)
                return;
            
            isInvincible = true;
            invincibleTimer = timeInvincible;
        }
        
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        UIHealthBar.instance.SetValue(currentHealth / (float)maxHealth);
    
        Debug.Log(currentHealth + "/" + maxHealth);
    }


    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
} 
