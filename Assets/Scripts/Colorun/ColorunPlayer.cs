using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace SchoolAdventure.Games.Mathematique.Colorun
{
    public class ColorunPlayer : MonoBehaviour
    {
        public float playerSpeed;
        private Rigidbody2D rb;
        private Vector2 playerDirection;
        public static int targetColor;
        public static int lifePoint;
        public GameObject[] hearts;
        public static string[] colors = { "Yellow", "Red", "Blue", "Green", "Pink", "Purple", "Black", "White", "Beige", "Brown", "Olive", "Orange", "Salmon", "Turquoise", "Gray", "Sky" };
        // 1 = Yellow, 2 = Red, 3 = Blue, 4 = Green, 5 = Pink, 6 = Purple
        public int stageLevel = 5;
        public static float score;
        private int combo;
        private int count;
        private int givenPoint;
        [SerializeField] AudioClip hitSound;
        [SerializeField] AudioClip damageSound;
        //[SerializeField] PyrunSoundsEffect _soundsEffect;
        public static float updatedSpeed = 8.5f;
        public GameObject errorHit;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            lifePoint = 3;
            stageLevel = MainMenu.level;
            targetColor = Random.Range(1, stageLevel);
            score = 0;
            givenPoint = 1;
            combo = 0;
            count = 0;
            updatedSpeed = 8.5f;
        }

        private IEnumerator ShowCanvasCoroutine(float duration)
        {
            errorHit.SetActive(true);
            yield return new WaitForSeconds(duration);
            errorHit.SetActive(false);
        }

        void Update()
        {
            float directionY = InputManager.GetInstance().GetMoveDirection().y;
            //   float directionX = Input.GetAxisRaw("Horizontal");
            playerDirection = new Vector2(0, directionY).normalized;
        }

        void FixedUpdate()
        {
            rb.velocity = new Vector2(0, playerDirection.y * playerSpeed);
        }

        IEnumerator waitSeconds()
        {
            yield return new WaitForSeconds(2);
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if ((collision.tag == "YellowObs" || collision.tag == "RedObs" || collision.tag == "BlueObs" || collision.tag == "GreenObs" || collision.tag == "PinkObs" || collision.tag == "PurpleObs" || collision.tag == "BlackObs"
            || collision.tag == "WhiteObs" || collision.tag == "BeigeObs" || collision.tag == "BrownObs" || collision.tag == "OliveObs" || collision.tag == "OrangeObs" || collision.tag == "SalmonObs" || collision.tag == "TurquoiseObs" || collision.tag == "GrayObs" || collision.tag == "SkyObs"))
            {
                Debug.Log(collision.tag);
                string tagPattern = ".*Obs$";
                GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();
                GameObject[] obsToDestroy = allObjects.Where(obj => System.Text.RegularExpressions.Regex.IsMatch(obj.tag, tagPattern)).ToArray();
                foreach (GameObject go in obsToDestroy)
                    Destroy(go);
                if (collision.tag == colors[targetColor - 1] + "Obs")
                {
                    combo += 1;
                    count += 1;
                    Audio.SoundManagerV2.Instance.PlaySound(hitSound);
                    //_soundsEffect.PlaySounds("right");
                    //hitSound.Play();
                    score += givenPoint;
                    updatedSpeed += 0.1f;
                    if (combo >= 5)
                    {
                        givenPoint = 5 * (combo / 5);
                    }
                    if (count == 5)
                    {
                        updatedSpeed += 0.5f;
                        count = 0;
                    }
                }
                else
                {
                    Audio.SoundManagerV2.Instance.PlaySound(damageSound);
                    //_soundsEffect.PlaySounds("wrong");
                    //damageSound.Play();
                    StartCoroutine(ShowCanvasCoroutine(0.1f));

                    lifePoint -= 1;
                    count = 0;
                    combo = 0;
                    if (lifePoint == 2 && hearts[0] != null)
                    {
                        Destroy(hearts[0].gameObject);
                    }
                    else if (lifePoint == 1 && hearts[1] != null)
                    {
                        Destroy(hearts[1].gameObject);
                    }
                    else if (lifePoint == 0 && hearts[2] != null)
                    {
                        Destroy(hearts[2].gameObject);
                    }
                    if (lifePoint == 0)
                    {
                        Destroy(this.gameObject, 0.5f);
                    }
                }
                targetColor = Random.Range(1, stageLevel);
            }
        }
    }
}