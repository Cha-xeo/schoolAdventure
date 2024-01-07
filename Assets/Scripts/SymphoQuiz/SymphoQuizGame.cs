using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SymphoQuizGame : MonoBehaviour
{
    int level;
    [SerializeField] Animation _hurtAnim;
    [SerializeField] AudioClip wrongAnswer;
    [SerializeField] AudioClip goodAnswer;
    [SerializeField] AudioClip[] musicalNotes;
    string[] musicalString = {"Do", "Ré", "Mi", "Fa", "Sol", "La", "Si"};
    public GameObject[] heart;
    public GameObject gameOverPanel;
    public Sprite[] musicalImg;
    public Button[] guessButton;
    public TextMeshProUGUI quizText;
    public TextMeshProUGUI scoreText;
    public Button repeatButton;
    int currentNote;
    int previousNote;
    int whichCase;
    int score;
    int hp;

    void Start()
    {
        heart[0].SetActive(true);
        heart[1].SetActive(true);
        heart[2].SetActive(true);
        heart[3].SetActive(true);
        heart[4].SetActive(true);
        level = SymphoQuizMainMenu.level;
        currentNote = 0;
        score = 0;
        hp = 4;
        previousNote = 8;
        GenerateRandomNote();
    }

    public void Restart()
    {
        gameOverPanel.SetActive(false);
        Start();
    }

    int RandomExcept(int min, int max, int exc)
    {
        int res = Random.Range(min, max);

        while (res == exc) {
            res = Random.Range(min, max);
        }

        return res;
    }

    void GenerateRandomNote()
    {
        currentNote = RandomExcept(0, 7, previousNote);
        previousNote = currentNote;
        whichCase = Random.Range(0, 4);
        int rand1 = RandomExcept(0, 7, currentNote);
        int rand2 = RandomExcept(0, 7, currentNote);
        int rand3 = RandomExcept(0, 7, currentNote);
        int rand4 = RandomExcept(0, 7, currentNote);

        guessButton[0].GetComponent<Image>().sprite = musicalImg[rand1];
        guessButton[1].GetComponent<Image>().sprite = musicalImg[rand2];
        guessButton[2].GetComponent<Image>().sprite = musicalImg[rand3];
        guessButton[3].GetComponent<Image>().sprite = musicalImg[rand4];
        guessButton[whichCase].GetComponent<Image>().sprite = musicalImg[currentNote];
        guessButton[0].interactable = true;
        guessButton[1].interactable = true;
        guessButton[2].interactable = true;
        guessButton[3].interactable = true;

        if (level == 1) {
            quizText.SetText("Trouvez cette note : " + musicalString[currentNote]);
        } else {
            quizText.SetText("Ecoutez cette note : ");
        }
        SchoolAdventure.Audio.SoundManagerV2.Instance.PlaySound(musicalNotes[currentNote]);
    }

    public void ClickedAnswer(int c)
    {
        if (c == whichCase) {
            score += 1;
            //SchoolAdventure.Audio.SoundManagerV2.Instance.PlaySound(goodAnswer);
            GenerateRandomNote();
        } else {
            _hurtAnim.Play();
            SchoolAdventure.Audio.SoundManagerV2.Instance.PlaySound(wrongAnswer);
            guessButton[c].interactable = false;
            heart[hp].SetActive(false);
            hp -= 1;
            if (hp <= -1) {
                GameOver();
            }
        }
    }

    public void PlayNote()
    {
        SchoolAdventure.Audio.SoundManagerV2.Instance.PlaySound(musicalNotes[currentNote]);
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        scoreText.SetText("Notes trouvées :\n"+score.ToString());
    }
}
