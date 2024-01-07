using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player1 : BasePlayer
{
    

    private void FixedUpdate()
    {
        if (Light.intensity <= 0f)
        {
            ChangeColor();
            //Debug.Log("Death");
        }
    }
}
