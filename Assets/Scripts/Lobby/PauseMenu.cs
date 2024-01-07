using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject Player;
    public GameObject Player2;
    public bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (InputManager.GetInstance().GetEscapePressed())
        {
            if (isPaused) {
                ResumeGame();
            }
            else {
                PauseGame();
            }
        }

        if (InputManager.GetInstance().GetSavePressed())
            SaveGame();
        if (InputManager.GetInstance().GetLoadPressed())
            LoadGame();
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void GoToMainMenu()
    {
        
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameSelection");
    }

    public void QuitGame()
    {
        Application.Quit();
    }


    public void SaveGame() {
        SaveData saveData = new SaveData();
        saveData.positions = new SaveData.Position[1];
        saveData.positions[0] = new SaveData.Position();
        saveData.positions[0].x = Player.transform.position.x;
        saveData.positions[0].y = Player.transform.position.y;
        //saveData.positions[0].scene = SceneManager.GetActiveScene().name;
        SaveManager.SaveGameState(saveData);
        Debug.Log("Game Saved!"); 
        Debug.Log("Awake:" + SceneManager.GetActiveScene().name);
        pauseMenu.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
    }

    public void LoadGame() {
        SaveData saveData = SaveManager.LoadGameState();
        if(saveData != null) {
            Player.transform.position = new Vector2(saveData.positions[0].x, saveData.positions[0].y);
            Debug.Log("Game Loaded!");
            //SceneManager.LoadScene(saveData.positions[0].scene);
        }
        pauseMenu.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
    }
}
