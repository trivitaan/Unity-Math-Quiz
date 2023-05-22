using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Timer : MonoBehaviour
{
    public GameObject gagal, sukses;
    public Text timerText, scoreText, checkScore;
    private float currentTime;
    public static bool gameActive;
    public static string currentOperation;
    
    public static string prevScene;


    private static readonly Dictionary<string, string> sceneMap = new Dictionary<string, string>
    {
        { "kurang", "subtraction" },
        { "tambah", "addition" },
        { "kali", "multiplication" },
        { "bagi", "division" },
        { "hitung", "count" },
        { "banding", "comparison" },
    };

    private void Start()
    {
        gameActive = true;
        currentOperation = sceneMap[SceneMan.prevScene.ToString()];
        currentTime = 15f;
        prevScene = SceneMan.prevScene.ToString();

    }

    private void Update()
    {
        if (gameActive)
        {
            currentTime -= Time.deltaTime;
            timerText.text = currentTime.ToString("0");
            scoreText.text = PlayerPrefs.GetInt(currentOperation + "Score", 0).ToString();
            if (currentTime <= 0f)
                GameOver();
        }
    }

    public void StopCountdown(bool answerCorrect)
    {
        gameActive = false;
        if (answerCorrect)
            sukses.SetActive(true);
            checkScore.text = PlayerPrefs.GetInt(currentOperation + "Score", 0).ToString();
    }

    public static void CheckAnswer(int correctAnswer, Button clickedButton, Text AnswerText)
    {
        bool IsCorrect = int.Parse(clickedButton.GetComponentInChildren<Text>().text) == correctAnswer;
        AnswerText.GetComponentInChildren<Text>().text = clickedButton.GetComponentInChildren<Text>().text;
        if (IsCorrect)
        {
            LevelCompletedSuccessfully(currentOperation);
            Timer timer = FindObjectOfType<Timer>();
            timer.StopCountdown(true);
        }
        else
        {
            Timer timer = FindObjectOfType<Timer>();
            timer.GameOver();
        }
    }

    public static void CheckAnswerBanding(Button clickedButton, Text AnswerText, string correctAnswer)
    {
        bool IsCorrect = clickedButton.GetComponentInChildren<Text>().text == correctAnswer;
        AnswerText.GetComponentInChildren<Text>().text = clickedButton.GetComponentInChildren<Text>().text;
        if (IsCorrect)
        {
            LevelCompletedSuccessfully(currentOperation);
            Timer timer = FindObjectOfType<Timer>();
            timer.StopCountdown(true);
        }
        else
        {
            Timer timer = FindObjectOfType<Timer>();
            timer.GameOver();
        }
    }

    public static void NextLevel(string prevScene)
    {
        SceneManager.LoadScene(prevScene);
    }

    public void GameOver()
    {
        gameActive = false;
        timerText.text = "0";
        gagal.SetActive(true);
    }

    public static void LevelCompletedSuccessfully(string currentOperation)
    {
        int scoreToAdd = 50;
        PlayerPrefs.SetInt(currentOperation + "Score", PlayerPrefs.GetInt(currentOperation + "Score", 0) + scoreToAdd);
    }
}
