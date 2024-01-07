using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


namespace SchoolAdventure.Games.MathRun
{
    public class GateManager : MonoBehaviour
    {
        public TextMeshPro GateNo;
        public int randomNumber;
        public int number;

        public string operatorType;

        public bool multiplication;
        public bool division;
        public bool substraction;
        public bool addition;
        void Start()
        {


            if (multiplication)
            {
                int valeurMin = number ;
                int valeurMax = number + 4;
                System.Random rand = new System.Random();
                number = rand.Next(valeurMin, valeurMax);

                GateNo.text = "x" + number.ToString();
                operatorType = "multiplication";
            }
            else if (division)
            {
                GateNo.text = "/" + number.ToString();
                operatorType = "division";
            }
            else if (substraction)
            {
                int valeurMin = number; 
                int valeurMax = number + 10;
                System.Random rand = new System.Random();
                number = rand.Next(valeurMin, valeurMax);

                GateNo.text = "-" + number.ToString();
                operatorType = "substraction";
            }
            else if (addition)
            {
                int valeurMin = 1; 
                int valeurMax = number + 20;
                System.Random rand = new System.Random();
                number = rand.Next(valeurMin, valeurMax);

                GateNo.text = "+" + number.ToString();
                operatorType = "addition";

            }
        }

    }

}