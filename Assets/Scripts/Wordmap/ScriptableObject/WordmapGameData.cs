using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu]
public class WordmapGameData : ScriptableObject
{
    public string selectedCategoryName;
    public WordmapBoardData selectedBoardData;
}
