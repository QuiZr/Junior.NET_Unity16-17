using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

// Script that button hooks into
public class MainMenuButtonNewGame : MonoBehaviour
{
    public int sceneToLoad = 1;

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
