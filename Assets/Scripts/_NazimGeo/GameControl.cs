using SchoolAdventure.Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SchoolAdventure.Games.Geographie.ZouzouGeo
{
    public class GameControl : MonoBehaviour
    {
        [SerializeField] GameObject token;
        public AudioClip clip;
        List<int> faceIndexes = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
        public static System.Random rnd = new System.Random();
        public int shuffleNum = 0;
        public int[] visibleFaces = { -1, -2 };
        public List<int> matchedFaces = new List<int>();

        void Start()
        {
            int originalLength = faceIndexes.Count;
            float yPosition = 3.0f;
            float xPosition = -3.0f;
            for (int i = 0; i < 11; i++)
            {
                shuffleNum = rnd.Next(0, (faceIndexes.Count));
                var temp = Instantiate(token, new Vector3(
                    xPosition, yPosition, 0),
                    Quaternion.identity);
                temp.GetComponent<MainToken>().faceIndex = faceIndexes[shuffleNum];
                faceIndexes.Remove(faceIndexes[shuffleNum]);
                xPosition = xPosition + 3;
                if (i == 2)
                {
                    yPosition = 0.0f;
                    xPosition = -6.0f;
                }
                if (i == 6)
                {
                    yPosition = -3.0f;
                    xPosition = -6.0f;
                }

            }
            token.GetComponent<MainToken>().faceIndex = faceIndexes[0];
        }

        public bool TwoCaardsUp()
        {
            bool cardsUp = false;
            if (visibleFaces[0] >= 0 && visibleFaces[1] >= 0)
            {
                cardsUp = true;
            }
            return (cardsUp);
        }

        public void AddVisisbleFace(int index)
        {
            if (visibleFaces[0] == -1)
            {
                visibleFaces[0] = index;
            }
            else if (visibleFaces[1] == -2)
            {
                visibleFaces[1] = index;
            }
        }

        public void RemoveVisibleFace(int index)
        {
            if (visibleFaces[0] == index)
            {
                visibleFaces[0] = -1;
            }
            else if (visibleFaces[1] == index)
            {
                visibleFaces[1] = -2;
            }
        }

        public bool CheckMatch()
        {
            bool success = false;
            if (visibleFaces[0] > 5)
            {
                if (visibleFaces[0] == visibleFaces[1] + 6)
                {
                    matchedFaces.Add(visibleFaces[0]);
                    matchedFaces.Add(visibleFaces[1]);
                    visibleFaces[0] = -1;
                    visibleFaces[1] = -2;
                    success = true;
                    SoundManagerV2.Instance.PlaySound(clip);
                    ScoreManager.instance.addPoint();
                    TimeManager.instance.addTime();
                    if (ScoreManager.score == 6)
                    {
                        TimeManager.TimeLeft = TimeManager.TimeLeft - 5.0f;
                        if (SceneManager.GetActiveScene().name == "Africa") {
                            SchoolAdventure.Success.SuccessHandler.Instance.UnlockAchievment(26);
                        }
                        else if (SceneManager.GetActiveScene().name == "Europe") {
                            SchoolAdventure.Success.SuccessHandler.Instance.UnlockAchievment(27);
                        }
                        else if (SceneManager.GetActiveScene().name == "America") {
                            SchoolAdventure.Success.SuccessHandler.Instance.UnlockAchievment(28);
                        }
                        else if (SceneManager.GetActiveScene().name == "Asia") {
                            SchoolAdventure.Success.SuccessHandler.Instance.UnlockAchievment(29);
                        }
                        SceneManager.LoadScene("winMenu");
                    }
                }
            }
            if (visibleFaces[0] <= 5)
            {
                if (visibleFaces[0] + 6 == visibleFaces[1])
                {
                    matchedFaces.Add(visibleFaces[0]);
                    matchedFaces.Add(visibleFaces[1]);
                    visibleFaces[0] = -1;
                    visibleFaces[1] = -2;
                    success = true;
                    SoundManagerV2.Instance.PlaySound(clip);
                    ScoreManager.instance.addPoint();
                    TimeManager.instance.addTime();
                    if (ScoreManager.score == 6)
                    {
                        TimeManager.TimeLeft = TimeManager.TimeLeft - 5.0f;
                        if (SceneManager.GetActiveScene().name == "Africa") {
                            SchoolAdventure.Success.SuccessHandler.Instance.UnlockAchievment(26);
                        }
                        else if (SceneManager.GetActiveScene().name == "Europe") {
                            SchoolAdventure.Success.SuccessHandler.Instance.UnlockAchievment(27);
                        }
                        else if (SceneManager.GetActiveScene().name == "America") {
                            SchoolAdventure.Success.SuccessHandler.Instance.UnlockAchievment(28);
                        }
                        else if (SceneManager.GetActiveScene().name == "Asia") {
                            SchoolAdventure.Success.SuccessHandler.Instance.UnlockAchievment(29);
                        }
                        SceneManager.LoadScene("winMenu");
                    }
                }
            }
            return (success);
        }

        /*private void Awake()
        {
            token = GameObject.Find("Token");
        }*/

    }
}