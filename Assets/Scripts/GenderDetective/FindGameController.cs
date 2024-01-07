using SchoolAdventure.Games.Geographie.GeoGuesser;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace SchoolAdventure.Games.Langues.GenderDetective
{
    public class FindGameController : MonoBehaviour
    {
        [SerializeField] Transform _topSide;
        [SerializeField] TMP_Text _genderText;
        [Range(1, 10)] public int nbChoices;
        [SerializeField] GameObject _buttonPrefab;
        public Gender winingGender;
        int _winingPos;
        int _restartCount;

        List<MatchButton> _topButtons = new List<MatchButton>();
        public void Initialize()
        {
            for (int i = 0; i < nbChoices; i++)
            {
                _topButtons.Add(Instantiate(_buttonPrefab, _topSide).GetComponent<MatchButton>());
            }
            GameManager.Instance.Score = 0;
        }
        
        public void UnInitialize()
        {
            foreach (MatchButton button in _topButtons)
            {
                Destroy(button.gameObject);
            }
            _topButtons.Clear();
            _restartCount = 0;
            GameManager.Instance.Score = 0;
            // TODO reset nbChoices or adjust it
        }


        public void GetWinningGender()
        {
            _winingPos = Random.Range(0, nbChoices);
            int tmp = _winingPos % 2;
            winingGender = (Gender)tmp;
        }

        public void ShowWining()
        {
            _genderText.text = winingGender.ToString();
        }

        public void FillButtons()
        {
            int length = _topButtons.Count;
            for (int i = 0; i < length; i++)
            {
                GenderWord tmp = GameManager.Instance.GetGenderWord(_winingPos == i  ? winingGender : winingGender == Gender.Masculin ? Gender.Feminin : Gender.Masculin);
                ///tmp.Log();
                _topButtons[i].Word = tmp;
                
            }
        }
        public void Hint()
        {
            foreach(MatchButton button in _topButtons)
            {
                button.Hint();
            }
        }

        public void Restart()
        {
            // TODO Add buttons ???
            /*if (_restartCount >= 2)
            {
                GameManager.Instance.Score++;
                return;
            }*/
            GameManager.Instance.Score++;
            /*_restartCount++;*/
            GetWinningGender();
            ShowWining();
            FillButtons();
        }
    }
}