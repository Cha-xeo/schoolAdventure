using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class win : MonoBehaviour
{
    public GameObject dialogBox_door1;
    public GameObject door_1;
    public Text dialogText_door1;
    public string dialog_door1;
    public bool dialogActive_door1; 
    
    
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        dialogBox_door1.SetActive(true);
        dialogText_door1.text = dialog_door1;

    }

    private void OnTriggerExit2D(Collider2D other)
    {
      
        dialogBox_door1.SetActive(false);
    }
   

}