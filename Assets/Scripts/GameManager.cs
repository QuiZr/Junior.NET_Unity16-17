using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private int currentLevelNumber = 1;

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(++currentLevelNumber);
    }
}
