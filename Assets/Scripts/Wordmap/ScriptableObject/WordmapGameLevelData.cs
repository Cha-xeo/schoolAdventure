using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu]
public class WordmapGameLevelData : ScriptableObject
{
    [System.Serializable]
    public struct CategoryRecord
    {
        public string categoryName;
        public List<WordmapBoardData> boardData;
    }

    public List<CategoryRecord> data;
}
