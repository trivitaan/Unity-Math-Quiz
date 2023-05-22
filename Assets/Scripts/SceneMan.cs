using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMan : MonoBehaviour
{
    public GameObject ExitPanel;
    public static string prevScene;

    public void StartGame()
    {
        LoadScene("mainMenu");
    }

    public void OpenPanel()
    {
        if (ExitPanel != null)
        {
            ExitPanel.SetActive(!ExitPanel.activeSelf);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("APP CLOSED");
    }

    public void Counting() => LoadScene("hitung");
    public void Comparison() => LoadScene("banding");
    public void Substraction() => LoadScene("kurang");
    public void Addition() => LoadScene("tambah");
    public void Division() => LoadScene("bagi");
    public void Multiplication() => LoadScene("kali");
    public void EnterArena()
    {
        prevScene = SceneManager.GetActiveScene().name;
        LoadScene("gameArea");
    }

    public void BackToMain() => LoadScene("mainMenu");
    
    public void ClearAllData()
    {
        PlayerPrefs.DeleteAll();
    }

    private void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
