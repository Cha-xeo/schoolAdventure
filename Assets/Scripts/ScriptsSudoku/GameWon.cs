using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SchoolAdventure.Games.Sudoku
{
    public class GameWon : MonoBehaviour
    {
        private void OnBoardCompleted()
        {
            if (LiveSudoku.Instance.errors == 0)
            {
                SchoolAdventure.Success.SuccessHandler.Instance.UnlockAchievment(71);
            }
            SchoolAdventure.Success.SuccessHandler.Instance.UnlockAchievment(70);
            SceneManager.LoadScene("SudokuWin");
        }

        private void OnEnable()
        {
            GameEvents.OnBoardCompleted += OnBoardCompleted;
        }

        private void OnDisable()
        {
            GameEvents.OnBoardCompleted -= OnBoardCompleted;
        }
    }
}