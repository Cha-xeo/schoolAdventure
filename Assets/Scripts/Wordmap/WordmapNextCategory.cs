using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordmapNextCategory : MonoBehaviour
{
    [System.Serializable]
    public struct CategoryName {
        public string name;
    }   

    public WordmapGameData currentGameData;
    public WordmapGameLevelData gameLevelData;
    public List<CategoryName> categoryNames;
    public GameObject winPop;

    private int _currentIndex;
    private string _currentCategoryName;
    private int _currentCategoryIndex;

    void Start()
    {
        winPop.SetActive(false);
        WordmapGameEvents.OnUnlockNextCategory += OnUnlockNextCategory;
        CheckIfCompleted();
    }

    private void CheckIfCompleted()
    {
        _currentCategoryName = currentGameData.selectedCategoryName;
        _currentIndex = WordmapDataSaver.ReadCategoryCurrentIndexValue(_currentCategoryName);

        for (int index = 0; index < gameLevelData.data.Count; index++) {
            if (gameLevelData.data[index].categoryName == _currentCategoryName) {
                _currentCategoryIndex = index;
            }
        }

        if (_currentIndex >= gameLevelData.data[_currentCategoryIndex].boardData.Count) {
            winPop.SetActive(true);
        }
    }

    private void OnDisable()
    {
        WordmapGameEvents.OnUnlockNextCategory -= OnUnlockNextCategory;
    }

    private void OnUnlockNextCategory()
    {
        bool captureNext = false;

        winPop.SetActive(true);

        foreach (var writing in categoryNames) {
            if (captureNext)
                captureNext = false;

            if (writing.name == currentGameData.selectedCategoryName)
                captureNext = true;
        }
    }

    public void ResetCurrentCategory()
    {
        WordmapDataSaver.SaveCategoryData(currentGameData.selectedCategoryName, 0);
    }

}
