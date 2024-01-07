using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

namespace SchoolAdventure.Games.Geometrie
{
    public class LivesManager : MonoBehaviour
    {
        public static LivesManager instance;
        public TMP_Text livesText;
        int lives = 3;
        public GameObject errorHit;

        private void Awake()
        {
            instance = this;
        }
        void Start()
        {
            livesText.text = lives.ToString() + " Vies";
        }

        void Update()
        {

        }

        public void removeLife()
        {
            if (lives == 1)
                SceneManager.LoadScene("EndMenuGeometry");
            if (lives > 0) {
                StartCoroutine(ShowCanvasCoroutine(0.1f));
                lives--;
            }
            livesText.text = lives.ToString() + " Vies";
        }

        private IEnumerator ShowCanvasCoroutine(float duration)
        {
            errorHit.SetActive(true);
            yield return new WaitForSeconds(duration);
            errorHit.SetActive(false);
        }
    }
}
