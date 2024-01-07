using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

namespace SchoolAdventure.Games.Langues.Quizz
{
    public class QuizManager : MonoBehaviour
    {
        public List<QuestionAnswer> QnA;
        public GameObject[] options;
        public int currentQuestion;

        public GameObject QuestionPanel;
        public GameObject GOPanel;
        public TMP_Text QuestionText;
        public TMP_Text ScoreText;
        public Button hintButton;
        public Button timeButton;

        int TotalQuestions = 0;
        int score;
        float randNum;
        bool hintClick = true;
        bool timeClick = true;
        public GameObject errorHit;

        private void Start()
        {
            TotalQuestions = QnA.Count;
            GOPanel.SetActive(false);
            generateQuestion();
        }

        private void Update()
        {
            if (options[(int)randNum].GetComponent<AnswerScript>().isCorrect != false)
            {
                randNum = Random.Range(0, 4);
            }
            if (TimeManagerLang.instance.TimeLeft <= 0)
            {
                GameOver();
            }
        }

        public void setAnswers()
        {
            for (int i = 0; i < options.Length; i++)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = false;
                options[i].transform.GetChild(0).GetComponent<TMP_Text>().text = QnA[currentQuestion].Answers[i];
                options[i].GetComponent<Image>().color = options[i].GetComponent<AnswerScript>().startColor;

                if (QnA[currentQuestion].CorrectAnswer == i + 1)
                {
                    options[i].GetComponent<AnswerScript>().isCorrect = true;
                }
            }
        }

        public void HintHelp()
        {
            if (hintClick == true)
            {
                SchoolAdventure.Success.SuccessHandler.Instance.UnlockAchievment(24);
                hintButton.gameObject.SetActive(false);
                for (int i = 0; i < options.Length; i++)
                {
                    if (QnA[currentQuestion].CorrectAnswer == i + 1)
                        options[i].GetComponent<Image>().color = Color.blue;
                }
                if (options[(int)randNum].GetComponent<AnswerScript>().isCorrect == false)
                    options[(int)randNum].GetComponent<Image>().color = Color.blue;
                hintClick = false;
            }
        }

        public void TimeHelp()
        {
            if (timeClick == true)
            {
                SchoolAdventure.Success.SuccessHandler.Instance.UnlockAchievment(24);
                timeButton.gameObject.SetActive(false);
                TimeManagerLang.instance.addTime();
                timeClick = false;
            }
        }

        IEnumerator WaitForNext()
        {
            yield return new WaitForSeconds(1);
            generateQuestion();
        }

        private IEnumerator ShowCanvasCoroutine(float duration)
        {
            errorHit.SetActive(true);
            yield return new WaitForSeconds(duration);
            errorHit.SetActive(false);
        }
        public void correct()
        {
            score++;
            QnA.RemoveAt(currentQuestion);
            StartCoroutine(WaitForNext());
        }
        public void wrong()
        {
            StartCoroutine(ShowCanvasCoroutine(0.1f));
            QnA.RemoveAt(currentQuestion);
            StartCoroutine(WaitForNext());
        }

        void GameOver()
        {
            QuestionPanel.SetActive(false);
            GOPanel.SetActive(true);
            if (score == 10) {
                SchoolAdventure.Success.SuccessHandler.Instance.UnlockAchievment(25);
            }
            ScoreText.text = score + " / " + "10";/*TotalQuestions*/
        }

        public void Retry()
        {

            SceneManager.LoadScene("QuizzLangues");
        }

        private void generateQuestion()
        {
            //Debug.Log(QnA.Count);
            if (QnA.Count > 12)
            {
                currentQuestion = Random.Range(0, QnA.Count);
                QuestionText.text = QnA[currentQuestion].Question;
                setAnswers();
            }
            else
            {
                Debug.Log("Y a plus de questions");
                GameOver();
            }
        }
    }
}