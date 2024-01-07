using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SchoolAdventure.Games.MathRun
{

    public class mainMenu : MonoBehaviour
    {
        public AudioClip btnsound;

        public void startTheGame()
        {
            SceneManager.LoadScene("MathRunLevel1");

        }
        public void PlaySound()
        {
            Audio.SoundManagerV2.Instance.PlaySound(btnsound);
        }
    }

}
