using UnityEngine;
using UnityEngine.SceneManagement;

namespace SchoolAdventure.Games.Geographie.GeoGuesser
{

    public class MenuManager : MonoBehaviour
    {
        public AudioClip btnsound;
        public GameObject myBtn;
        public GameObject howToPlayCanvas;

        public void howToPlay()
        {
            howToPlayCanvas.SetActive(true);
        }
        public void closeHowToPlay()
        {
            howToPlayCanvas.SetActive(false);
        }

        public void PlayWorld()
        {
            SceneManager.LoadScene("GeoGuesserWorld");
        }
        public void PlayContinent()
        {
            SceneManager.LoadScene("GeoGuesserContinent");
        }
        public void PlayEurope()
        {
            SceneManager.LoadScene("GeoGuesserEurope");
        }

        public void PlaySound()
        {
            Audio.SoundManagerV2.Instance.PlaySound(btnsound);
        }

        public void changeBtnW()
        {
            myBtn.GetComponent<RectTransform>().anchorMax = new Vector2(30.0f, 30.0f);

        }
    }
}