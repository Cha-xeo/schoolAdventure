using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SchoolAdventure.Games.Mathematique.Pyrun
{
    public class Paralax : MonoBehaviour
    {
        // vitesse de la paralax
        public float speed;
        // position retour de la paralax
        public float endX;
        // position debut paralax
        public float startX;

        private void Update()
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            if (transform.position.x <= endX)
            {
                Vector2 pos = new Vector2(startX, transform.position.y);
                transform.position = pos;
            }
        }
    }
}
