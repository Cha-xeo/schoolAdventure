using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SchoolAdventure.Games.MathRun
{
    public class PlayAudio : MonoBehaviour
    {
        // Start is called before the first frame update
        public AudioSource audioSource;

        public float volume = 0.5f;
        void Start()
        {
            audioSource.Play();
        }

    }

}
