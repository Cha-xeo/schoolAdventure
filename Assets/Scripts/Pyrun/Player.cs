using UnityEngine;
using UnityEngine.SceneManagement;
using NCalc;
using UnityEngine.UI;
using TMPro;
using SchoolAdventure.Audio;
using Expression = NCalc.Expression;

namespace SchoolAdventure.Games.Mathematique.Pyrun
{
    public class Player : MonoBehaviour
    {
        private Vector2 targetPos;
        public float Yincrement;

        public float speed;
        public float maxHeight;
        //public float score;
        //public static float statScore;
        public float minHeight;
        public Animator animator;
        public TMP_Text calcul;
        public TMP_Text Score_txt;
        public string stock;
        public int tmp;
        public int tmp2;
        public int tmp3;
        public int Difficulty;

        public Animator anim;

        public Animator heart;

        enum difficulty_ : int { cp, ce1, ce2, cm1, cm2 };
        enum opType : int { addition, soustraction, multiplcation, division };

        [SerializeField] Sprite[] _healthSpriteArray;
        [SerializeField] Image _healtImage;
        [SerializeField] GameObject _spawner;
        [SerializeField] GameObject tutoManager;
        [SerializeField] int _score;
        public int Score
        {
            set
            {
                if (Score == 0)
                {
                    Success.SuccessHandler.Instance.UnlockAchievment(2);
                }
                else if (value == 10)
                {
                    Success.SuccessHandler.Instance.UnlockAchievment(3);
                }else if(value == 100)
                {
                    Success.SuccessHandler.Instance.UnlockAchievment(38);
                }
                _score = value;
                Score_txt.text = value.ToString();
                //statScore = value;
            }
            get => _score;
        }
        [SerializeField] int _health;
        public int Health
        {
            set
            {
                Gameplay.UI.UiHurt.Instance.PlayHurtAnim();
                _health = value;
                if (value == 0) return;
                _healtImage.sprite = _healthSpriteArray[value - 1];
            }
            get => _health;
        }



        public Vector2 playerPosition;
        public VectorValue playerStorage;
        // Start is called before the first frame update

        //tuto
        public bool tutoEnd = false;
        public Animator animtut;
        private void Start()
        {
            if (PlayerPrefs.HasKey("tutoPyrun") && PlayerPrefs.GetInt("tutoPyrun") == 1)
            {
                tutoEnd = true;
            }
            if (tutoEnd == true)
            {
                tutoManager.SetActive(false);
                RefreshCalcul();
                //Get_calcul(1, 5);
            }
        }
        // Update is called once per frame
        void Update()
        {
            if (InputManager.GetInstance().GetUpPressed() && transform.position.y < maxHeight)
            {
                targetPos = new Vector2(transform.position.x, transform.position.y + Yincrement);
                transform.position = targetPos;
                if (tutoEnd == false && animtut.GetInteger("Change") <= 4)
                {
                    animtut.SetInteger("Change", animtut.GetInteger("Change") + 1);
                }
            }
            else if (InputManager.GetInstance().GetDownPressed() && transform.position.y > minHeight)
            {
                targetPos = new Vector2(transform.position.x, transform.position.y - Yincrement);
                transform.position = targetPos;
                if (tutoEnd == false && animtut.GetInteger("Change") <= 4)
                {
                    animtut.SetInteger("Change", animtut.GetInteger("Change") + 1);
                }
            }

            if (tutoEnd == false && animtut.GetInteger("Change") > 4)
            {
                if (!PlayerPrefs.HasKey("tutoPyrun"))
                {
                    PlayerPrefs.SetInt("tutoPyrun", 1);
                }
                tutoEnd = true;
                RefreshCalcul();
                //Get_calcul(1, 5);
            }

            //heart.SetInteger("Pv", health);

            if (Health <= 0)
            {
                PyrunGameManager.instance.GameOver();
                //SceneManager.LoadScene("Game_over_pirun");
            }

            //statScore = score;


            /*Expression expression = new Expression(calcul);
            tmp = (int)expression.Evaluate();

            tmp2 = tmp - 1;
            tmp3 = tmp + 2;*/
        }

        /*public float Get_Score()
        {
            return statScore;
        }*/
        public const string opp = "+-*/";

        public char GetOperator(int difficulty)
        {
            if (difficulty >= 0 && difficulty < 5)
            {
                //Debug.Log(1);
                return opp[0];
            }else if (difficulty >= 5 && difficulty < 10)
            {
                //Debug.Log(2);
                return opp[Random.Range(0, 2)];
            }else if (difficulty >= 10 && difficulty < 15)
            {
                //Debug.Log(3);
                return opp[Random.Range(0, 3)];
            }else if (difficulty >= 15 && difficulty < 20)
            {
                //Debug.Log(4);
                return opp[Random.Range(0, 4)];
            }
            return opp[Random.Range(0, 2)];
        }
        public string Get_operator(int difficulty)
        {
            string ret = "";
            switch ((difficulty_)difficulty)
            {
                case difficulty_.cp:
                    ret = opp[Random.Range(0, 2)].ToString();
                    break;
                case difficulty_.ce1:
                    ret = opp[Random.Range(0, 3)].ToString();
                    break;
                case difficulty_.ce2:
                    ret = opp[Random.Range(0, 3)].ToString();
                    break;
                case difficulty_.cm1:
                    ret = opp[Random.Range(0, 3)].ToString();
                    break;
                case difficulty_.cm2:
                    ret = opp[Random.Range(0, 4)].ToString();
                    break;
            }
            return ret;
        }
        private string get_cp(int niveaux)
        {
            string mtype = "";
            int number1 = 0;
            int number2 = 0;
            switch (niveaux)
            {
                case 0:
                    number1 = Random.Range(0, 10);
                    number2 = Random.Range(1, 10);
                    // ret = number1+" + "+number2;
                    return number1 + " + " + number2;
                case 1:
                    number1 = Random.Range(0, 10);
                    number2 = Random.Range(number1, 10);
                    return number1 + " - " + number2;
                default:
                    mtype = Get_operator((int)difficulty_.cp);
                    switch (mtype)
                    {
                        case "+":
                            number1 = Random.Range(1, 10);
                            number2 = Random.Range(1, 10);
                            break;
                        case "-":
                            number1 = Random.Range(1, 10);
                            number2 = Random.Range(number1, 10);
                            break;
                    }
                    return number1 + " " + mtype + " " + number2;
            }

        }
        private string get_ce1(int niveaux)
        {
            string mtype = "";
            int lvl = (niveaux >= 3) ? 99 : 10;
            int number1 = 0;
            int number2 = 0;
            switch (niveaux)
            {
                case 0:
                    number1 = Random.Range(1, 10);
                    // ret = number1+" + "+number2;
                    return number1 + " + " + number2;
                case 1:
                    number1 = Random.Range(1, 10);
                    return number1 + " + " + number1;
                case 2:
                    number1 = Random.Range(1, 10);
                    return number1 + " * 2";
                case 3:
                    number1 = Random.Range(1, 10);
                    int time = Random.Range(0, 4);
                    return number1 + " * " + time;
                case 4:
                    number1 = Random.Range(1, 10);
                    number2 = Random.Range(1, 3);
                    return number1 + "00 + " + number2 + "00";
                default:
                    mtype = Get_operator((int)difficulty_.ce1);
                    switch (mtype)
                    {
                        case "+":
                            number1 = Random.Range(1, 10);
                            number2 = Random.Range(1, 10);
                            break;
                        case "-":
                            number1 = Random.Range(1, 10);
                            number2 = Random.Range(number1, 10);
                            break;
                        case "*":
                            number1 = Random.Range(1, 5);
                            number2 = Random.Range(0, 5);
                            break;
                    }
                    return number1 + " " + mtype + " " + number2;
            }
        }

        public void RefreshCalcul()
        {
            Difficulty ++;
            string ret = "";
            string mtype = GetOperator(Difficulty).ToString();
            //Debug.Log(mtype);
            int number1 = 0, number2 = 0;
            switch (mtype)
            {
                case "+":
                    number1 = Random.Range(0, 10);
                    number2 = Random.Range(0, 10);
                    break;
                case "-":
                    number1 = Random.Range(0, 10);
                    number2 = Random.Range(0, number1);
                    break;
                case "*":
                    number1 = Random.Range(0, 10);
                    number2 = Random.Range(0, 10);
                    break;
                case "/":
                    number1 = Random.Range(0, 10);
                    number2 = Random.Range(1, 10);
                    break;
            }
            ret = number1 + " " + mtype + " " + number2;

            Expression expression = new Expression(ret);
            calcul.text = ret + " =";
            tmp = (int)expression.Evaluate();
            //Debug.Log(tmp);

            ret = tmp + " " + GetOperator(-42) + " " + Random.Range(1, 10);
            Expression expression1 = new Expression(ret);
            tmp2 = (int)expression1.Evaluate();

            ret = tmp + " " + GetOperator(-42) + " " + Random.Range(1, 10);
            Expression expression2 = new Expression(ret);
            tmp3 = (int)expression2.Evaluate();
        }

        public void Get_calcul(int difficulty, int niveaux)
        {
            string ret = "";
            switch ((difficulty_)difficulty)
            {
                case difficulty_.cp:
                    ret = get_cp(niveaux);
                    break;
                case difficulty_.ce1:
                    ret = get_ce1(niveaux);
                    break;
                case difficulty_.ce2:
                    ret = "0";
                    break;
                case difficulty_.cm1:
                    ret = "0";
                    break;
                case difficulty_.cm2:
                    ret = "0";
                    break;
            }
            stock = ret;
            Expression expression = new Expression(stock);
            calcul.text = stock + " =";
            tmp = (int)expression.Evaluate();

            ret = tmp + " " + Get_operator((int)difficulty_.cp) + " " + Random.Range(1, 10);
            Expression expression1 = new Expression(ret);
            tmp2 = (int)expression1.Evaluate();

            ret = tmp + " " + Get_operator((int)difficulty_.cp) + " " + Random.Range(1, 10);
            Expression expression2 = new Expression(ret);
            tmp3 = (int)expression2.Evaluate();
        }

    }
}