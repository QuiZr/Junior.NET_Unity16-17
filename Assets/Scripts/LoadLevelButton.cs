using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadLevelButton : MonoBehaviour
{
    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }
}
