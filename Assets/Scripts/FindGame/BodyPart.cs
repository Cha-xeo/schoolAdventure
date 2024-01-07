using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using SchoolAdventure.Audio;

public class BodyPart : MonoBehaviour
{
    [SerializeField] AudioClip[] bodyVoice;
    [SerializeField] private Camera maincamera;
    //AudioSource audiosource;
    public AudioClip clip;
    public TextMeshProUGUI changeText;
    public TextMeshProUGUI score;
    public int points = 0;
    public GameObject errorHit;

    public string[] body = {"Head", "Eyes", "Nose", "Mouth", "Shoulder", "Elbow", "Hand", "Leg", "Knee", "Foot"};
    public float[][] coord1 = {
        new float[] {0.97f, 2.61f, 2.86f, 4.29f},// Head
        new float[] {1.29f, 1.88f, 3.31f, 3.48f},// Eyes
        new float[] {1.44f, 1.67f, 3.15f, 3.43f},// Nose
        new float[] {1.42f, 1.88f, 2.94f, 3.18f},// Mouth
        new float[] {1.18f, 3.37f, 1.84f, 2.62f},// Shoulder
        new float[] {0.82f, 1.44f, 0.73f, 1.42f},// Elbow
        new float[] {-0.29f, 0.60f, -0.47f, 0.23f},// Hand
        new float[] {0.87f, 2.93f, -2.23f, -0.28f},// Leg
        new float[] {0.81f, 3.01f, -2.60f, -1.81f},// Knee
        new float[] {0.21f, 3.08f, -4.61f, -3.72f},// Foot
    };

    public float[][] coord2 = {
        new float[] {0.97f, 2.61f, 2.86f, 4.29f},// Head
        new float[] {1.29f, 1.88f, 3.31f, 3.48f},// Eyes
        new float[] {1.44f, 1.67f, 3.15f, 3.43f},// Nose
        new float[] {1.42f, 1.88f, 2.94f, 3.18f},// Mouth
        new float[] {1.18f, 3.37f, 1.84f, 2.62f},// Shoulder
        new float[] {2.75f, 3.53f, 0.67f, 1.33f},// Elbow
        new float[] {2.35f, 2.95f, -0.81f, -0.21f},// Hand
        new float[] {0.87f, 2.93f, -2.23f, -0.28f},// Leg
        new float[] {0.81f, 3.01f, -2.60f, -1.81f},// Knee
        new float[] {0.21f, 3.08f, -4.61f, -3.72f},// Foot
    };

    public int rand;
    public int last_rand = -1;
    // Start is called before the first frame update
    void Start()
    {
        rand = Random.Range(0, 10);
          while (rand == last_rand) {
            rand = Random.Range(0, 10);
        }
        last_rand = rand;
        string part = body[rand];
        string inst = "Find :\n" + part;

        //audiosource = GetComponent<AudioSource>();

        clip = bodyVoice[rand];
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
        double mouseX = 0;
        double mouseY = 0;

        if (InputManager.GetInstance().GetLeftMousePressed())
        {
            //Vector3 mousePos = maincamera.ScreenToWorldPoint(Input.mousePosition);
            Vector3 mousePos = InputManager.GetInstance().GetMousePosition();
            mouseX = mousePos.x;
            mouseY = mousePos.y;
            //Debug.Log("X: " + mousePos.x + "\nY: " + mousePos.y);
            if ((mouseX >= coord1[rand][0] && mouseX <= coord1[rand][1] && mouseY >= coord1[rand][2] && mouseY <= coord1[rand][3]) ||
            (mouseX >= coord2[rand][0] && mouseX <= coord2[rand][1] && mouseY >= coord2[rand][2] && mouseY <= coord2[rand][3])) {
                points += 1;
                score.text = "Points : " + points.ToString();
                Start();
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
