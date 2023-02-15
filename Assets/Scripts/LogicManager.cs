using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicManager : MonoBehaviour
{

    void Start()
    {
        Timer.gameActive = true;
    }

    public static void StartCalculation(int a, int b, Button[] answerButtons, Text answerText)
    {
        int hasil;

        
        if (SceneMan.prevScene == "tambah")
        {

            hasil = a+b;

            Debug.Log("correct " + hasil);
            int[] randomNumbers = GenerateRandomNumbers(answerButtons.Length, hasil, answerButtons);
            
            // Assign random numbers to buttons
            for (int i = 0; i < answerButtons.Length; i++)
            {
                int capturedIndex = i;
                answerButtons[i].onClick.AddListener(() => Timer.CheckAnswer(hasil, answerButtons[capturedIndex], answerText));
                answerButtons[i].GetComponentInChildren<Text>().text = randomNumbers[i].ToString();
                
            }

        }
        else if (SceneMan.prevScene == "kurang")
        {

            hasil = Mathf.Abs(a-b);

            Debug.Log("correct " + hasil);
            int[] randomNumbers = GenerateRandomNumbers(answerButtons.Length, hasil, answerButtons);
            
            // Assign random numbers to buttons
            for (int i = 0; i < answerButtons.Length; i++)
            {
                int capturedIndex = i;
                answerButtons[i].onClick.AddListener(() => Timer.CheckAnswer(hasil, answerButtons[capturedIndex], answerText));
                answerButtons[i].GetComponentInChildren<Text>().text = randomNumbers[i].ToString();
                
            }

        }
        else if (SceneMan.prevScene == "kali")
        {

            hasil = Mathf.Abs(a*b);

            Debug.Log("correct " + hasil);
            int[] randomNumbers = GenerateRandomNumbers(answerButtons.Length, hasil, answerButtons);
            
            // Assign random numbers to buttons
            for (int i = 0; i < answerButtons.Length; i++)
            {
                int capturedIndex = i;
                answerButtons[i].onClick.AddListener(() => Timer.CheckAnswer(hasil, answerButtons[capturedIndex], answerText));
                answerButtons[i].GetComponentInChildren<Text>().text = randomNumbers[i].ToString();
                
            }

        }
        else if (SceneMan.prevScene == "bagi")
        {
            float hasilBagi = a/b;

            hasil = Mathf.RoundToInt(hasilBagi);

            Debug.Log("correct " + hasil);
            int[] randomNumbers = GenerateRandomNumbers(answerButtons.Length, hasil, answerButtons);
            
            // Assign random numbers to buttons
            for (int i = 0; i < answerButtons.Length; i++)
            {
                int capturedIndex = i;
                answerButtons[i].onClick.AddListener(() => Timer.CheckAnswer(hasil, answerButtons[capturedIndex], answerText));
                answerButtons[i].GetComponentInChildren<Text>().text = randomNumbers[i].ToString();
                
            }

        }
        
    }

    private static int[] GenerateRandomNumbers(int count, int answer, Button[] button)
    {

        int[] numbers = new int[count];
        numbers[0] = answer;
        for (int i = 1; i < count; i++)
        {
            numbers[i] = Random.Range(1, answer+17);
        }

        //put correct answer into the list of numbers generated
        ShuffleArray(numbers);
        return numbers;
    }

    private static void ShuffleArray(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            int randomIndex = Random.Range(0, array.Length);
            int temp = array[i];
            array[i] = array[randomIndex];
            array[randomIndex] = temp;
        }
    }

    
}
