using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public GameObject[] helixRings;
    public GameObject gameOverPanel;
    public GameObject levelCompletePanel;
    public GameObject gamePlayPanel;
    public GameObject menuPanel;

    public static int currentLevelIndex;
    public TextMeshProUGUI currentLevelText;
    public TextMeshProUGUI nextLevelText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public Slider progressSlider;

    public float ySpawn = 0;
    public float ringDis = 5;
    public int numberofRings;

    public static bool gameOver;
    public static bool levelCompleted;
    public static bool isGameStarted;
    public static bool mute =false;
    public static int numberOfPassedRing;
    public static int score = 0;
    public CharacterSelector character;
    public CameraFollow cam;
    // Start is called before the first frame update
    private void Awake()
    {
        currentLevelIndex = PlayerPrefs.GetInt("CurrentLevelIndex", 1);
    }
    void Start()
    {
        Time.timeScale = 1;
        numberofRings = currentLevelIndex +5;
        numberOfPassedRing = 0;
        highScoreText.text = "Best Score\n" + PlayerPrefs.GetInt("HighScore", 0);
        isGameStarted = gameOver = levelCompleted = false;
        for(int i =0; i < numberofRings; i++)
        {
            if (i == 0)
                SpawnRings(0);
            else
                SpawnRings(Random.Range(0, helixRings.Length - 1));
        }
        SpawnRings(helixRings.Length - 1);
        if(currentLevelIndex >=5)
        {
            character.MultipleBall();
        }
        cam.GetComponent<CameraFollow>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        //update the UI
        currentLevelText.text = currentLevelIndex.ToString();
        nextLevelText.text = (currentLevelIndex +1).ToString();

        int progress = numberOfPassedRing * 100 / numberofRings;
        progressSlider.value = progress;

        scoreText.text = score.ToString();

        if(Input.GetMouseButtonDown(0) && !isGameStarted)
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;
            isGameStarted = true;
            gamePlayPanel.SetActive(true);
            menuPanel.SetActive(false);
        }

        //if game is Over
        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
            if(Input.GetButtonDown("Fire1"))
            {
                if(score > PlayerPrefs.GetInt("HighScore", 0))
                {
                    PlayerPrefs.SetInt("HighScore", score);
                }
                score = 0;
                SceneManager.LoadScene("Level");
            }
        }
        //check if the level iscompleted
        if (levelCompleted)
        {
            Time.timeScale = 0;
            levelCompletePanel.SetActive(true);
            if (Input.GetButtonDown("Fire1"))
            {
                if (score > PlayerPrefs.GetInt("HighScore", 0))
                {
                    PlayerPrefs.SetInt("HighScore", score);
                }
                PlayerPrefs.SetInt("CurrentLevelIndex", currentLevelIndex+1);
                SceneManager.LoadScene("Level");
            }
        }
    }
    //spawn the Rings here under the Gamemanager GameObject
    public void SpawnRings(int ringIndex)
    {
        GameObject go =Instantiate(helixRings[ringIndex], transform.up * ySpawn, Quaternion.identity);
        go.transform.parent = transform;
        ySpawn -= ringDis;
    }
}
