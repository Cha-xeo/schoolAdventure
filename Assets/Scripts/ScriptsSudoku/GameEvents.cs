using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SchoolAdventure.Games.Sudoku
{
    public class GameEvents : MonoBehaviour
    {
        public delegate void CheckBoardCompleted();
        public static event CheckBoardCompleted onCheckBoardCompleted;

        public static void CheckBoardCompletedMethod()
        {
            if (onCheckBoardCompleted != null)
                onCheckBoardCompleted();
        }

        public delegate void UpdateSquareNumber(int number);
        public static event UpdateSquareNumber OnUpdateSquareNumber;

        public static void UpdateSquareNumberMethod(int number)
        {
            if (OnUpdateSquareNumber != null)
                OnUpdateSquareNumber(number);
        }

        public delegate void SquareSelected(int indexSquare);
        public static event SquareSelected OnSquareSelected;

        public static void SquareSelectedMethod(int indexSquare)
        {
            if (OnSquareSelected != null)
                OnSquareSelected(indexSquare);
        }

        public delegate void WrongNumber();
        public static event WrongNumber OnWrongNumber;

        public static void WrongNumberMethod()
        {
            if (OnWrongNumber != null)
                OnWrongNumber();
        }

        public delegate void BoardCompleted();
        public static event BoardCompleted OnBoardCompleted;

        public static void BoardCompletedMethod()
        {
            if (OnBoardCompleted != null)
                OnBoardCompleted();
        }
    }
}