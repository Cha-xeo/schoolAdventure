using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;


namespace SchoolAdventure.Games.Geometrie
{
    public class mouseGame : MonoBehaviour
    {
        Vector3 pos;
        [SerializeField] Camera cam;
        
        void FixedUpdate()
        {
            pos = cam.ScreenToWorldPoint(InputManager.GetInstance().GetRawMousePosition());
            pos.z = 0;
            transform.position = pos;
        }
    }
}
