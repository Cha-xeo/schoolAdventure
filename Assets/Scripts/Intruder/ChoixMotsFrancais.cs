using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class ChoixMotsFrancais : MonoBehaviour
{
    public Button bouton1;
    public Button bouton2;
    public Button bouton3;
    public Button bouton4;
    public Button boutonHelp;
    public Button bouton50;
    public GameObject correct;
    public GameObject erreur;
    public GameObject helpPannel;
    private bool GameOver = false;
    public Animator animTransition;
    public Animator animLife;
    public GameObject Score;
    private int ScoreValue = 0;
    public TMP_Text overScoreTexte;
    public TMP_Text scoreTexte;

    public GameObject GameOverObject;
    private List<Button> boutons;

    public Animator Man01;
    public Animator Man02;
    public Animator Man03;
    public Animator Man04;

    private List<Animator> Mans;

    public bool transiMid = true;

    [SerializeField] AudioClip EvilChoice;
    [SerializeField] AudioClip InnoChoice;

    private int boutonsInnocentsAGriser = 2;

    

    private int boutonIntrusIndex; // Conserver l'index du bouton intrus

    private List<string> motsFiniParE = new List<string>() {
        "la psyché", "l'acné", "une clé", "la solidarité", "l'amitié", "la pitié", "la volonté", "l'efficacité"
        , "la moitié", "la pâté", "il a sauté", "elle a coupé", "tu as cassé", "elle a mangé", "j'ai acheté", "tu as aimé", "un bébé", "le déjeuné", "il a développé",
        "tu as dessiné", "elle a détesté", "tu as dévoilé", "je suis enchanté", "j'ai espéré", "elle a foncé", "tu as gagné", "il est habillé",
        "tu as ignoré", "je suis informé", "tu as inventé", "elle a jeté", "il a lancé", "il est marié", "il a monté", "j'ai négligé", "j'ai oublié",
        "tu as parlé", "ils ont passé", "tu as porté", "il a préparé"
        // Ajoutez d'autres mots ici
    };

    // Liste des mots finissant par "ée" mais écrits avec "é"
    private List<string> motsFiniParEEAvecE = new List<string>() {
    "le lycée", "le musée", "l'apogée", "une araignée",
    "le mausolée", "le trophée", "un athée", "une dictée", "une année", "une idée", "une cheminée", "une armée", "une allée", "la montée"
    , "une gorgée" , "une bouchée", "une orchidée", "une fusée", "une entrée", "la lignée", "une portée", "une fournée", "une poignée", "la fumée"
    };

    public float TimeLeft = 30;
    public bool TimerOn = false;
    public TMP_Text TimerText;

    void Start() 
    {
        boutons = new List<Button> { bouton1, bouton2, bouton3, bouton4 };
        Mans = new List<Animator> { Man01, Man02, Man03, Man04 };

        doButton();
        
        foreach (Button bouton in boutons)
        {
            bouton.onClick.AddListener(() => OnButtonClick(bouton));
        }

        TimerOn = true;
    }

    public void OnAideButtonClick()
    {

        //liste d'indices des boutons innocents
        List<int> indicesInnocents = new List<int> { 0, 1, 2, 3 };
        indicesInnocents.Remove(boutonIntrusIndex); // -indice du bouton intrus

        for (int i = 0; i < indicesInnocents.Count; i++)
        {
            int randomIndex = Random.Range(i, indicesInnocents.Count);
            int temp = indicesInnocents[i];
            indicesInnocents[i] = indicesInnocents[randomIndex];
            indicesInnocents[randomIndex] = temp;
        }

        for (int i = 0; i < boutonsInnocentsAGriser; i++)
        {
            int index = indicesInnocents[i];
            boutons[index].interactable = false;
        }
        
        int boutonInnocentAReactiver = indicesInnocents[boutonsInnocentsAGriser];
        boutons[boutonInnocentAReactiver].interactable = true;

        bouton50.gameObject.SetActive(false);
    }

    void Update()
    {
        if (InputManager.GetInstance().GetAnyKeyPressed() || InputManager.GetInstance().GetRightMousePressed() || InputManager.GetInstance().GetLeftMousePressed())
        {
            if (GameOver == true) {
                animTransition.SetTrigger("Transi");
                correct.SetActive(false);
                erreur.SetActive(false);
                
                //GameOver = false;
            }
        }

        if (TimerOn)
            {
                if (TimeLeft > 0)
                {
                    TimeLeft -= Time.deltaTime;
                    updateTimer(TimeLeft);
                }
                else
                {
                    TimeLeft = 0;
                    TimerOn = false;



                    SchoolAdventure.Audio.SoundManagerV2.Instance.PlaySound(InnoChoice);
                    animLife.SetInteger("Life", animLife.GetInteger("Life") - 1);
                    erreur.SetActive(true);
                    bouton1.interactable = false;
                    bouton2.interactable = false;
                    bouton3.interactable = false;
                    bouton4.interactable = false;
                    boutonHelp.gameObject.SetActive(false);
                    for (int i = 0; i < Mans.Count; i++)
                    {
                        Mans[i].SetTrigger(i == boutonIntrusIndex ? "EvilWin" : "InnoLose");
                    }
                    GameOver = true;
                }
            }
    }

    void updateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        TimerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }

    public void ChangeButton() {
        
        doButton();
        
    }

    public void resetGame()
    {
        
        GameOver = false;
        bouton1.interactable = true;
        bouton2.interactable = true;
        bouton3.interactable = true;
        bouton4.interactable = true;
        boutonHelp.gameObject.SetActive(true);
        for (int i = 0; i < Mans.Count; i++)
            {
                //string trigger = ;
                Mans[i].SetTrigger("Reset");
            }
        TimeLeft = 30;
        TimerOn = true;
        /*bouton1.interactable = true;
        bouton2.interactable = true;
        bouton3.interactable = true;
        bouton4.interactable = true;*/
    }

    private void doButton()
    {
        bool choisirEE = Random.Range(0, 2) == 0;

        boutonIntrusIndex = Random.Range(0, boutons.Count);
        Button boutonIntrus = boutons[boutonIntrusIndex];

        List<string> motsChoisis = new List<string>();


        /*if (choisirEE)
        {
            //int positionMotE = Random.Range(0, 3);

            for (int i = 0; i < boutons.Count; i++)
            {
                string motChoisi = i == boutonIntrusIndex ? (ChoisirMotFiniParE() + "e") : ChoisirMotFiniParEEAvecE();
                SetButtonTMPText(boutons[i], motChoisi);
            }
        }
        else
        {
            //int positionMotEEAvecE = Random.Range(0, 3);

            for (int i = 0; i < boutons.Count; i++)
            {
                string motChoisi = i == boutonIntrusIndex ? RemoveLastCharacter(ChoisirMotFiniParEEAvecE()) : ChoisirMotFiniParE();
                //if (i == boutonIntrusIndex) {
                //    motChoisi = Substring(0, motChoisi.Length - 1);
                //}
                //i == boutonIntrusIndex ? motChoisi = Substring(0, ChoisirMotFiniParEEAvecE().Length - 1);
                SetButtonTMPText(boutons[i], motChoisi);
            }
        }*/

        if (choisirEE)
        {
            //int positionMotE = Random.Range(0, 3);
            
            for (int i = 0; i < boutons.Count; i++)
            {
                if (i == boutonIntrusIndex) { 
                    motsChoisis.Add(ChoisirMotFiniParE() + "e");
                } else {
                    string motsChoisi;
                    do {
                        motsChoisi = ChoisirMotFiniParEEAvecE();
                    } while (motsChoisis.Contains(motsChoisi));
                    
                    motsChoisis.Add(motsChoisi);
                }
                //SetButtonTMPText(boutons[i], motChoisi);
            }
        }
        else
        {
            //int positionMotEEAvecE = Random.Range(0, 3);
            for (int i = 0; i < boutons.Count; i++)
            {
                if (i == boutonIntrusIndex) {
                    motsChoisis.Add(RemoveLastCharacter(ChoisirMotFiniParEEAvecE()));
                } else {
                    string motsChoisi;
                    do {
                        motsChoisi = ChoisirMotFiniParE();
                    } while (motsChoisis.Contains(motsChoisi));

                    motsChoisis.Add(motsChoisi);
                }
                //string motChoisi = i == boutonIntrusIndex ? motsChoisis.Add(RemoveLastCharacter(ChoisirMotFiniParEEAvecE())) : motsChoisis.Add(ChoisirMotFiniParE());
                /*if (i == boutonIntrusIndex) {
                    motChoisi = Substring(0, motChoisi.Length - 1);
                }*/
                //i == boutonIntrusIndex ? motChoisi = Substring(0, ChoisirMotFiniParEEAvecE().Length - 1);
                //SetButtonTMPText(boutons[i], motChoisi);
            }
        }

    
        for (int i = 0; i < boutons.Count; i++)
        {
            SetButtonTMPText(boutons[i], motsChoisis[i]);
        }
        
        
        
    }

    private string RemoveLastCharacter(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        return input.Substring(0, input.Length - 1);
    }

    void SetButtonTMPText(Button button, string text)
    {
        TextMeshProUGUI textMeshPro = button.GetComponentInChildren<TextMeshProUGUI>();
        if (textMeshPro != null)
        {
            textMeshPro.text = text;
        }
    }
    
    void OnButtonClick(Button clickedButton)
    {
        Debug.Log(boutonIntrusIndex);
        TimerOn = false;
        if (boutons.IndexOf(clickedButton) == boutonIntrusIndex && GameOver == false)
        {
            //gagné
            SchoolAdventure.Success.SuccessHandler.Instance.UnlockAchievment(7);
            SchoolAdventure.Audio.SoundManagerV2.Instance.PlaySound(EvilChoice);
            ScoreValue++;
            scoreTexte.SetText(ScoreValue.ToString());
            if (ScoreValue == 5) {
                SchoolAdventure.Success.SuccessHandler.Instance.UnlockAchievment(8);
            }
            else if (ScoreValue == 15) {
                SchoolAdventure.Success.SuccessHandler.Instance.UnlockAchievment(9);
            }
            else if (ScoreValue == 30) {
                SchoolAdventure.Success.SuccessHandler.Instance.UnlockAchievment(10);
            }
            correct.SetActive(true);
            bouton1.interactable = false;
            bouton2.interactable = false;
            bouton3.interactable = false;
            bouton4.interactable = false;
            boutonHelp.gameObject.SetActive(false);
            for (int i = 0; i < Mans.Count; i++)
            {
                //string trigger = ;
                Mans[i].SetTrigger(i == boutonIntrusIndex ? "EvilLose" : "InnoWin");
            }
            //doButton();
        }
        else if (GameOver == false)
        {
            //perdu
            SchoolAdventure.Gameplay.UI.UiHurt.Instance.PlayHurtAnim();
            SchoolAdventure.Audio.SoundManagerV2.Instance.PlaySound(InnoChoice);
            animLife.SetInteger("Life", animLife.GetInteger("Life") - 1);
            erreur.SetActive(true);
            bouton1.interactable = false;
            bouton2.interactable = false;
            bouton3.interactable = false;
            bouton4.interactable = false;
            boutonHelp.gameObject.SetActive(false);
            for (int i = 0; i < Mans.Count; i++)
            {
                Mans[i].SetTrigger(i == boutonIntrusIndex ? "EvilWin" : "InnoLose");
            }
            //doButton();
        }
        if (animLife.GetInteger("Life") <= 0) {
            GameOverObject.SetActive(true);
            Score.SetActive(false);
            erreur.SetActive(false);
            overScoreTexte.SetText(ScoreValue.ToString());
        } else {
            GameOver = true;
        }
    }

    private string ChoisirMotFiniParE()
    {
        int index = Random.Range(0, motsFiniParE.Count);
        return motsFiniParE[index];
    }

    private string ChoisirMotFiniParEEAvecE()
    {
        int index = Random.Range(0, motsFiniParEEAvecE.Count);
        return motsFiniParEEAvecE[index];
    }


    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void helpOpen()
    {
        bouton1.interactable = false;
        bouton2.interactable = false;
        bouton3.interactable = false;
        bouton4.interactable = false;
        boutonHelp.gameObject.SetActive(false);
        Score.SetActive(false);
        helpPannel.SetActive(true);

        TimerOn = false;
    }

   

    public void helpClose()
    {
        bouton1.interactable = true;
        bouton2.interactable = true;
        bouton3.interactable = true;
        bouton4.interactable = true;
        boutonHelp.gameObject.SetActive(true);
        Score.SetActive(true);
        helpPannel.SetActive(false);

        TimerOn = true;
    }
}