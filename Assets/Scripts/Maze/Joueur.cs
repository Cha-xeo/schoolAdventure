using SchoolAdventure.Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SchoolAdventure.Games.Maze
{
    public class Joueur : MonoBehaviour
    {
        static public int levels = 0;
        public int keys = 0;
        public float speed = 5.0f;

        public Text keyAmount;
        public GameObject door;
        //public AudioSource getkey;
        [SerializeField] AudioClip _keyCLip;
        // Start is called before the first frame update
        public GameObject errorHit;

        void Start()
        {
            TimeManagerMaze.instance.TimerOn = true;
        }

        // Update is called once per frame
        void Update()
        {
            if (keys == 3)
            {
                Destroy(door);
            }

        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Keys")
            {
                //getkey.gameObject.SetActive(true);
                SoundManagerV2.Instance.PlaySound(_keyCLip);
                keys++;
                keyAmount.text = "Keys: " + keys + " / 3";
                Destroy(collision.gameObject);
            }

            if (collision.gameObject.tag == "Princess")
            {
                if (levels < 3)
                    levels++;
                if (levels == 1) {
                    SchoolAdventure.Success.SuccessHandler.Instance.UnlockAchievment(15);
                    SceneManager.LoadScene("MazeTwo");
                } if (levels == 2)
                    SceneManager.LoadScene("MazeThree");
                if (levels == 3)
                {
                    levels = 0;
                    TimeManagerMaze.instance.TimerOn = false;
                    SchoolAdventure.Success.SuccessHandler.Instance.UnlockAchievment(16);
                    SceneManager.LoadScene("EndMenuMaze");
                }
            }
            if (collision.gameObject.tag == "Enemies")
            {
                StartCoroutine(ShowCanvasCoroutine(0.1f));
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                SchoolAdventure.Success.SuccessHandler.Instance.UnlockAchievment(14);
            }
        }
        private IEnumerator ShowCanvasCoroutine(float duration)
        {
            errorHit.SetActive(true);
            yield return new WaitForSeconds(duration);
            errorHit.SetActive(false);
        }
    }
}