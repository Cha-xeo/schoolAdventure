using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SchoolAdventure.Games.Mathematique.Pyrun
{
    public class test : MonoBehaviour
    {
        // Start is called before the first frame update
        public float timeLeft = 2;

        // Update is called once per frame
        void Update()
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
