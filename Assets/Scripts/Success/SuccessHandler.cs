using SchoolAdventure.Games.Langues.Pendu;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SchoolAdventure.Success
{
    [System.Serializable]
    public class SuccessTemplate
    {
        public string GameName;
        public int GameID;
        public ScriptableSuccess[] _successArray;
    }
    public class SuccessHandler : MonoBehaviour
    {
        public static SuccessHandler Instance { get; private set; }
        //public List<SuccessTemplate> _successList;
        List<ScriptableSuccess> _successSciptableList;

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

        private void Start()
        {
            if (Instance)
            {
                _successSciptableList = Resources.LoadAll<ScriptableSuccess>("Success").ToList();
            }
        }

        public void UnlockAchievment(int idAchievment)
        {
            if (idAchievment == 0) return;
            foreach (ScriptableSuccess achievment in _successSciptableList)
            {
                if (achievment._id == idAchievment)
                {
                    if (!achievment._unlocked)
                    {
                        UI.PopUp.PopUpHandler.Instance.DisplaySuccessPopUp(achievment);
                        achievment._unlocked = true;
                    }
                    return;
                }
            }
        }
    }

}