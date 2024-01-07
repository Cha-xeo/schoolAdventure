using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleInfo : MonoBehaviour
{
    public GameObject info;
    
    public void ToggleGameObject()
    {
        if (info != null)
        {
            info.SetActive(!info.activeSelf);
        }
    }
}
