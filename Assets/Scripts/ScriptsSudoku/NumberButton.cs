using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using SchoolAdventure.Audio;

namespace SchoolAdventure.Games.Sudoku
{
    public class NumberButton : Selectable, IPointerClickHandler, ISubmitHandler, IPointerUpHandler, IPointerExitHandler
    {
        [SerializeField] AudioClip clip;
        public int value = 0;
        void Update()
        {

        }
        public void OnPointerClick(PointerEventData eventData)
        {
            SoundManagerV2.Instance.PlaySound(clip);
            GameEvents.UpdateSquareNumberMethod(value);
        }

        public void OnSubmit(BaseEventData eventData) //pour les erreurs
        {
            throw new System.NotImplementedException();
        }
    }
}