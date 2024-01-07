using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NCalc;
using UnityEngine.UI;
using TMPro;

namespace SchoolAdventure.Games.Mathematique.Pyrun
{
    enum ChestType
    {
        Good,
        Bad1,
        Bad2
    }
    public class Chest : MonoBehaviour
    {
        public float speed;
        public Animator youranimation;
        [SerializeField] TMP_Text _text;
        [SerializeField] ChestType _chest;
        // Start is called before the first frame update

        void Start()
        {
            switch (_chest)
            {
                case ChestType.Good:
                    _text.text = PyrunGameManager.instance.GetPlayer().tmp.ToString();
                    //Debug.Log(PyrunGameManager.instance.GetPlayer().tmp.ToString());
                    break;
                case ChestType.Bad1:
                    _text.text = PyrunGameManager.instance.GetPlayer().tmp2.ToString();
                    break;
                case ChestType.Bad2:
                    _text.text = PyrunGameManager.instance.GetPlayer().tmp3.ToString();
                    break;
                default:
                    break;
            }
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(Constants.TAG_PLAYER))
            {
                switch (_chest)
                {
                    case ChestType.Good:
                        other.GetComponent<Player>().Score += 5;
                        break;
                    case ChestType.Bad1:
                    case ChestType.Bad2:
                        other.GetComponent<Player>().anim.SetTrigger("isHurting");
                        other.GetComponent<Player>().Health--;
                        youranimation.SetTrigger("isBoom");
                        Destroy(gameObject, 0.5f);
                        break;
                    default:
                        break;
                }
                //other.GetComponent<Player>().Get_calcul(1, 5);
                other.GetComponent<Player>().RefreshCalcul();

                youranimation.SetTrigger("isOk");
            }
        }

        // Update is called once per frame
        void Update()
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        void OnBecameInvisible()
        {
            Destroy(gameObject);
        }
    }
}
