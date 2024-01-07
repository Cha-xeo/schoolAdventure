using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymphoQuizPiano : MonoBehaviour
{

    [SerializeField] AudioClip Note;

    void Start()
    {
        
    }

    public void PlayNote()
    {
        SchoolAdventure.Audio.SoundManagerV2.Instance.PlaySound(Note);
    }
}
