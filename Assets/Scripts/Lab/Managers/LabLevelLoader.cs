using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SchoolAdventure.Games.Lab.Manager
{
    public class LabLevelLoader : MonoBehaviour
    {
        public Animator transition;
        public float transitionTime = 1f;
        [SerializeField] private LabGameManager _gameManager;
        [SerializeField] private Canvas _mainMenuCanvas;

        public void StartTransition()
        {
            StartCoroutine(Transition());
        }
        IEnumerator Transition()
        {
            transition.SetTrigger("Start");
            yield return new WaitForSeconds(transitionTime);
            _mainMenuCanvas.gameObject.SetActive(false);
            _gameManager.SceneAdvance();
        }

        public void LoadNextLevel()
        {
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        }
        public void LoadLevel(string name)
        {
            StartCoroutine(LoadLevelByName(name));
        }

        IEnumerator LoadLevel(int levelIndex)
        {
            yield return new WaitForSeconds(transitionTime);
            transition.SetTrigger("Start");
            SceneManager.LoadScene(levelIndex);
        }
        IEnumerator LoadLevelByName(string name)
        {
            yield return new WaitForSeconds(transitionTime);
            transition.SetTrigger("Start");
            SceneManager.LoadScene(name);
        }
    }
}