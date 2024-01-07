using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntruderHelp : MonoBehaviour
{
    public GameObject Rules;
    public GameObject Exception;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void helpRule()
    {
        Rules.SetActive(true);
        Exception.SetActive(false);
    }

    public void helpExeption()
    {
        Rules.SetActive(false);
        Exception.SetActive(true);
    }
}
