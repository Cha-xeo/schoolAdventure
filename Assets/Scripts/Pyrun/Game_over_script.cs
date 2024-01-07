using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace SchoolAdventure.Games.Mathematique.Pyrun
{
    public class Game_over_script : MonoBehaviour
    {
        public TMP_Text pointsText;
        //public Player toto;
        // Start is called before the first frame update
        public void Setup()
        {
            pointsText.text = "Vous voila riche !\n" + PyrunGameManager.instance.GetPlayer().Score.ToString();
        }

        private void OnEnable()
        {
            Setup();
        }

        public void RestartButton()
        {
            SceneManager.LoadScene("Pyrun");
        }
    }
}
