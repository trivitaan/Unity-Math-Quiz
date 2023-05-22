using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionSpawn : MonoBehaviour
{
    public Sprite[] countObjects;
    Sprite countObjectSprite;
    public Canvas canvas;
    public GameObject questionPrefab;
    int amountOfObjects;
    GameObject newCountObj;
    Sprite countItem;

    void Start()
    {
        amountOfObjects = Random.Range(0, 9);
    }

    public void LoadSpriteHitung()
    {
        for(int i = 0; i < countObjects.Length-1; i++)
        {
            
            {
                    countItem = countObjects[i];
                    newCountObj = Instantiate(questionPrefab);
                    newCountObj.GetComponent<SpriteRenderer>().sprite = countItem;
                    //set position on canvas
                    newCountObj.transform.SetParent(canvas.transform);
                    newCountObj.GetComponent<RectTransform>().localPosition = new Vector3(-170,270,0);
                    newCountObj.GetComponent<RectTransform>().sizeDelta = new Vector2(100,100);
                    newCountObj.GetComponent<SpriteRenderer>().sortingOrder = 1;
                    newCountObj.transform.localScale = new Vector3(45f, 45f, 0f);
                    //scale prefab
                    RectTransform rectTransform = newCountObj.GetComponent<RectTransform>();
                    rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
                    rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
                    
                    //Debug.Log(numberFromImage);
            }

        }
    }
}

