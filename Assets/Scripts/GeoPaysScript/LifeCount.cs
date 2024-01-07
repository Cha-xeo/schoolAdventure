using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SchoolAdventure.Games.Geographie.GeoPays
{
    public class LifeCount : MonoBehaviour
    {
        public Image[] lives;
        public int livesRemaining;

        public GameObject errorHit;
        public GameObject endGameHUD;
        public Score score;
        public Score score2;
        // Start is called before the first frame update

        public void seterrorHit(GameObject obj)
        {
            errorHit = obj;
        }

        public void setendGameHUD(GameObject obj)
        {
            endGameHUD = obj;
        }

        public void setScore(Score obj, Score obj2)
        {
            score = obj;
            score2 = obj2;
        }

        public void ResetLife(int life)
        {
            livesRemaining = life > 4 ? 4 : life > 0 ? life : 0;

            for (int i = 0; i < life; i++)
            {
                lives[i].enabled = true;
            }
        }

        public void LoseLife()
        {
            //If no lives remaining do nothing
            if (livesRemaining == 0)
                return;

            livesRemaining--;
            lives[livesRemaining].enabled = false;

            // Hit effect
            StartCoroutine(ShowCanvasCoroutine(0.1f));
            Camera.main.GetComponent<ScreenShaker>().ShakeScreen();

            //If we run out of lives we lose the game
            if(livesRemaining==0)
            {
                endGameHUD.SetActive(true);
                StartCoroutine(UpdateScoreAfterOneFrame());
            }
        }

        private IEnumerator UpdateScoreAfterOneFrame()
        {
            // Attendre une frame
            yield return null;
            score2.setScore(score.getScore());
            score2.checkAchievements();
        }

        private IEnumerator ShowCanvasCoroutine(float duration)
        {
            errorHit.SetActive(true);

            yield return new WaitForSeconds(duration);

            errorHit.SetActive(false);

        }
    }
}