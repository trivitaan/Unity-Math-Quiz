using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelButton : MonoBehaviour
{
    public void OnClick()
    {
        Debug.Log(SceneMan.prevScene);
        Timer.NextLevel(SceneMan.prevScene);
        //add function to move the level selection's position
    }

    
}
