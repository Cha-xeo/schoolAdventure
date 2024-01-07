using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSoundManager : MonoBehaviour
{
    public AudioSource sound;

    IEnumerator timer()
    {
        sound.Play();
        yield return new WaitForSeconds(5);
    }

    /*public void playSound()
    {
        
        StartCoroutine(timer());
    }*/
}
