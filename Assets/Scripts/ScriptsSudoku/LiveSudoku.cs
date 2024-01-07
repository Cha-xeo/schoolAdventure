using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SchoolAdventure.Games.Sudoku
{
    public class LiveSudoku : MonoBehaviour
    {
        public List<Image> err;
        public int errors = 0;
        public static LiveSudoku Instance { get; private set; }

        void Awake()
        {
            if (Instance)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
        }
        void Start()
        {
            errors = 0;
        }

        private void WrongNumber()
        {
            if (errors < 5)
            {
                err[errors].color = Color.red;
                errors++;
            }

            checkGameOver();
        }

        private void checkGameOver()
        {
            if (errors >= 5)
            {
                SchoolAdventure.Success.SuccessHandler.Instance.UnlockAchievment(72);
                //errors = 0;
                SceneManager.LoadScene("SudokuEnd");
            }
        }

        private void OnEnable()
        {
            GameEvents.OnWrongNumber += WrongNumber;
        }

        private void OnDisable()
        {
            GameEvents.OnWrongNumber -= WrongNumber;
        }
    }
}