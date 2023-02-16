using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Question : MonoBehaviour
{
    public Button[] answerButtons;
    public Text answerText;
    public GameObject[] questionObjects;
    public Sprite[] questionItems;
    public Sprite[] hitungItems;
    public Canvas canvas;
    public string numberText;

    string qustionNum, qustionNum1;
    GameObject newQuestion, newQuestion1;
    Sprite questionItem, questionItem1;
    int numberFromImage, numberFromImage1;

    void Start()
    {
        LoadQuestions();
    }

    void LoadQuestions()
    {

        LoadSprite();
        
    }

    void LoadBothSPrites()
    {
        
        for(int i = 0; i < 2; i++)
        {
            int arrayIndex = Random.Range(0, questionItems.Length-1);
            int arrayIndex1 = arrayIndex;
            while(arrayIndex == arrayIndex1)
            {
                arrayIndex1 = Random.Range(0, questionItems.Length-1);
            }

            if(i==0)
            {
                    questionItem = questionItems[arrayIndex];
                    qustionNum = questionItem.name;
                    newQuestion = Instantiate(questionObjects[0]);
                    newQuestion.GetComponent<SpriteRenderer>().sprite = questionItem;
                    newQuestion.name = qustionNum.Substring(0, 1);
                    numberFromImage = int.Parse(newQuestion.name);
                    //set position on canvas
                    newQuestion.transform.SetParent(canvas.transform);
                    newQuestion.GetComponent<RectTransform>().localPosition = new Vector3(-170,270,0);
                    newQuestion.GetComponent<RectTransform>().sizeDelta = new Vector2(100,100);
                    newQuestion.GetComponent<SpriteRenderer>().sortingOrder = 1;
                    newQuestion.transform.localScale = new Vector3(45f, 45f, 0f);
                    //scale prefab
                    RectTransform rectTransform = newQuestion.GetComponent<RectTransform>();
                    rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
                    rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
                    
                    //Debug.Log(numberFromImage);
            }
            else if(i == 1)
            {
                    questionItem1 = questionItems[arrayIndex1];
                    qustionNum1 = questionItem1.name;
                    newQuestion1 = Instantiate(questionObjects[1]);
                    newQuestion1.name = qustionNum1.Substring(0, 1);
                    numberFromImage1 = int.Parse(newQuestion1.name);
                    //set position on canvas
                    newQuestion1.transform.SetParent(canvas.transform);
                    newQuestion1.GetComponent<RectTransform>().localPosition = new Vector3(-170,270,0);
                    newQuestion1.GetComponent<RectTransform>().sizeDelta = new Vector2(100,100);
                    newQuestion1.GetComponent<SpriteRenderer>().sortingOrder = 1;
                    newQuestion1.transform.localScale = new Vector3(45f, 45f, 0f);
                    //scale prefab
                    RectTransform rectTransform = newQuestion1.GetComponent<RectTransform>();
                    rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
                    rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
                    newQuestion1.GetComponent<RectTransform>().localPosition = new Vector3(-170,-270,0);
                    
                    newQuestion1.GetComponent<SpriteRenderer>().sprite = questionItem1;
                    
                    //Debug.Log(numberFromImage1);
            }

        }

        if(SceneMan.prevScene == "kurang")
        {
            if(numberFromImage < numberFromImage1)
            {
                //Swap positions of the two sprites
                Vector3 tempPos = newQuestion.GetComponent<RectTransform>().localPosition;
                newQuestion.GetComponent<RectTransform>().localPosition = newQuestion1.GetComponent<RectTransform>().localPosition;
                newQuestion1.GetComponent<RectTransform>().localPosition = tempPos;
            }
        }
        if(SceneMan.prevScene == "banding")
        {
            LogicManager.StartCalculation(numberFromImage, numberFromImage1, answerButtons, answerText);

        }else
        {
            LogicManager.StartCalculation(numberFromImage, numberFromImage1, answerButtons, answerText);
        }

    }

    void LoadSprite()
    {
        
        if(SceneMan.prevScene == "hitung")
        {
            LoadSpriteHitung();
        }else if(SceneMan.prevScene == "banding")
        {
            LoadSpriteBanding();
        }else
        {
            LoadBothSPrites();
        }
    }

    void LoadSpriteBagi()
    {
        
    }

    void LoadSpriteHitung()
    {

    }

    void LoadSpriteBanding()
    {
        LoadBothSPrites();
        newQuestion.GetComponent<RectTransform>().localPosition = new Vector3(0, 360, 0); //spawn question in the middle (new position)
        newQuestion1.GetComponent<RectTransform>().localPosition = new Vector3(0, -360, 0);
    }
    
}
