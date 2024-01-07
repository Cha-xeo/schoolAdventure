using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SchoolAdventure.Games.Langues.Quizz
{
    public class AnswerScript : MonoBehaviour
    {
        public bool isCorrect = false;
        public QuizManager quizManager;
        public Color startColor;
        public AudioClip clicked;

        public void Start()
        {
            startColor = GetComponent<Image>().color;
        }

        public void Answer()
        {
            Audio.SoundManagerV2.Instance.PlaySound(clicked);
            if (isCorrect)
            {
                GetComponent<Image>().color = Color.green;
                Debug.Log("Bonne reponse");
                quizManager.correct();
                TimeManagerLang.instance.resetTime();
            }
            else
            {
                GetComponent<Image>().color = Color.red;
                Debug.Log("Mauvaise reponse");
                quizManager.wrong();
                TimeManagerLang.instance.resetTime();
            }
        }
    }
}
