using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SchoolAdventure.Games.Mathematique.Colorun
{
    public class CameraMove : MonoBehaviour
    {
        public float cameraSpeed;
        public float updatedSpeed;

        void Start()
        {
            cameraSpeed = 8.5f;
            updatedSpeed = ColorunPlayer.updatedSpeed;
        }

        void Update()
        {
            cameraSpeed = ColorunPlayer.updatedSpeed;
            transform.position += new Vector3(cameraSpeed * Time.deltaTime, 0, 0);
        }
    }
}