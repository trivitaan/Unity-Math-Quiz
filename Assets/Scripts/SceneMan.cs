using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMan : MonoBehaviour
{
     public GameObject ExitPanel;
     public static string prevScene;

     public void StartGame()
     {
          SceneManager.LoadScene("mainMenu");
     }
     
     public void OpenPanel()
     {
          if(ExitPanel != null)
          {
               bool isActive = ExitPanel.activeSelf;
               ExitPanel.SetActive(!isActive);
          }
     }
     
     public void QuitGame()
     {
          Application.Quit();
          Debug.Log("APP CLOSED");
     }
     
     public void Counting()
     {
          SceneManager.LoadScene("hitung");
     }
     
     public void Comparison()
     {
          SceneManager.LoadScene("banding");
     }
     
     public void Substraction()
     {
          SceneManager.LoadScene("kurang");
     }
     
     public void Addition()
     {
          SceneManager.LoadScene("tambah");
     }
     
     public void Division()
     {
          SceneManager.LoadScene("bagi");
     }
     
     public void Multiplication()
     {
          SceneManager.LoadScene("kali");
     }
     
     public void EnterArena()
     {
          prevScene = SceneManager.GetActiveScene().name;
          SceneManager.LoadScene("gameArea");
     }
     
     public void BackToMain()
     {
          SceneManager.LoadScene("mainMenu");
     }
}
