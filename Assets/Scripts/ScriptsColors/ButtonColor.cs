using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using SchoolAdventure.Audio;

namespace SchoolAdventure.Games.Science.ColorSequence
{
    public class ButtonColor : MonoBehaviour
    {
        public static event Action<string> SendColorValue = delegate { };
        [SerializeField] AudioClip _click;
        public void ButtonClicked()
        {
            SendColorValue(name.Substring(0, name.IndexOf("_")));
            SoundManagerV2.Instance.PlaySound(_click);
            //Debug.Log(name.Substring(0, name.IndexOf("_")));
        }
    }
}