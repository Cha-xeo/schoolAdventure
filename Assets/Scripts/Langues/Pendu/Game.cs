using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using SchoolAdventure.Audio;

namespace SchoolAdventure.Games.Langues.Pendu
{
    public class Game : MonoBehaviour
    {
        private Words word = new Words();
        private string curWord;
        public TMP_Text txt;
        private string reponse;
        private bool win = false;
        public Sprite[] sp;
        public AudioClip SfxCorrect, SfxFailed;
        public GameObject Pendu;
        private int errors = 0;
        public GameObject PanelEnd;
        public List<Button> lstLetters = new List<Button>();
        public GameObject errorHit;

        private void Start()
        {
            Begin();
        }
        private void Begin()
        {
            txt.text = "";
            for (int i = 0; i < word.curWord.Length; i++)
            {
                if (word.curWord[i] == ' ')
                    txt.text = txt.text + " ";
                if (word.curWord[i] != ' ')
                    txt.text = txt.text + "_";
            }
        }
        private void Awake()
        {
            curWord = word.GetWord();
        }

        public void KeyboardPress(string letter)
        {
            Validation(letter);
        }

        private void Validation(string letter)
        {
            reponse = "";
            win = false;
            for (int i = 0; i < word.curWord.Length; i++)
            {
                if (txt.text.Substring(i, 1) == "_")
                {
                    if (word.curWord.Substring(i, 1) == letter)
                    {
                        reponse += letter;
                        win = true;
                    }
                    else
                    {
                        reponse += "_";
                    }
                }
                else
                {
                    reponse += txt.text.Substring(i, 1);
                }
            }

            txt.text = reponse;
            Verification();
        }
        void Verification()
        {
            if (win)
            {
                SoundManagerV2.Instance.PlaySound(SfxCorrect);

                if (txt.text == curWord)
                {
                    ScoreManagerFrench.instance.addPoint();
                    PanelEnd.SetActive(true);
                    SchoolAdventure.Success.SuccessHandler.Instance.UnlockAchievment(18);
                    PanelEnd.GetComponentInChildren<Text>().text = "BRAVO ! le mot etait " + curWord;
                    word.delWord(curWord);
                    StartCoroutine(Restart());
                }
            }
            else
            {
                StartCoroutine(ShowCanvasCoroutine(0.1f));
                Pendu.GetComponent<Image>().sprite = sp[errors];
                errors++;
                SoundManagerV2.Instance.PlaySound(SfxFailed);

                if (errors == 6)
                {
                    SchoolAdventure.Success.SuccessHandler.Instance.UnlockAchievment(17);
                    PanelEnd.SetActive(true);
                    PanelEnd.GetComponentInChildren<Text>().text = "PERDU ! le mot etait " + curWord;
                    StartCoroutine(EndGame());
                }
            }
        }

        IEnumerator Restart()
        {
            yield return new WaitForSeconds(3f);
            if (word.lstSize() != 0)
            {
                curWord = word.GetWord();
                Begin();
                PanelEnd.SetActive(false);
                for (int i = 0; i < 26; i++)
                {
                    if (!lstLetters[i].interactable)
                        lstLetters[i].interactable = true;
                }
                errors = 0;
                Pendu.GetComponent<Image>().sprite = sp[6];
            }
            else
            {
                SceneManager.LoadScene("EndMenuFr");
            }
        }

        IEnumerator EndGame()
        {
            yield return new WaitForSeconds(3f);
            SceneManager.LoadScene("EndMenuFr");
        }
        private IEnumerator ShowCanvasCoroutine(float duration)
        {
            errorHit.SetActive(true);
            yield return new WaitForSeconds(duration);
            errorHit.SetActive(false);
        }
    }
}