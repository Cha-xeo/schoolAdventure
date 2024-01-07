using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using SchoolAdventure.Audio;

public class FindGame : MonoBehaviour
{
    [SerializeField] private Camera maincamera;
    [SerializeField] AudioClip[] findAnimal;
    //AudioSource audiosource;
    public AudioClip clip;
    public TextMeshProUGUI changeText;
    public TextMeshProUGUI score;
    public int points = 0;
    public string[] animals = {"Cat", "Dog", "Fox", "Lion", "Monkey", "Squirrel"};

    [SerializeField] public Image Background;
    [SerializeField] public Sprite[] levelSprite;

    public int lvl;
    public GameObject errorHit;

    public float[][] coord;
    public float[][] coord0 = {
        new float[] {3.92f, 7.25f, -6.57f, -2.91f},
        new float[] {-0.23f, 3.63f, -6.34f, -2.61f},
        new float[] {-7.09f, -1.99f, -7.61f, -3.69f},
        new float[] {-17.19f, -11.11f, -8.27f, -3.86f},
        new float[] {8.99f, 13.24f, 0.92f, 4.61f},
        new float[] {12.16f, 16.18f, -4.87f, -1.54f},
    };
    public float[][] coord1 = {
        new float[] {-3.43f, -0.13f, -7.35f, -3.53f},
        new float[] {-7.12f, -3.56f, -7.35f, -3.27f},
        new float[] {6.14f, 11.27f, -7.88f, -3.79f},
        new float[] {14.54f, 18.63f, -6.63f, -2.12f},
        new float[] {-9.67f, -6.75f, -0.40f, 3.10f},
        new float[] {5.88f, 9.44f, -2.22f, 0.95f},
    };
    public float[][] coord2 = {
        new float[] {13.76f, 17.45f, -7.16f, -3.43f},
        new float[] {-2.78f, 1.11f, -7.55f, -3.14f},
        new float[] {4.44f, 9.71f, -2.22f, 1.67f},
        new float[] {-18.66f, -14.71f, -5.88f, -0.88f},
        new float[] {-11.54f, -8.46f, 6.14f, 9.38f},
        new float[] {11.27f, 13.37f, -0.16f, 2.88f},
    };
    public float[][] coord3 = {
        new float[] {-3.73f, -0.26f, -9.28f, -5.92f},
        new float[] {8.99f, 12.45f, -9.28f, -5.39f},
        new float[] {1.31f, 5.98f, -9.31f, -5.36f},
        new float[] {-3.50f, 1.05f, -2.09f, 1.34f},
        new float[] {14.05f, 17.45f, 6.39f, 9.48f},
        new float[] {-16.67f, -11.80f, -6.37f, -2.19f},
    };
    public int rand;
    public int last_rand = -1;
    // Start is called before the first frame update
    void Start()
    {
        lvl = Random.Range(0, 4);
        Background.sprite = levelSprite[lvl];
        //Debug.Log("Level : " + lvl);
            if (lvl == 0)
                coord = coord0;
            if (lvl == 1)
                coord = coord1;
            if (lvl == 2)
                coord = coord2;
            if (lvl == 3)
                coord = coord3;
        Start_Game();
    }

    void Start_Game()
    {
        rand = Random.Range(0, 6);
        while (rand == last_rand) {
            rand = Random.Range(0, 6);
        }
        last_rand = rand;
        string find = animals[rand];
        string inst = "Where is the " + find + " ?\n";

        //audiosource = GetComponent<AudioSource>();

        clip = findAnimal[rand];
        changeText.text = inst;
        SoundManagerV2.Instance.PlaySound(clip);
        //audiosource.PlayOneShot(clip);
    }

    public void GoBack()
    {
        SceneManager.LoadScene("FindGameMenu");
    }
    // Update is called once per frame
    void Update()
    {
        float mouseX = 0;
        float mouseY = 0;

        if (InputManager.GetInstance().GetLeftMousePressed()) {
            //Vector3 mousePos = maincamera.ScreenToWorldPoint(Input.mousePosition);
            Vector3 mousePos = InputManager.GetInstance().GetMousePosition();
            mouseX = mousePos.x;
            mouseY = mousePos.y;
            //Debug.Log("X: " + mousePos.x + "\nY: " + mousePos.y);
            if ((mouseX >= coord[rand][0] && mouseX <= coord[rand][1] && mouseY >= coord[rand][2] && mouseY <= coord[rand][3])) {
                points += 1;
                score.text = "Points : " + points.ToString();
                Start_Game();
            } else {
                StartCoroutine(ShowCanvasCoroutine(0.1f));
            }
        }
    }
    private IEnumerator ShowCanvasCoroutine(float duration)
    {
        errorHit.SetActive(true);
        yield return new WaitForSeconds(duration);
        errorHit.SetActive(false);
    }
}
