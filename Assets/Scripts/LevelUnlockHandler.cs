using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelUnlockHandler : MonoBehaviour
{
    [SerializeField] Button[] buttons;
    [SerializeField] int score;
    int unlockedLevelsNumber;
    public Text playerScore;

    private string activeSceneName;

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
        activeSceneName = sceneMap[SceneManager.GetActiveScene().name];
        playerScore.text = PlayerPrefs.GetInt(activeSceneName + "Score", 0).ToString();
        //Debug.Log(PlayerPrefs.GetInt(activeSceneName + "Score", 0));
        Debug.Log(activeSceneName);

        if(!PlayerPrefs.HasKey("levelsUnlocked"))
        {
            PlayerPrefs.SetInt("levelsUnlocked", 1);
        }

        unlockedLevelsNumber = PlayerPrefs.GetInt("levelsUnlocked");
        Debug.Log("unlockedLevelsNumber : " + unlockedLevelsNumber);
        for(int i = 1; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }
        buttons[0].interactable = true;
    }

    // Update is called once per frame
    void Update()
    {
        int currentScore = PlayerPrefs.GetInt(activeSceneName + "Score", 0);
        int unlockedLevelsNumber = PlayerPrefs.GetInt("levelsUnlocked", 1); // Use the same variable name as the class field
        //Debug.Log("Current Score : " + currentScore);
        int buttonsToUnlock = Mathf.FloorToInt(currentScore / 80f);

        // Unlock buttons one by one
        for (int i = 0; i <= buttonsToUnlock; i++)
        {
            buttons[i].interactable = true;
            PlayerPrefs.SetInt("levelsUnlocked", i + 1);
        }
    }
}
