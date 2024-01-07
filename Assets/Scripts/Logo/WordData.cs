using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SchoolAdventure.Games.Langues.Logo
{
    public class WordData : MonoBehaviour
    {
        [SerializeField] private TMP_Text wordText;

        [HideInInspector]
        public char wordValue;

        private Button buttonComponent;

        private void Awake()
        {
            buttonComponent = GetComponent<Button>();
            if (buttonComponent)
            {
                buttonComponent.onClick.AddListener(() => WordSelected());
            }
        }

        public void SetWord(char value)
        {
            wordText.text = value + "";
            wordValue = value;
        }

        private void WordSelected()
        {
            QuizManager.instance.SelectedOption(this);
        }

    }
}