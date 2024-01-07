using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SchoolAdventure.Games.Histoire
{
    [CreateAssetMenu(fileName = "QuestionsData", menuName = "QuestionsData", order = 1)]
    public class QuizDataScriptable : ScriptableObject
    {
        public List<QuestionData> questions;
    }
}