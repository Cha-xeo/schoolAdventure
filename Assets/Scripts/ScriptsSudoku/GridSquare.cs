using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace SchoolAdventure.Games.Sudoku
{
    public class GridSquare : Selectable, IPointerClickHandler, ISubmitHandler, IPointerUpHandler, IPointerExitHandler
    {
        public GameObject numberText;
        private int number = 0;
        private bool selected = false;
        private int squareIndex = -1;
        private int correctNumber = 0;
        private bool hasDefault = false;
        private bool wrongValue = false;
        public bool isCorrectNumberSet() { return number == correctNumber; }

        public bool hasWrongvalue() { return (wrongValue); }

        public void SetHasDefaultValue(bool hasdDef) { hasDefault = hasdDef; }
        public bool GetHasDefaultValue() { return (hasDefault); }
        public bool isSelected() { return (selected); }
        public void setSquareIndex(int index)
        {
            squareIndex = index;
        }

        public void SetCorrectNumber(int num)
        {
            correctNumber = num;
            wrongValue = false;
        }

        public void SetCorrectNumber()
        {
            number = correctNumber;
        }

        public void Start()
        {
            selected = false;
        }

        public void SetNumber(int num)
        {
            number = num;
            DisplayText();
        }
        public void DisplayText()
        {
            if (number <= 0)
                numberText.GetComponent<Text>().text = " ";
            else
                numberText.GetComponent<Text>().text = number.ToString();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            selected = true;
            GameEvents.SquareSelectedMethod(squareIndex);
        }

        public void OnSubmit(BaseEventData eventData)
        {
            throw new System.NotImplementedException();
        }

        private void OnEnable()
        {
            GameEvents.OnUpdateSquareNumber += OnSetNumber;
            GameEvents.OnSquareSelected += OnSquareSelected;
        }

        private void OnDisable()
        {
            GameEvents.OnUpdateSquareNumber -= OnSetNumber;
            GameEvents.OnSquareSelected -= OnSquareSelected;
        }

        public void OnSetNumber(int number)
        {
            if (selected && hasDefault == false)
            {
                SetNumber(number);

                if (number != correctNumber)
                {
                    wrongValue = true;
                    var colors = this.colors;
                    colors.normalColor = Color.red;
                    this.colors = colors;

                    GameEvents.WrongNumberMethod();
                }
                else
                {
                    wrongValue = false;
                    hasDefault = true;
                    var colors = this.colors;
                    colors.normalColor = Color.white;
                    this.colors = colors;
                }

                GameEvents.CheckBoardCompletedMethod();
            }
        }

        public void OnSquareSelected(int indexSquare)
        {
            if (squareIndex != indexSquare)
            {
                selected = false;
            }
        }

        public void setSquareColor(Color couleur)
        {
            var colors = this.colors;
            colors.normalColor = couleur;
            this.colors = colors;
        }
    }
}