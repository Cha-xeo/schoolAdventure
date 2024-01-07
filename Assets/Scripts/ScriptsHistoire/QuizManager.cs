using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
namespace SchoolAdventure.Games.Histoire
{
    public class QuizManager : MonoBehaviour
    {
        public static QuizManager instance;

        [SerializeField] private QuizDataScriptable questionDataScriptable;
        [SerializeField] private Image questionImage;
        [SerializeField] private WordData[] answerWordList;
        [SerializeField] private WordData[] optionsWordList;
        [SerializeField] SceneChanger _changer;
        [SerializeField] AudioClip clip;

        private GameStatus gameStatus = GameStatus.Playing;
        private char[] wordsArray = new char[12];

        private List<int> selectedWordsIndex;
        private int currentAnswerIndex = 0, currentQuestionIndex = 0;
        private bool correctAnswer = true;
        private string answerWord;
        public Button timeButton;
        bool timeClick = true;

        private void Awake()
        {
            if (instance == null)
                instance = this;
            else
                Destroy(this.gameObject);
        }

        void Start()
        {
            selectedWordsIndex = new List<int>();
            SetQuestion();
        }

        void SetQuestion()
        {
            gameStatus = GameStatus.Playing;

            answerWord = questionDataScriptable.questions[currentQuestionIndex].answer;

            questionImage.sprite = questionDataScriptable.questions[currentQuestionIndex].questionImage;

            ResetQuestion();

            selectedWordsIndex.Clear();
            Array.Clear(wordsArray, 0, wordsArray.Length);

            for (int i = 0; i < answerWord.Length; i++)
            {
                wordsArray[i] = char.ToUpper(answerWord[i]);
            }

            for (int j = answerWord.Length; j < wordsArray.Length; j++)
            {
                wordsArray[j] = (char)UnityEngine.Random.Range(48, 57);
            }

            wordsArray = ShuffleList.ShuffleListItems<char>(wordsArray.ToList()).ToArray();

            for (int k = 0; k < optionsWordList.Length; k++)
            {
                optionsWordList[k].SetWord(wordsArray[k]);
            }

        }

        public void ResetQuestion()
        {
            if (ScoreManagerHist.score == 1)
                SchoolAdventure.Success.SuccessHandler.Instance.UnlockAchievment(73);
                if (ScoreManagerHist.score == 5)
                    SchoolAdventure.Success.SuccessHandler.Instance.UnlockAchievment(74);
                    for (int i = 0; i < answerWordList.Length; i++)
                    {
                        answerWordList[i].gameObject.SetActive(true);
                        answerWordList[i].SetWord('_');
                    }

            for (int i = answerWord.Length; i < answerWordList.Length; i++)
            {
                answerWordList[i].gameObject.SetActive(false);
            }

            for (int i = 0; i < optionsWordList.Length; i++)
            {
                optionsWordList[i].gameObject.SetActive(true);
            }

            currentAnswerIndex = 0;
        }

        public void SelectedOption(WordData value)
        {
            if (gameStatus == GameStatus.Next || currentAnswerIndex >= answerWord.Length) return;

            selectedWordsIndex.Add(value.transform.GetSiblingIndex());
            value.gameObject.SetActive(false);
            answerWordList[currentAnswerIndex].SetWord(value.wordValue);

            currentAnswerIndex++;

            if (currentAnswerIndex <= answerWord.Length)
            {
                _changer.PlaySound(clip);
            }
            if (currentAnswerIndex == answerWord.Length)
            {
                correctAnswer = true;
                for (int i = 0; i < answerWord.Length; i++)
                {
                    if (char.ToUpper(answerWord[i]) != char.ToUpper(answerWordList[i].wordValue))
                    {
                        correctAnswer = false;
                        break;
                    }
                }

                if (correctAnswer)
                {
                    timeClick = true;
                    timeButton.gameObject.SetActive(true);
                    ScoreManagerHist.instance.addPoint();
                    TimeManagerHist.instance.addTime();
                    gameStatus = GameStatus.Next;
                    currentQuestionIndex++;

                    if (currentQuestionIndex < questionDataScriptable.questions.Count)
                    {
                        Invoke("SetQuestion", 0.5f);
                    }
                    else
                    {
                        SceneManager.LoadScene("EndMenuHist");
                    }
                }
            }
        }

        public void ResetLastWord()
        {
            if (currentAnswerIndex > 0)
            {
                int index = selectedWordsIndex[selectedWordsIndex.Count - 1];
                optionsWordList[index].gameObject.SetActive(true);
                selectedWordsIndex.RemoveAt(selectedWordsIndex.Count - 1);

                currentAnswerIndex--;
                answerWordList[currentAnswerIndex].SetWord('_');
            }
        }

        public void TimeHelp()
        {
            if (timeClick == true)
            {
                timeButton.gameObject.SetActive(false);
                //TimeManagerHist.instance.addTime();
                TimeManagerHist.instance.addTime();
                timeClick = false;
            }
        }
    }

    [System.Serializable]
    public class QuestionData
    {
        public Sprite questionImage;
        public string answer;
    }

    public enum GameStatus
    {
        Next,
        Playing
    }
}