using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelButton : MonoBehaviour
{
    public void OnClick()
    {
        Debug.Log(Timer.prevScene);
        Timer.NextLevel(Timer.prevScene);
    }
}
