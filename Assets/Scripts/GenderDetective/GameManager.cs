using SchoolAdventure.Gameplay.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using yutokun;
using Random = UnityEngine.Random;

namespace SchoolAdventure.Games.Langues.GenderDetective
{
    public enum Gender
    {
        Masculin,
        Feminin
    }
    [System.Serializable]
    public struct GenderWord
    {
       public string particle;
        public string word;
        public Gender gender;
        public void Log()
        {
            Debug.Log(particle + " : " + word);
        }
        public bool EquelGender(Gender gender)
        {
            return this.gender == gender;
        }

        public GenderWord(string word, char gender, string particle)
        {
            this.word = word;
            this.gender = gender == 'm' ? Gender.Masculin : Gender.Feminin;
            this.particle = particle;
        }
        public GenderWord(Gender gender)
        {
            this.word = gender.ToString();
            this.gender = gender;
            this.particle = "";
        }
    }
    public enum GameMode
    {
        Menu,
        Find,
    }

    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        public static event Action<GameMode> ModeChanged;
        public static event Action<int> HealthCHanged;
        [SerializeField] MusicHandlerV2 musicHandler;
        void Awake()
        {
            if (Instance)
            {
                Destroy(Instance);
            }
            else
            {
                Instance = this;
            }
        }
        GameMode _currentMode;
        GameMode _LastMode;
        

        [SerializeField] TextAsset CSVAsset;
        [HideInInspector] public List<List<string>> sheet = new List<List<string>>();
        [HideInInspector] public List<GenderWord> WordDB = new List<GenderWord>();

        [SerializeField] FindGameController _findGameController;
        [SerializeField] GameObject _MenuPanelRoot;
        [SerializeField] TMP_Text _scoreText;

        private int _score;
        public int Score
        {
            get
            {
                return _score; 
            }
            set
            {
                //if (_currentMode == GameMode.Menu) return;
                if (value == 5 && Health == 3)
                {
                    Success.SuccessHandler.Instance.UnlockAchievment(4);
                }
                _score = value;
                _scoreText.text = _score.ToString();
            }
        }
        public int maxHealth;// { private set; get;}
        private int _health;
        public int Health 
        { 
            get 
            {
                return _health; 
            } 
            set 
            {
                _health = value;
                if (_currentMode != GameMode.Menu) HealthCHanged(value);
                if (value <= 0)
                {
                    switch (_currentMode)
                    {
                        case GameMode.Menu:
                            break;
                        case GameMode.Find:
                            _findGameController.UnInitialize();
                            _findGameController.gameObject.SetActive(false);
                            UpdateGameState(GameMode.Menu);
                            break;
                    }
                }
            }
        }

        int GRight = -1;
        int GLeft = -1;

        void Start()
        {
            //musicHandler.PlayMusic(Gameplay.Audio.MusicType.MainMenu);
            _findGameController.gameObject.SetActive(false);
            ModeChanged += UpdateGameState;
            HealthCHanged += PlaceHolder;
            sheet = CSVParser.LoadFromString(CSVAsset.text);
            foreach (var item in sheet)
            {
                if (item == sheet.First()) {  continue; }
                WordDB.Add(new GenderWord( item[0], item[1][0], item[4]));
            }
            ModeChanged(GameMode.Menu);
            // TODO
            // UpdateGameState((GameMode)Random.Range(0, Enum.GetNames(typeof(GameMode)).Length));
            //
            //UpdateGameState(currentMode);

        }



        public void Play()
        {
            ModeChanged(GameMode.Find);
        }

        public void UpdateGameState(GameMode newMode)
        {
            _currentMode = newMode;
            switch (_currentMode)
            {
                case GameMode.Menu:
                    musicHandler.PlayMusic(Gameplay.Audio.MusicType.MainMenu);
                    _MenuPanelRoot.SetActive(true);
                    break;
                case GameMode.Find:
                    musicHandler.PlayMusic(Gameplay.Audio.MusicType.InGame1);
                    _MenuPanelRoot.SetActive(false);
                    _findGameController.gameObject.SetActive(true);
                    Health = maxHealth;
                    _findGameController.Initialize();
                    _findGameController.GetWinningGender();
                    _findGameController.ShowWining();
                    _findGameController.FillButtons();
                    break;
            }
        }

        public GenderWord GetGenderWord(Gender gender)
        {
            List<GenderWord> tmp = WordDB.FindAll(x => x.gender == gender);
            return tmp[Random.Range(0, tmp.Count)];
        }

        public int checkResponseV2(Gender gender, bool leftSide)
        {
            if (leftSide)
            {
                GLeft = (int)gender;
            }
            else
            {
                GRight = (int)gender;
            }
            if (GRight == -1 && GLeft == -1)
            {
                return 0;
            }
            else if (GRight == GLeft)
            {
                return 2;
            }
            return 1;
        }

        public bool CheckResponse(Gender gender)
        {
            return gender == _findGameController.winingGender;
                    
        }

        public void Cleared(Gender gender = 0)
        {
            switch (_currentMode)
            {
                case GameMode.Find:
                    _findGameController.Restart();
                    break;
            }
        }

        public void Failed()
        {
            Health--;
            Gameplay.UI.UiHurt.Instance.PlayHurtAnim();
        }

        public void PlaceHolder(int a)
        {
        }

        void OnDestroy()
        {
            ModeChanged -= UpdateGameState;
            HealthCHanged -= PlaceHolder;
        }
    }
}
