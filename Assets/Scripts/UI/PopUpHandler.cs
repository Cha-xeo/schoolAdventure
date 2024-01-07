using SchoolAdventure.AplicationController;
using System.Collections;
using UnityEngine;

namespace SchoolAdventure.UI.PopUp
{
    public class PopUpHandler : MonoBehaviour
    {
        public static PopUpHandler Instance { get; private set; }
        [SerializeField] GameObject PopUpPrefab;
        void Awake()
        {
            if (Instance)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
        }
        
        public void DisplaySuccessPopUp(ScriptableSuccess sc)
        {
            Instantiate(PopUpPrefab, transform).GetComponent<PopUpSucces>().SetSuccess(sc);
            // TODO send success to db, link success to profile
        }
    }
}