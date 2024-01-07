using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SchoolAdventure.Games.Geographie.GeoPays
{
    public class PlayerMovment : MonoBehaviour
    {
        public int currentCountry;
        public string currentContinent;
        public int points;
        public int countryLeft;
        public bool isContinentKnown;

        private float horizontal;
        public bool isFacingRight;
        public float speed;
        public float wallSlidingSpeed;
        public float jump;
        public bool isJumping;
        public bool isGlued;
        private float gravityScale;
        private bool isWallSliding;

        private bool canDoubleJump;

        public StageGenerator stageGenerator;

        public GameObject startPosition;
        public LifeCount ui_Life;
        private float Move;
        private Rigidbody2D rb;

        public GameObject errorHit;
        public GameObject endGameHUD;
        public Score score;
        public Score score2;
        // Start is called before the first frame update
        void Start()
        {
            //SchoolAdventure.Success.SuccessHandler.Instance.UnlockAchievment();
            rb = GetComponent<Rigidbody2D>();
            isFacingRight = true;
            canDoubleJump = true;
            isWallSliding = false;
            isGlued = false;
            gravityScale = rb.gravityScale;
            stageGenerator.InitializeCountries();
            stageGenerator.GenerateStage();
            currentCountry = -1;
            currentContinent = "void";
            isContinentKnown = false;
            ui_Life.seterrorHit(errorHit);
            ui_Life.setendGameHUD(endGameHUD);
            ui_Life.setScore(score, score2);
        }

        void restartGame()
        {

        }

        // Update is called once per frame
        void Update()
        {
            //        Move = Input.GetAxisRaw("Horizontal");
            Move = InputManager.GetInstance().GetMoveDirection().x;
            rb.velocity = new Vector2(speed * Move, rb.velocity.y);
            if (InputManager.GetInstance().GetJumpPressed() && (!isJumping || canDoubleJump))
            {
                rb.velocity = new Vector2(rb.velocity.x, jump);
                canDoubleJump = !canDoubleJump;
                isJumping = true;
                if (isWallSliding)
                    canDoubleJump = true;
            }
            if (InputManager.GetInstance().GetJumpPressed() && rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            }

            // Unglue
            if (isGlued && (InputManager.GetInstance().GetDownPressed() || InputManager.GetInstance().GetJumpPressed()))
            {
                rb.gravityScale = gravityScale;
            }

            WallSlide();
            Flip();

            if (countryLeft == 0)
            {
                GameObject[] targets = GameObject.FindGameObjectsWithTag("Lock");
                foreach (GameObject target in targets)
                {
                    Destroy(target);
                }
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                isJumping = false;
                canDoubleJump = false;
            }
            if (other.gameObject.CompareTag("WallReset"))
            {
                isWallSliding = true;
                canDoubleJump = true;
            }
            if (other.gameObject.CompareTag("Death"))
            {
                stageGenerator.GenerateStage();
                transform.position = startPosition.transform.position;
                rb.velocity = Vector2.zero;
                ui_Life.LoseLife();
            }
            if (other.gameObject.CompareTag("Glue"))
            {
                canDoubleJump = false;
                isGlued = true;
                rb.gravityScale = 0f;
            }
            if (other.gameObject.CompareTag("Clear"))
            {
                stageGenerator.GenerateStage();
                transform.position = startPosition.transform.position;
                rb.velocity = Vector2.zero;
            }
            if (other.gameObject.CompareTag("Target"))
            {
                Target targetScript = other.gameObject.GetComponent<Target>();
                targetScript.TargetHit();
            }
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Glue"))
            {
                canDoubleJump = false;
                rb.gravityScale = gravityScale;
                isGlued = false;
            }
            if (other.gameObject.CompareTag("WallReset"))
            {
                isWallSliding = false;
                canDoubleJump = true;
            }
            if (other.gameObject.CompareTag("Ground"))
            {
                isJumping = true;
                canDoubleJump = true;
            }
        }

        private void WallSlide()
        {
            if (isWallSliding)
            {
                rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
            }
        }

        private void Flip()
        {
            if (isFacingRight && Move < 0f || !isFacingRight && Move > 0f)
            {
                isFacingRight = !isFacingRight;
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;
            }
        }
    }
}