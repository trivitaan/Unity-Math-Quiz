using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public GameObject gagal;
    public GameObject sukses;
    public Text timerText;
    private float countdownTime = 30f;
    private float currentTime;
    public static bool gameActive = true;
    public static float timeLeft;
    private static Timer timer;
    public static string prevScene;
    

    private void Start()
    {
        prevScene = (SceneMan.prevScene).ToString();
        timer = GetComponent<Timer>();
        currentTime = countdownTime;
        gameActive = true;
    }

    private void Update()
    {
        if (gameActive)
        {
            currentTime -= Time.deltaTime;
            timerText.text = currentTime.ToString("0");

            if (currentTime <= 0f)
            {
                GameOver();
            }
        }
    }

    public static void StopCountdown(bool answerCorrect)
    {
        gameActive = false;
        if(answerCorrect)
        {
            timer.sukses.SetActive(true);
        }
    }

    public static void CheckAnswerBanding(Button clickedButton, Text AnswerText, string correctAnswer)
    {
        bool IsCorrect;
        string clickedAnswer = clickedButton.GetComponentInChildren<Text>().text;
        Debug.Log(clickedAnswer);
        AnswerText.GetComponentInChildren<Text>().text = clickedAnswer.ToString();
        if (clickedAnswer == correctAnswer)
        {
            IsCorrect = true;
            Debug.Log("Correct! Score: " );
            StopCountdown(IsCorrect);
        }else
        {
            IsCorrect = false;
            Debug.Log("Incorrect");
            Timer.GameOver();
        }
    }

    public static void CheckAnswer(int correctAnswer, Button clickedButton, Text AnswerText)
    {
        bool IsCorrect;
        int clickedAnswer = int.Parse(clickedButton.GetComponentInChildren<Text>().text);
        Debug.Log(clickedAnswer);
        AnswerText.GetComponentInChildren<Text>().text = clickedAnswer.ToString();
        if (clickedAnswer == correctAnswer)
        {
            PlayerPrefs.SetInt("Score", 0);
            int currentScore = PlayerPrefs.GetInt("Score", 0);
            PlayerPrefs.SetInt("Score", currentScore += 20);
            Debug.Log("Correct! Score: " + (currentScore));
            IsCorrect = true;
            //Success();
            StopCountdown(IsCorrect);
        }
        else
        {
            IsCorrect = false;
            Debug.Log("Incorrect");
            Timer.GameOver();
            //StopCountdown(IsCorrect);
        }
    }

    private static readonly Dictionary<string, string> sceneMap = new Dictionary<string, string>
    {
        { "kurang", "kurang" },
        { "bagi", "bagi" },
        { "tambah", "tambah" },
        { "kali", "kali" },
        { "banding", "banding" },
        { "hitung", "hitung" },
    };

    public static void NextLevel(string prevScene)
    {
        if (sceneMap.TryGetValue(prevScene, out string sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    public static void GameOver()
    {
        gameActive = false;
        timer.timerText.text = "0";
        timer.gagal.SetActive(true);
    }
}
