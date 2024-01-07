using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class WordmapSelectPuzzleBoutton : MonoBehaviour
{
    public WordmapGameData gameData;
    public WordmapGameLevelData levelData;
    public TextMeshProUGUI categoryText;
    public string currentCategoryName;
    public int currentCategoryIndex;
    public Image progressBarFilling;

    private bool _levelLocked;
    private string gameSceneName = "WordmapGame";

    void Start()
    {
        _levelLocked = false;
        var button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
        UpdateButtonInformation();
        if (_levelLocked) {
            button.interactable = false;
        } else {
            button.interactable = true;
        }
    }

    void Update()
    {
        
    }

    private void UpdateButtonInformation()
    {
        var currentIndex = 0;
        var totalBoards = 0;

        foreach (var data in levelData.data) {
            if (data.categoryName == gameObject.name) {
                currentIndex = WordmapDataSaver.ReadCategoryCurrentIndexValue(gameObject.name);
                totalBoards = data.boardData.Count;

                if (levelData.data[0].categoryName == gameObject.name && currentIndex < 0) {
                    WordmapDataSaver.SaveCategoryData(levelData.data[0].categoryName, 0);
                    currentIndex =  WordmapDataSaver.ReadCategoryCurrentIndexValue(gameObject.name);
                    totalBoards = data.boardData.Count;
                }
            }
        }

        if (currentIndex == -1) {
            _levelLocked = true;
        }
        categoryText.text = _levelLocked ? string.Empty : (currentIndex.ToString() + "/" + totalBoards.ToString());
        progressBarFilling.fillAmount = (currentIndex >= 0 && totalBoards > 0) ? ((float)currentIndex / (float)totalBoards) : 0f;
    }

    private void OnButtonClick()
    {
        var currentIndex =  WordmapDataSaver.ReadCategoryCurrentIndexValue(currentCategoryName);
        gameData.selectedCategoryName = gameObject.name;
        SceneManager.LoadScene(gameSceneName);
    }
}
