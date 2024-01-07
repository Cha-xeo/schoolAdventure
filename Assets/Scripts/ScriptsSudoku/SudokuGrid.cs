using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

namespace SchoolAdventure.Games.Sudoku
{
    public class SudokuGrid : MonoBehaviour
    {
        public int columns = 0;
        public int rows = 0;
        public float gridOffset = 0.0f;
        public GameObject gridSquare;
        public Vector2 startPos = new Vector2(0.0f, 0.0f);
        public float squareScale = 1.0f;
        public float squareGap = 0.1f;
        public Color lineColor = Color.red;
        private List<GameObject> gridSquares = new List<GameObject>();
        private int selectedGridData = -1;

        void Start()
        {
            if (gridSquare.GetComponent<GridSquare>() == null)
                Debug.Log("il manque le script");
            CreateGrid();
            SetGridNumber("Easy");
        }

        void Update()
        {

        }

        private void CreateGrid()
        {
            SpawnGridSquares();
            SetSquarePositions();
        }

        private void SpawnGridSquares()
        {
            int indexSquare = 0;
            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    gridSquares.Add(Instantiate(gridSquare) as GameObject);
                    gridSquares[gridSquares.Count - 1].GetComponent<GridSquare>().setSquareIndex(indexSquare);
                    gridSquares[gridSquares.Count - 1].transform.SetParent(this.transform, false);// = this.transform; //SetParent method instead, with the worldPositionStays argument set to false
                    gridSquares[gridSquares.Count - 1].transform.localScale = new Vector3(squareScale, squareScale, squareScale);
                    indexSquare++;
                }
            }
        }

        private void SetSquarePositions()
        {
            var squareRect = gridSquares[0].GetComponent<RectTransform>();
            Vector2 offset = new Vector2();
            Vector2 sqrGapNum = new Vector2(0.0f, 0.0f);
            bool rowMoved = false;

            offset.x = squareRect.rect.width * squareRect.transform.localScale.x + gridOffset;
            offset.y = squareRect.rect.height * squareRect.transform.localScale.y + gridOffset;

            int rowNumber = 0;
            int columnNumber = 0;

            foreach (GameObject square in gridSquares)
            {
                if ((columnNumber + 1) > columns)
                {
                    rowNumber++;
                    columnNumber = 0;
                    sqrGapNum.x = 0;
                    rowMoved = false;
                }
                var posxOffset = offset.x * columnNumber + (sqrGapNum.x * squareGap);
                var posyOffset = offset.y * rowNumber + (sqrGapNum.y * squareGap);

                if (columnNumber > 0 && columnNumber % 3 == 0)
                {
                    sqrGapNum.x++;
                    posxOffset += squareGap;
                }
                if (rowNumber > 0 && rowNumber % 3 == 0 && rowMoved == false)
                {
                    rowMoved = true;
                    sqrGapNum.y++;
                    posyOffset += squareGap;
                }

                square.GetComponent<RectTransform>().anchoredPosition = new Vector2(startPos.x + posxOffset, startPos.y - posyOffset);
                columnNumber++;
            }
        }

        private void SetGridNumber(string level)
        {
            selectedGridData = Random.Range(0, SudokuData.instance.sudokuGame[level].Count);
            var data = SudokuData.instance.sudokuGame[level][selectedGridData];
            setGridSquareData(data);
        }

        private void setGridSquareData(SudokuData.SudokuBoardData data)
        {
            for (int index = 0; index < gridSquares.Count; index++)
            {
                gridSquares[index].GetComponent<GridSquare>().SetNumber(data.unsolvedData[index]);
                gridSquares[index].GetComponent<GridSquare>().SetCorrectNumber(data.solvedData[index]);
                gridSquares[index].GetComponent<GridSquare>().SetHasDefaultValue(data.unsolvedData[index] != 0 && data.unsolvedData[index] == data.solvedData[index]);
            }
        }

        private void OnEnable()
        {
            GameEvents.OnSquareSelected += OnSquareSelected;
            GameEvents.onCheckBoardCompleted += checkBoardCompleted;
        }

        private void OnDisable()
        {
            GameEvents.OnSquareSelected -= OnSquareSelected;
            GameEvents.onCheckBoardCompleted -= checkBoardCompleted;
        }

        private void setSquaresColor(int[] data, Color couleur)
        {
            foreach (var index in data)
            {
                var comp = gridSquares[index].GetComponent<GridSquare>();
                if (comp.hasWrongvalue() == false && comp.isSelected() == false)
                    comp.setSquareColor(couleur);
            }
        }

        public void OnSquareSelected(int sqrIndex)
        {
            var horizontalLine = LineIndicator.instance.getHorizontalLine(sqrIndex);
            var verticalLine = LineIndicator.instance.getVerticalLine(sqrIndex);
            var square = LineIndicator.instance.getSquare(sqrIndex);

            setSquaresColor(LineIndicator.instance.getAllsquareIndexes(), Color.white);
            setSquaresColor(horizontalLine, lineColor);
            setSquaresColor(verticalLine, lineColor);
            setSquaresColor(square, lineColor);
        }

        private void checkBoardCompleted()
        {
            foreach (var square in gridSquares)
            {
                var comp = square.GetComponent<GridSquare>();
                if (comp.isCorrectNumberSet() == false)
                    return;
            }
            GameEvents.BoardCompletedMethod();
        }

        public void SolveSudoku()
        {
            foreach (var square in gridSquares)
            {
                var comp = square.GetComponent<GridSquare>();
                comp.SetCorrectNumber();
            }
            checkBoardCompleted();
        }
    }
}