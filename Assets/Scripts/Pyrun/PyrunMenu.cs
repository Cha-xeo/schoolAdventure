using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PyrunMenu : MonoBehaviour
{

    public GameObject pop;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void goToGame()
    {
        SceneManager.LoadScene("Pyrun");
    }

    public void openPop()
    {
        pop.SetActive(true);
    }

    public void closePop()
    {
        pop.SetActive(false);
    }
}
