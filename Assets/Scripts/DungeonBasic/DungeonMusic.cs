using SchoolAdventure.Gameplay.Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DungeonMusic : MonoBehaviour
{
    [SerializeField] MusicHandlerV2 musicHandler;

    private void Start()
    {
        musicHandler.PlayMusic(SchoolAdventure.Gameplay.Audio.MusicType.MainMenu);
    }
}
