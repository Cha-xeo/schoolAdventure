using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SchoolAdventure.Games.MathRun
{
    public class Perso : MonoBehaviour
    {
        public static Perso instance;

        public int CurrentScore = 0;

        public Transform player;
        private int NumberOfStickmans;
        [SerializeField] private TextMeshPro CounterTxt;
        [SerializeField] private GameObject stickman;

        public float speed = 10;
        public GameObject perso;

        public GameObject manager;
        public GameObject endPanel;
        public GameObject pausePanel;
        public GameObject test;


        public bool gamestarted = false;
        public bool gameEndded = false;
        public bool gamePaused = false;

        // Barriers
        public GameObject barrierLeft;
        public GameObject barrierRight;

        public float posbarrierLeftX;
        public float posbarrierRightX;
        public float posPersoX;

        public AudioClip portal;
        private bool firstPortal = false;

        private void Awake()
        {
            instance = this;
        }
        void Start()
        {
            player = transform;
            CounterTxt.text = CurrentScore.ToString();

        }


        // Update is called once per frame
        void Update()
        {
            posbarrierLeftX = barrierLeft.transform.position.x;
            posbarrierRightX = barrierRight.transform.position.x;
            posPersoX = perso.transform.position.x;

            if (gameEndded)
            {
                endPanel.SetActive(true);

            }
            else
            {
                movePerso();
            }
        }


        void movePerso()
        {


            transform.Translate(0, 0, Time.deltaTime * speed);

            float translation = InputManager.GetInstance().GetMoveDirection().x * speed;

            translation *= Time.deltaTime;

            if ((posPersoX - 0.7 <= posbarrierLeftX) && translation < 0)
            {
                return;
            }
            if ((posPersoX + 0.7 >= posbarrierRightX) && translation > 0)
            {
                return;
            }
            transform.Translate(translation , 0, 0);
        }

   

        private void OnTriggerEnter(Collider other)
        {
            if (firstPortal == false)
            {
                SchoolAdventure.Success.SuccessHandler.Instance.UnlockAchievment(68);
                firstPortal = true;
            }

            if (other.CompareTag("gate") || other.CompareTag("gate2"))
            {
            Audio.SoundManagerV2.Instance.PlaySound(portal);

                var gateManager = other.GetComponent<GateManager>();

                if (gateManager.operatorType == "addition") {
                    CurrentScore += gateManager.number;
                } else if (gateManager.operatorType == "substraction") {
                    CurrentScore -= gateManager.number;
                } else if (gateManager.operatorType == "division") {
                    CurrentScore /= gateManager.number;
                } else if (gateManager.operatorType == "multiplication")
                {
                    CurrentScore *= gateManager.number;
                }

                CounterTxt.text = CurrentScore.ToString();

            }

            if (other.CompareTag("enddingportal"))
            {
                SchoolAdventure.Success.SuccessHandler.Instance.UnlockAchievment(69);
                Audio.SoundManagerV2.Instance.PlaySound(portal);
                gameEndded = true;

            }
        }
    }
}
