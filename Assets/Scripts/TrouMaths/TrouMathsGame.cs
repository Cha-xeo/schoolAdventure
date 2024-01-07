using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TrouMathsGame : MonoBehaviour
{
    [SerializeField] AudioClip wrongAnswer;
    [SerializeField] AudioClip goodAnswer;
    public GameObject[] heart;
    public GameObject GameOverPanel;
    public TextMeshProUGUI ClockText;
    public TextMeshProUGUI ScoreText;

    public Sprite[] operandArray; // 0 : case, 1 : Add, 2 : Minus, 3 : Multiply, 4 : Divide, 5 : Guess, 6 : wrong case, 7 : wrong add, 8 : wrong sub, 9 : wrong mult, 10 : wrong div

    // Question
    public Image operand1;
    public Image operand2;
    public Image operand3;

    public TextMeshProUGUI number1;
    public TextMeshProUGUI number2;
    public TextMeshProUGUI number3;
    public TextMeshProUGUI number4; // Result

    // Answers
    public Button[] guess_button;
    public TextMeshProUGUI[] answer_text;

    int level = TrouMathsMenu.level; // 1 = Addition & Substraction, 2 = Multiplication & Division
    int thisLevel;
    int questionType; // 1 = Number, 2 = Operator
    int quiz_num1;
    int quiz_num2;
    int quiz_res;
    int toFind; // if operator, 0 = Addition, 1 = Substraction, 2 = Multiplication, 3 = Division
    int whichCase;
    int hp;
    int score;
    public GameObject errorHit;
    
    void Start()
    {
        heart[0].SetActive(true);
        heart[1].SetActive(true);
        heart[2].SetActive(true);
        hp = 2;
        score = 0;
        GetCalcul();
    }

    void GetCalcul()
    {
        thisLevel = Random.Range(1, 5);
        questionType = Random.Range(1, 3);
        if (level == 1) {
            if (thisLevel == 1 || thisLevel == 2) {
                generateAddition();
            } else {
                generateSubstraction();
            }
        } else {
            if (thisLevel == 1) {
                generateAddition();
            } else if (thisLevel == 2) {
                generateSubstraction();
            } else if (thisLevel == 3) {
                generateMultipication();
            } else {
                generateDivision();
            }
        }
        if (questionType == 1) {
            generateAnswerNumber();
        } else {
            generateAnswerOperator();
        }
    }

    int RandomExcept(int min, int max, int exc)
    {
        int res = Random.Range(min, max);

        while (res == exc) {
            res = Random.Range(min, max);
        }

        return res;
    }

    void generateAnswerOperator()
    {
        whichCase = toFind;
        guess_button[0].GetComponent<Image>().sprite = operandArray[1];
        guess_button[1].GetComponent<Image>().sprite = operandArray[2];
        guess_button[2].GetComponent<Image>().sprite = operandArray[3];
        guess_button[3].GetComponent<Image>().sprite = operandArray[4];
        answer_text[0].SetText("");
        answer_text[1].SetText("");
        answer_text[2].SetText("");
        answer_text[3].SetText("");
    }

    void generateAnswerNumber()
    {
        whichCase = Random.Range(0, 4);
        int max = (level == 2 && thisLevel >= 3) ? 11 : 99;
        int rand1 = RandomExcept(1, max, toFind);
        int rand2 = RandomExcept(1, max, toFind);
        int rand3 = RandomExcept(1, max, toFind);
        int rand4 = RandomExcept(1, max, toFind);

        guess_button[0].GetComponent<Image>().sprite = operandArray[0];
        guess_button[1].GetComponent<Image>().sprite = operandArray[0];
        guess_button[2].GetComponent<Image>().sprite = operandArray[0];
        guess_button[3].GetComponent<Image>().sprite = operandArray[0];
        answer_text[0].SetText(rand1.ToString());
        answer_text[1].SetText(rand2.ToString());
        answer_text[2].SetText(rand3.ToString());
        answer_text[3].SetText(rand4.ToString());
        answer_text[whichCase].SetText(toFind.ToString());

    }

    void generateAddition()
    {
        int whatNumber = Random.Range(1, 3);
        quiz_num1 = Random.Range(1, 99);
        quiz_num2 = Random.Range(1, (99-quiz_num1));
        int res = quiz_num1 + quiz_num2;

        operand1.sprite = operandArray[0];
        number1.SetText(quiz_num1.ToString());
        operand2.sprite = operandArray[1];
        number2.SetText("");
        operand3.sprite = operandArray[0];
        number3.SetText(quiz_num2.ToString());
        number4.SetText(res.ToString());
        if (questionType == 1) {
            if (whatNumber == 1) {
                toFind = quiz_num1;
                operand1.sprite = operandArray[5];
                number1.SetText("");
            } else {
                toFind = quiz_num2;
                operand3.sprite = operandArray[5];
                number3.SetText("");
            }
        } else {
            toFind = 0;
            operand2.sprite = operandArray[5];
            number2.SetText("");
        }

    }

    void generateSubstraction()
    {
        int whatNumber = Random.Range(1, 3);
        quiz_num1 = Random.Range(2, 99);
        quiz_num2 = Random.Range(1, quiz_num1);
        int res = quiz_num1 - quiz_num2;

        operand1.sprite = operandArray[0];
        number1.SetText(quiz_num1.ToString());
        operand2.sprite = operandArray[2];
        number2.SetText("");
        operand3.sprite = operandArray[0];
        number3.SetText(quiz_num2.ToString());
        number4.SetText(res.ToString());
        if (questionType == 1) {
            if (whatNumber == 1) {
                toFind = quiz_num1;
                operand1.sprite = operandArray[5];
                number1.SetText("");
            } else {
                toFind = quiz_num2;
                operand3.sprite = operandArray[5];
                number3.SetText("");
            }
        } else {
            toFind = 1;
            operand2.sprite = operandArray[5];
            number2.SetText("");
        }
    }

    void generateMultipication()
    {
        int whatNumber = Random.Range(1, 3);
        quiz_num1 = Random.Range(1, 11);
        quiz_num2 = Random.Range(1, 11);
        int res = quiz_num1 * quiz_num2;

        operand1.sprite = operandArray[0];
        number1.SetText(quiz_num1.ToString());
        operand2.sprite = operandArray[3];
        number2.SetText("");
        operand3.sprite = operandArray[0];
        number3.SetText(quiz_num2.ToString());
        number4.SetText(res.ToString());
        if (questionType == 1) {
            if (whatNumber == 1) {
                toFind = quiz_num1;
                operand1.sprite = operandArray[5];
                number1.SetText("");
            } else {
                toFind = quiz_num2;
                operand3.sprite = operandArray[5];
                number3.SetText("");
            }
        } else {
            toFind = 2;
            operand2.sprite = operandArray[5];
            number2.SetText("");
        }
    }

    void generateDivision()
    {
        int whatNumber = Random.Range(1, 3);
        quiz_num2 = Random.Range(1, 11);
        quiz_num1 = Random.Range(1, 11) * quiz_num2;
        int res = quiz_num1 / quiz_num2;

        operand1.sprite = operandArray[0];
        number1.SetText(quiz_num1.ToString());
        operand2.sprite = operandArray[4];
        number2.SetText("");
        operand3.sprite = operandArray[0];
        number3.SetText(quiz_num2.ToString());
        number4.SetText(res.ToString());
        if (questionType == 1) {
            if (whatNumber == 1) {
                toFind = quiz_num1;
                operand1.sprite = operandArray[5];
                number1.SetText("");
            } else {
                toFind = quiz_num2;
                operand3.sprite = operandArray[5];
                number3.SetText("");
            }
        } else {
            toFind = 3;
            operand2.sprite = operandArray[5];
            number2.SetText("");
        }
    }

    public void ClickedAnswer(int c)
    {
        if (c == whichCase) {
            score += 1;
            SchoolAdventure.Audio.SoundManagerV2.Instance.PlaySound(goodAnswer);
            GetCalcul();
        } else {
            StartCoroutine(ShowCanvasCoroutine(0.1f));
            SchoolAdventure.Audio.SoundManagerV2.Instance.PlaySound(wrongAnswer);
            if (questionType == 1) {
                guess_button[c].GetComponent<Image>().sprite = operandArray[6];
            } else {
                guess_button[c].GetComponent<Image>().sprite = operandArray[c+7];
            }
            heart[hp].SetActive(false);
            hp -= 1;
            if (hp <= -1) {
                GameOver();
            }
        }
    }

    void GameOver()
    {
        GameOverPanel.SetActive(true);
        ScoreText.SetText("Calculs résolus:\n"+score.ToString());
    }

    void Update()
    {
        if (ClockText.text == "00:00") {
            GameOver();
        }
    }
    private IEnumerator ShowCanvasCoroutine(float duration)
    {
        errorHit.SetActive(true);
        yield return new WaitForSeconds(duration);
        errorHit.SetActive(false);
    }
}
