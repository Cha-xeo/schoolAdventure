using System;
using UnityEngine;

namespace SchoolAdventure.UI
{
    public class ResetTuto : MonoBehaviour
    {
        private void Start()
        {
            PlayerPrefs.DeleteKey("tutoMenu");
            Debug.Log(PlayerPrefs.HasKey("tutoMenu"));
        }
    }
}
