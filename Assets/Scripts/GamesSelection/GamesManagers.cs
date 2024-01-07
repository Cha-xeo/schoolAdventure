using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Linq;
using System;
using SchoolAdventure.Gameplay.Audio;
using SchoolAdventure.Audio;
using SchoolAdventure.Gameplay.UI;

namespace SchoolAdventure.GameSelection
{
    public class GamesManagers : MonoBehaviour
    {

        [SerializeField] Sprite _workInProgress;

        //[HideInInspector] public Dictionary<string, ScriptableGames> _games = new Dictionary<string, ScriptableGames>();
        [HideInInspector] public List<ScriptableGames> _games = new List<ScriptableGames>();

        [SerializeField] RectTransform _gamesPanel;
        [SerializeField] Button _buttonPrefab;
        [SerializeField] MusicHandlerV2 _musicHandler;
        private Button _buttontmp;
        [HideInInspector] public List<Button> _buttons;
        [SerializeField] AudioClip _soundEffect;
        [SerializeField] Sprite[] _btnSprite; 
        [SerializeField] Image _activImg;
        string _lastFilter;

        public class GameSearch : MonoBehaviour
        {
            public string Name;
            public string Matiere;
            int Length;
            public void init(string name, string matiere)
            {
                Name = name.ToLower();
                Matiere = matiere.ToLower();
            }
        }
        // Start is called before the first frame update
        void Start()
        {
            AplicationController.AplicationController.Instance.isQuitLobby = false;
            AplicationController.AplicationController.Instance.m_QuitMode = AplicationController.QuitMode.QuitApplication;
            _games = Resources.LoadAll<ScriptableGames>("Games").ToList();
            foreach (ScriptableGames item in _games)
            {
                if (!item.includeInBuild) continue;
                AplicationController.AplicationController.Instance.GameList.Add((item._sceneName, item.ID));
                AddButton(item);
            }
            _musicHandler.PlayMusic(0);
        }

        void AddButton(ScriptableGames item)
        {
            _buttons.Add(Instantiate(_buttonPrefab, _gamesPanel, false));
            _buttons.Last().gameObject.AddComponent<GameSearch>().init(item._name, item._matiere);
            _buttons.Last().GetComponentInChildren<TextMeshProUGUI>().text = item._name;
            _buttons.Last().transform.GetChild(0).GetComponent<Image>().sprite = item._icon ? item._icon : _workInProgress;
            _buttons.Last().onClick.AddListener(MenuClick);
            _buttons.Last().onClick.AddListener(() => UISettingsCanvas.GetInstance().LoadHelp(item.helpPrefab));
            _buttons.Last().onClick.AddListener(() => Utils.StaticUtils.LoadGame(item._sceneName, item.ID));
            _buttons.Last().onClick.AddListener(() => AplicationController.AplicationController.Instance.m_QuitMode = AplicationController.QuitMode.ReturnToGameSelection);
        }

        public void QuitGame()
        {
#if !UNITY_EDITOR
			        Application.Quit();
#endif

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }

        public void MenuClick()
        {
            SchoolAdventure.Audio.SoundManagerV2.Instance.PlaySound(_soundEffect);
        }

        public void StartGameHandler(string name)
        {
            SceneManager.LoadScene(name);
        }


        public void GamesFilter(string str)
        {
            
            if (str.Length < 3 || _lastFilter == str)
            {
                _lastFilter = "";
               // _activImg.sprite = _btnSprite[1];
                foreach (var item in _buttons)
                {
                    item.gameObject.SetActive(true);
                }
                return;
            }
            //_activImg.sprite = _btnSprite[0];
            str = str.ToLower();
            foreach (var item in _buttons)
            {
                if (item.gameObject.GetComponent<GameSearch>().Name.ToLower().Contains(str) || item.gameObject.GetComponent<GameSearch>().Matiere.Contains(str))
                {
                    item.gameObject.SetActive(true);
                }
                else
                {
                    item.gameObject.SetActive(false);
                }
            }
            _lastFilter = str;
        }
    }
}
