using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


namespace SchoolAdventure.Games.Geographie.GeoGuesser
{

    public class GameManager : MonoBehaviour
    {
        public Question[] question;
        //private static List<Question> unansweredQuestions;
        private List<Question> unansweredQuestions;
        private Question currentQuestion;
        [SerializeField]

        //UI
        private TextMeshProUGUI questionText;
        public TextMeshProUGUI scoreTextInWorldGame;

        public string currentMapName = null;
        private string currentObjectName = null;
        public float Wait = 2;
        private int gameIsOver = 0;
        private int score = 0;
        private int nbTotalQuestions = 0;
        Collider2D _hitCollider;

        private Camera _mainCamera;

        //gamerOver
        public GameObject gameOverCanvas;
        public GameObject gameEnddedCanvas;
        public TextMeshProUGUI scoreTxtGameOver;
        public TextMeshProUGUI goodAnswersNb;
        public TextMeshProUGUI nbTotalQuestionsTxt;



        //canva hit wrong question
        public GameObject errorHit;

        //heart system
        public int nbOfLife = 3;
        public int indexNbOfLife = 3;
        public GameObject[] hearts;
        public bool canClick = false;
        public AudioClip clickedFailed;
        public AudioClip clickedSuccess;

        private bool isMenuOpen = false;
        private bool firstClickSucces = false;

        public List<string> congratulationPhrases = new List<string>
    {
        "F�licitations !",
        "Excellent travail !",
        "Brillant !",
        "Superbe performance !",
        "Tu d�chires !",
        "Impressionnant !",
        "C'est du g�nie !",
        "Formidable !",
        "Bien jou� !"
    };



        private void Start()
        {
            nbTotalQuestions = question.ToList<Question>().Count;
            //Debug.Log("nb total quesiton :" + nbTotalQuestions);
            if (unansweredQuestions == null || unansweredQuestions.Count == 0)
            {
                unansweredQuestions = question.ToList<Question>();
            }

            SetRandomQuestion();

        }

        public string GetCurrentObjName()
        {
            return currentObjectName;
        }
        public void SetCurrentObjName(string new_name)
        {
            currentObjectName = new_name;
        }

        void SetRandomQuestion()
        {

            if (unansweredQuestions.Count == 0)
            {
                gameIsOver = 1;
                return;
            }

            int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
            currentQuestion = unansweredQuestions[randomQuestionIndex];
            questionText.text = currentQuestion.question;
            currentObjectName = null;
            canClick = true;

        }
        IEnumerator ChangeQuestion()
        {
            //phrases al�atoires
            int randomIndex = Random.Range(0, congratulationPhrases.Count);
            questionText.text = congratulationPhrases[randomIndex];

            unansweredQuestions.Remove(currentQuestion);
            yield return new WaitForSeconds(Wait);
            canClick = true;
            if (gameIsOver == 0)
            {
                questionText.text = currentQuestion.question;
            }
        }

        private void Update()
        {
            // check if menu is open
            if (InputManager.GetInstance().GetEscapePressed() && isMenuOpen == false) {
                isMenuOpen = true;
            } else if (InputManager.GetInstance().GetEscapePressed() && isMenuOpen) {
                isMenuOpen = false;
            }

            if (isMenuOpenFct()) {} else {
                if (currentMapName == "World") {
                    scoreTextInWorldGame.text = score.ToString();
                }


                if (gameIsOver == 1)
                {
                    SchoolAdventure.Success.SuccessHandler.Instance.UnlockAchievment(67);
                    nbTotalQuestionsTxt.text = nbTotalQuestions.ToString();
                    scoreTxtGameOver.text = (nbTotalQuestions - (indexNbOfLife - nbOfLife)).ToString();
                    gameEnddedCanvas.SetActive(true);

                }

                if (nbOfLife == 0)
                {
                    canClick = false;
                    nbTotalQuestionsTxt.text = nbTotalQuestions.ToString();
                    scoreTxtGameOver.text = (nbTotalQuestions - (indexNbOfLife - nbOfLife)).ToString();
                    gameOverCanvas.SetActive(true);

                }


                if (currentObjectName == currentQuestion.answer)
                {
                    if (firstClickSucces == false)
                    {
                        firstClickSucces = true;
                        SchoolAdventure.Success.SuccessHandler.Instance.UnlockAchievment(66);
                    }

                    Audio.SoundManagerV2.Instance.PlaySound(clickedSuccess);
                    score++;
                    SetRandomQuestion();

                    if (gameIsOver == 0)
                    {
                        canClick = false;
                        StartCoroutine(ChangeQuestion());
                    }


                }
                else if (currentObjectName != currentQuestion.answer && currentObjectName != null)
                {
                    Audio.SoundManagerV2.Instance.PlaySound(clickedFailed);

                    StartCoroutine(ShowCanvasCoroutine(0.1f));
                    Camera.main.GetComponent<ScreenShaker>().ShakeScreen();
                    if (currentMapName != "World") {
                        losingLife();
                    }
                    currentObjectName = null;

                    SetRandomQuestion();
                }
            }
        }

        private bool isMenuOpenFct()
        {
            // fix bug when you menus is pressed in the world map
            if (isMenuOpen)
            {
                return true;
            } else {
                return false;
            }
        }

        private void losingLife()
        {
            if (nbOfLife <= 0) return;
            hearts[indexNbOfLife - nbOfLife].SetActive(false);
            nbOfLife--;
        }

        private IEnumerator ShowCanvasCoroutine(float duration)
        {
            errorHit.SetActive(true);
            yield return new WaitForSeconds(duration);
            errorHit.SetActive(false);
        }

        //play again
        public void RestartGame(string name)
        {
            SceneManager.LoadScene(name);
        }
        //menu
        public void LoadMainMenu()
        {
            SceneManager.LoadScene("GeoGuesserMenu");
        }

        //input system
        private void Awake()
        {
            InputManager.GetInstance().SwitchCam();
            //_mainCamera = Camera.main;
        }
    }
}