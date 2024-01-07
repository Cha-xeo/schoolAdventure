using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace SchoolAdventure.Games.Geographie.GeoPays
{
    public class TextTargetScript : MonoBehaviour
    {
        public TextMeshPro textMeshPro;

        public void SetText(string text)
        {
            textMeshPro.text = text;
        }
    }
}