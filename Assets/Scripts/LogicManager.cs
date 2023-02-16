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
        else if (SceneMan.prevScene == "banding")
        {

            string correctAnswer;
            if(a<b)
            {
                correctAnswer ="<";
            }else if(a>b)
            {
                correctAnswer = ">";
            }else
            {
                correctAnswer = "=";
            }

            
            char[] randomSymbols = GenerateRandomSymbols(answerButtons);
            answerText.transform.localPosition = new Vector3(25.0f, 125.0f, 0);
            // Assign random numbers to buttons
            for (int i = 0; i < answerButtons.Length; i++)
            {
                int capturedIndex = i;
                answerButtons[i].onClick.AddListener(() => Timer.CheckAnswerBanding(answerButtons[capturedIndex], answerText, correctAnswer));
                answerButtons[i].GetComponentInChildren<Text>().text = randomSymbols[i].ToString();
                
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

    private static char[] GenerateRandomSymbols(Button[] buttons)
    {
        char[] symbols = new char[] { '>', '<', '=' }; // create an array with the two symbols
        ShuffleSymbols(symbols); // shuffle the array to randomize the placement of the symbols

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponentInChildren<Text>().text = symbols[i % symbols.Length].ToString();
            // assign the symbols to the buttons in a repeating pattern
        }

        return symbols;
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

    private static void ShuffleSymbols<T>(T[] array)
    {
        int n = array.Length;
        for (int i = 0; i < n - 1; i++)
        {
            int j = UnityEngine.Random.Range(i, n);
            T temp = array[j];
            array[j] = array[i];
            array[i] = temp;
        }
    }
}
