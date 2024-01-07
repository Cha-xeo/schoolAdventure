using SchoolAdventure.DungeonPuzzle.Scriptable.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SchoolAdventure.DungeonPuzzle.Player.Elements
{
    public class ElementsScript : MonoBehaviour
    {
        Dictionary<string, ElementScriptable> _elements = new Dictionary<string, ElementScriptable>();
        ElementScriptable _currentElement;

        private void Awake()
        {
            //_element = Resources.LoadAll<ElementScriptable>("DungeonPuzzle/Elements");
            _elements = Resources.LoadAll<ElementScriptable>("DungeonPuzzle/Elements").ToDictionary(x => x.name, x => x);
            _currentElement = _elements["None"];
        }
        public void SwitchElement(string name)
        {
            _currentElement = _elements[name];
            Player.PlayerManager.Instance.ElementChanged();
        }
        public void SwitchElement()
        {
            switch (_currentElement.ID.ID)
            {
                case 0:
                    _currentElement = _elements["Lightning"];
                    break;
                case 1:
                    _currentElement = _elements["Ice"];
                    break;
                case 2:
                    _currentElement = _elements["Fire"];
                    break;
                case 3:
                    _currentElement = _elements["None"];
                    break;
                default:
                    throw new NotImplementedException();
            }
            Player.PlayerManager.Instance.ElementChanged();
        }

        public ElementScriptable GetCurrentElement()
        {
            return _currentElement;
        }
    }
}
