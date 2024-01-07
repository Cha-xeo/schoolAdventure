using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace SchoolAdventure.Gameplay.UI
{
    public class UISettingsCanvas : MonoBehaviour
    {
        [SerializeField] GameObject _MenuPanelRoot;
        [SerializeField] TMP_Text _MenuBoutonText;
        [SerializeField] Image _MenuBoutonImage;
        [SerializeField] Sprite _MenuBoutonImageRed;
        [SerializeField] Sprite _MenuBoutonImageOrange;
        [SerializeField] Transform _helpPanelBodyTransform;
        GameObject _HelpObject;
        private static UISettingsCanvas _instance;
        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }
            else
            {
                Destroy(this);
            }
        }
        public static UISettingsCanvas GetInstance()
        {
            return _instance;
        }

        public void CallMenu()
        {
            EventSystem.current.SetSelectedGameObject(null);
            _MenuPanelRoot.SetActive(!_MenuPanelRoot.activeSelf);
            _MenuBoutonText.text = _MenuPanelRoot.activeSelf ? "Fermer" : "Menu";
            _MenuBoutonImage.sprite = _MenuPanelRoot.activeSelf ? _MenuBoutonImageRed : _MenuBoutonImageOrange;
        }

        public void LoadHelp(GameObject helpPrefab)
        {
            if (!helpPrefab) return;
            _HelpObject = Instantiate(helpPrefab, _helpPanelBodyTransform);
        }

        public void ResetHelp()
        {
            Destroy(_HelpObject);
        }
    }
}
