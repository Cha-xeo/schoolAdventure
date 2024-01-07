
using UnityEngine;

namespace SchoolAdventure.DungeonPuzzle.Input
{
    public class PlayerInput : MonoBehaviour
    {
       // InputHandler _input;
        private void Awake()
        {
            //_input = GameObject.FindGameObjectWithTag(Constants.TAG_MATCHINGZONE).GetComponentInChildren<InputHandler>();
        }
        private void Update()
        {
            if (InputManager.GetInstance().GetSubmitPressed())
            {
                Player.PlayerManager.Instance.Element.SwitchElement();
            }
        }
    }
}
