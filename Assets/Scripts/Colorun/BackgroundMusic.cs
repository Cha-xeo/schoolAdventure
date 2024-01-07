using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SchoolAdventure.Games.Mathematique.Colorun
{
    public class BackgroundMusic : MonoBehaviour
    {
        private static BackgroundMusic music;

        void Awake()
        {
            if (music == null)
            {
                music = this;
                DontDestroyOnLoad(music);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}