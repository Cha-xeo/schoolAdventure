using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordmapGameDataSelector : MonoBehaviour
{
    public WordmapGameData currentGameData;
    public WordmapGameLevelData levelData;

    void Awake()
    {
        SelectSequentialBoardData();
    }

    private void SelectSequentialBoardData()
    {
        foreach (var data in levelData.data) {
            if (data.categoryName == currentGameData.selectedCategoryName) {
                var boardIndex = WordmapDataSaver.ReadCategoryCurrentIndexValue(currentGameData.selectedCategoryName);

                if (boardIndex < data.boardData.Count) {
                    currentGameData.selectedBoardData = data.boardData[boardIndex];
                } else {
                    var randomIndex = Random.Range(0, data.boardData.Count);
                    currentGameData.selectedBoardData = data.boardData[randomIndex];
                }
            }
        }
    }
}
