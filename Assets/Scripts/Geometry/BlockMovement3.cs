using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace SchoolAdventure.Games.Geometrie
{
    public class BlockMovement3 : MonoBehaviour, IPointerClickHandler
    {
        public TMP_Text formText;
        public bool isOK = false;
        public static float randForm;

        void Start()
        {
            if (this.CompareTag("1"))
            {
                Randomizer();
                TextDisplayer();
            }
        }

        void Update()
        {
            Reset();
        }

        void Reset()
        {
            float xPos = Random.Range(-7, 7);
            float yVel = Random.Range(11, 15);
            float xVel = Random.Range(-4, 4);

            if (this.transform.position.y < -6)
            {
                if (!isOK)
                    isOK = true;
                if (xPos < -3)
                    xVel = Random.Range(-1, 6);
                if (xPos > 3)
                    xVel = Random.Range(-6, 1);
                xPos = Random.Range(-7, 7);
                this.transform.position = new Vector2(xPos, -6);
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(xVel, yVel);
                this.GetComponent<Rigidbody2D>().AddTorque(13);
            }
        }

        void Randomizer()
        {
            randForm = Random.Range(1, 8);
        }

        void TextDisplayer()
        {
            if (randForm == 1)
                formText.text = "Triangle";
            if (randForm == 2)
                formText.text = "Carré";
            if (randForm == 3)
                formText.text = "Cercle";
            if (randForm == 4)
                formText.text = "Etoile";
            if (randForm == 5)
                formText.text = "Trapèze";
            if (randForm == 6)
                formText.text = "Pentagone";
            if (randForm == 7)
                formText.text = "Hexagone";
        }

        public virtual void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log("clicked");

            if (isOK && this.CompareTag(randForm.ToString()))
            {
                isOK = false;
                ScoreManagerGeometry.instance.addPoint();
                Randomizer();
                TextDisplayer();
            }
            if (isOK && !this.CompareTag(randForm.ToString()))
            {
                isOK = false;
                LivesManager.instance.removeLife();
            }
        }
    }
}