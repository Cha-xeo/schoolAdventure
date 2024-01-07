using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using SchoolAdventure.Audio;

namespace SchoolAdventure.Games.Science.ColorSequence
{
    public class Door : MonoBehaviour
    {
        [SerializeField]
        private GameObject arrow;
        private string correctSequence, currentSequence, secondcorrectSequence;
        private int clickedColors;

        public Text formText;
        public static float randForm;

        [SerializeField] AudioClip _correct;
        [SerializeField] AudioClip _wrong;

        void Start()
        {
            ButtonColor.SendColorValue += AddValueAndCheckSequence;
            currentSequence = "";
            arrow.SetActive(false);
            TextDisplayer();
            clickedColors = 0;
        }

        public string Reverse(string text)
        {
            char[] cArray = text.ToCharArray();
            string reverse = String.Empty;
            for (int i = cArray.Length - 1; i > -1; i--)
            {
                reverse += cArray[i];
            }
            return reverse;
        }

        void TextDisplayer()
        {
            randForm = UnityEngine.Random.Range(1, 8);
            if (randForm == 1)
            {
                formText.text = "Orange";
                correctSequence = "56";
            }
            if (randForm == 2)
            {
                formText.text = "Vert";
                correctSequence = "46";
            }
            if (randForm == 3)
            {
                formText.text = "Violet";
                correctSequence = "54";
            }
            if (randForm == 4)
            {
                formText.text = "Indigo";
                correctSequence = "454";
                secondcorrectSequence = "544";
            }
            if (randForm == 5)
            {
                formText.text = "Rose";
                correctSequence = "15";
            }
            if (randForm == 6)
            {
                formText.text = "Turquoise";
                correctSequence = "446";
                secondcorrectSequence = "464";
            }
            if (randForm == 7)
            {
                formText.text = "Pourpre";
                correctSequence = "554";
                secondcorrectSequence = "545";
            }
        }

        private void AddValueAndCheckSequence(string buttonColor)
        {
            clickedColors++;
            Debug.Log(buttonColor);
            switch (buttonColor)
            {
                case "White":
                    currentSequence += 1;
                    break;
                case "Green":
                    currentSequence += 46;
                    break;
                case "Orange":
                    currentSequence += 56;
                    break;
                case "Blue":
                    currentSequence += 4;
                    break;
                case "Red":
                    currentSequence += 5;
                    break;
                case "Yellow":
                    currentSequence += 6;
                    break;
                case "Violet":
                    currentSequence += 54;
                    break;
            }
            if (clickedColors <= 2)
            {
                if (currentSequence == correctSequence || currentSequence == Reverse(correctSequence) || currentSequence == secondcorrectSequence)
                {
                    if (arrow.activeInHierarchy)
                    {
                        SchoolAdventure.Success.SuccessHandler.Instance.UnlockAchievment(75);
                        TextDisplayer();
                        clickedColors = 0;
                    }
                    Debug.Log(correctSequence);
                    arrow.SetActive(true);
                    currentSequence = "";
                    Destroy(gameObject);
                    SoundManagerV2.Instance.PlaySound(_correct);
                    if (clickedColors == 1)
                        ScoreManagerColors.instance.addOnePoint();
                    if (clickedColors == 2)
                        ScoreManagerColors.instance.addThreePoint();
                    if (ScoreManagerColors.score == 20)
                    {
                        SchoolAdventure.Success.SuccessHandler.Instance.UnlockAchievment(77);
                    }
                }
                Debug.Log(currentSequence);
            }
            if (clickedColors == 2 && !arrow.activeInHierarchy)
            {
                SchoolAdventure.Success.SuccessHandler.Instance.UnlockAchievment(76);
                clickedColors = 0;
                currentSequence = "";
                LivesManagerColors.instance.removeLife();
                SoundManagerV2.Instance.PlaySound(_wrong);
            }
        }

        private void OnDestroy()
        {
            ButtonColor.SendColorValue -= AddValueAndCheckSequence;
        }
    }
}