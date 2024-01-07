using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu]
public class WordmapAlphaData : ScriptableObject
{
    [System.Serializable]

    public class LetterData
    {
        public string letter;
        public Sprite image;
    }

    public List<LetterData> AlphabetPlain = new List<LetterData>();
    public List<LetterData> AlphabetNormal = new List<LetterData>();
    public List<LetterData> AlphabetHighlight = new List<LetterData>();
    public List<LetterData> AlphabetWrong = new List<LetterData>();
}