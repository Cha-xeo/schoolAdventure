using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WordmapSearchingWord : MonoBehaviour
{
    public TextMeshProUGUI displayedText;
    public Image crossLine;

    private string _word;

    void Start()
    {
    }

    private void OnEnable()
    {
        WordmapGameEvents.OnCorrectWord += CorrectWord;
    }

    private void OnDisable()
    {
        WordmapGameEvents.OnCorrectWord -= CorrectWord;
    }

    public void SetWord(string word)
    {
        _word = word;
        displayedText.text = _word;
    }

    private void CorrectWord(string word, List<int> squareIndexes)
    {
        if (word == _word) {
            crossLine.gameObject.SetActive(true);
        }
    }
}
