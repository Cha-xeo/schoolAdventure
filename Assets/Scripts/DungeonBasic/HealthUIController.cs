using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SchoolAdventure.Dungeon.Generation
{
    public class HealthUIController : MonoBehaviour
    {
        //public GameObject heartContainer;
        //private float fillValue;
        [SerializeField] TextMeshProUGUI textMeshProUGUI;
        float timer = 0;
        // Update is called once per frame
        /*void Update()
        {
            fillValue = (float)GameController.Health;
            fillValue = fillValue / GameController.MaxHealth;
            heartContainer.GetComponent<Image>().fillAmount = fillValue;
        }*/

        /*private void Update()
        {
            timer += Time.deltaTime;
        }
        private void FixedUpdate()
        {
            textMeshProUGUI.text = ((int)timer).ToString();
        }*/
    }
}
