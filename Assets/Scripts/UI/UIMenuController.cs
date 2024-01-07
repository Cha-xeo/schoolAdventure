using System.Collections;
using UnityEngine;

namespace SchoolAdventure.Gameplay.UI
{
    public class UIMenuController : MonoBehaviour
    {
        [SerializeField] GameObject[] _ToHide;
        /*public void OnEnable()
        {
            AplicationController.AplicationController.Instance.gameIsPaused = !AplicationController.AplicationController.Instance.gameIsPaused;
            Time.timeScale = AplicationController.AplicationController.Instance.gameIsPaused ? 0f : 1f;
        }*/

        private void OnEnable()
        {
            // show main menu
            _ToHide[0].SetActive(true);

            AplicationController.AplicationController.Instance.gameIsPaused = true;
            Time.timeScale = 0f;
        }

        private void OnDisable()
        {
            //hide all menu
            foreach (GameObject go in _ToHide) { go.SetActive(false); }
            AplicationController.AplicationController.Instance.gameIsPaused = false;
            Time.timeScale = 1;
        }
    }
}