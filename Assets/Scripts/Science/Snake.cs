using SchoolAdventure.Audio;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SchoolAdventure.Games.Science.ZouzouSnake.Audio
{
    public class Snake : MonoBehaviour
    {
        private Vector2 direction = Vector2.right;
        public GameObject gmobj;
        public Animator animatedWolf;
        public AudioClip eat;

        private void Start()
        {
            shuffleShape();
            Debug.Log("Start");
        }

        private void CarnUp()
        {
            if (gmobj.tag == "Carnivore")
            {
                animatedWolf.SetBool("LeftWolf", false);
                animatedWolf.SetBool("RightWolf", false);
                animatedWolf.SetBool("UpWolf", true);
                animatedWolf.SetBool("DownWolf", false);
            }
        }
        private void CarnDown()
        {
            if (gmobj.tag == "Carnivore")
            {
                animatedWolf.SetBool("LeftWolf", false);
                animatedWolf.SetBool("RightWolf", false);
                animatedWolf.SetBool("UpWolf", false);
                animatedWolf.SetBool("DownWolf", true);
            }
        }
        private void Carnleft()
        {
            if (gmobj.tag == "Carnivore")
            {

                animatedWolf.SetBool("LeftWolf", true);
                animatedWolf.SetBool("RightWolf", false);
                animatedWolf.SetBool("UpWolf", false);
                animatedWolf.SetBool("DownWolf", false);
            }
        }
        private void CarnRight()
        {
            if (gmobj.tag == "Carnivore")
            {
                animatedWolf.SetBool("LeftWolf", false);
                animatedWolf.SetBool("RightWolf", true);
                animatedWolf.SetBool("UpWolf", false);
                animatedWolf.SetBool("DownWolf", false);
            }
        }
        private void CarnDel()
        {
            animatedWolf.SetBool("LeftWolf", false);
            animatedWolf.SetBool("RightWolf", false);
            animatedWolf.SetBool("UpWolf", false);
            animatedWolf.SetBool("DownWolf", false);
        }

        private void HerbUp()
        {
            if (gmobj.tag == "Herbivore")
            {
                animatedWolf.SetBool("LeftRabbit", false);
                animatedWolf.SetBool("RightRabbit", false);
                animatedWolf.SetBool("UpRabbit", true);
                animatedWolf.SetBool("DownRabbit", false);
            }
        }
        private void HerbDown()
        {
            if (gmobj.tag == "Herbivore")
            {
                animatedWolf.SetBool("LeftRabbit", false);
                animatedWolf.SetBool("RightRabbit", false);
                animatedWolf.SetBool("UpRabbit", false);
                animatedWolf.SetBool("DownRabbit", true);
            }
        }
        private void HerbLeft()
        {
            if (gmobj.tag == "Herbivore")
            {
                animatedWolf.SetBool("LeftRabbit", true);
                animatedWolf.SetBool("RightRabbit", false);
                animatedWolf.SetBool("UpRabbit", false);
                animatedWolf.SetBool("DownRabbit", false);
            }
        }
        private void HerbRight()
        {
            if (gmobj.tag == "Herbivore")
            {
                animatedWolf.SetBool("LeftRabbit", false);
                animatedWolf.SetBool("RightRabbit", true);
                animatedWolf.SetBool("UpRabbit", false);
                animatedWolf.SetBool("DownRabbit", false);
            }
        }
        private void HerbDel()
        {
            animatedWolf.SetBool("LeftRabbit", false);
            animatedWolf.SetBool("RightRabbit", false);
            animatedWolf.SetBool("UpRabbit", false);
            animatedWolf.SetBool("DownRabbit", false);
        }

        private void OmniUp()
        {
            if (gmobj.tag == "Omnivore")
            {
                animatedWolf.SetBool("LeftBoar", false);
                animatedWolf.SetBool("RightBoar", false);
                animatedWolf.SetBool("UpBoar", true);
                animatedWolf.SetBool("DownBoar", false);
            }
        }
        private void OmniDown()
        {
            if (gmobj.tag == "Omnivore")
            {
                animatedWolf.SetBool("LeftBoar", false);
                animatedWolf.SetBool("RightBoar", false);
                animatedWolf.SetBool("UpBoar", false);
                animatedWolf.SetBool("DownBoar", true);
            }
        }
        private void OmniLeft()
        {
            if (gmobj.tag == "Omnivore")
            {
                animatedWolf.SetBool("LeftBoar", true);
                animatedWolf.SetBool("RightBoar", false);
                animatedWolf.SetBool("UpBoar", false);
                animatedWolf.SetBool("DownBoar", false);
            }
        }
        private void OmniRight()
        {
            if (gmobj.tag == "Omnivore")
            {
                animatedWolf.SetBool("LeftBoar", false);
                animatedWolf.SetBool("RightBoar", true);
                animatedWolf.SetBool("UpBoar", false);
                animatedWolf.SetBool("DownBoar", false);
            }
        }
        private void OmniDel()
        {
            animatedWolf.SetBool("LeftBoar", false);
            animatedWolf.SetBool("RightBoar", false);
            animatedWolf.SetBool("UpBoar", false);
            animatedWolf.SetBool("DownBoar", false);
        }

        private void Update()
        {
            if (InputManager.GetInstance().GetUpPressed())
            {
                CarnUp();
                HerbUp();
                OmniUp();
                direction = Vector2.up;
            }
            else if (InputManager.GetInstance().GetDownPressed())
            {
                CarnDown();
                HerbDown();
                OmniDown();
                direction = Vector2.down;
            }
            else if (InputManager.GetInstance().GetLeftPressed())
            {
                Carnleft();
                HerbLeft();
                OmniLeft();
                direction = Vector2.left;
            }
            else if (InputManager.GetInstance().GetRightPressed())
            {
                CarnRight();
                HerbRight();
                OmniRight();
                direction = Vector2.right;
            }
        }

        private void FixedUpdate()
        {
            this.transform.position = new Vector3(
                Mathf.Round(this.transform.position.x) + direction.x,
                Mathf.Round(this.transform.position.y) + direction.y,
                0.0f
            );
        }

        private void shuffleShape()
        {
            float shape = Random.Range(1, 4);
            animatedWolf.SetInteger("ShapeShifter", (int)shape);
            if (shape == 1)
            {
                HerbDel();
                OmniDel();
                gmobj.tag = "Carnivore";
            }
            if (shape == 2)
            {
                CarnDel();
                OmniDel();
                gmobj.tag = "Herbivore";
            }
            if (shape == 3)
            {
                CarnDel();
                HerbDel();
                gmobj.tag = "Omnivore";
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Meat")
            {
                if (gmobj.tag == "Carnivore" || gmobj.tag == "Omnivore")
                {
                    ScoreManagerSc.instance.addPoint();
                    TimeManagerSc.instance.AddTime();
                    if (ScoreManagerSc.score > 0)
                        SoundManagerV2.Instance.PlaySound(eat);
                    shuffleShape();
                }else{
                    Gameplay.UI.UiHurt.Instance.PlayHurtAnim();
                }
            }
            else if (other.tag == "Veggie")
            {
                if (gmobj.tag == "Herbivore" || gmobj.tag == "Omnivore")
                {
                    ScoreManagerSc.instance.addPoint();
                    TimeManagerSc.instance.AddTime();
                    if (ScoreManagerSc.score > 0)
                        SoundManagerV2.Instance.PlaySound(eat);
                    shuffleShape();
                }else{
                    Gameplay.UI.UiHurt.Instance.PlayHurtAnim();
                }
            } else if (other.tag == "Obstacle")
            {
                Debug.Log("Reset");
                SceneManager.LoadScene("EndMenu1");
            }
        }
    }
}
