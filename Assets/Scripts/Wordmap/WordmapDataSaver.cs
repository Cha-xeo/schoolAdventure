using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordmapDataSaver : MonoBehaviour
{
    public static int ReadCategoryCurrentIndexValue(string name)
    {
        var value = 0;
        if (PlayerPrefs.HasKey(name)) {
            value = PlayerPrefs.GetInt(name);
        }

        return value;
    }

    public static void SaveCategoryData(string categoryName, int currentIndex)
    {
        PlayerPrefs.SetInt(categoryName, currentIndex);
        PlayerPrefs.Save();
    }

    public static void ClearGameData(WordmapGameLevelData levelData)
    {
        foreach (var data in levelData.data) {
            PlayerPrefs.SetInt(data.categoryName, 0);
        }

        PlayerPrefs.SetInt(levelData.data[0].categoryName, 0);
        PlayerPrefs.Save();
    }
}
