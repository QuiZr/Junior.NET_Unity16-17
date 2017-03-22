using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // Hook to ui element
    public Text scoreDisplayText;

    // Field that can be read globally but only changed
    // from inside ScoreManager.
    public int Score { get; private set; }

    // This is an example of singleton patttern - class that 
    // can only have one instance of it instantiated at a time.
    // More info: http://wiki.unity3d.com/index.php/Singleton
    public static ScoreManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<ScoreManager>();
                if (_instance == null)
                    throw new System.Exception("ScoreManager was not found on this scene.");
            }

            return _instance;
        }
    }
    private static ScoreManager _instance;

    /// <summary>
    /// Add score. In future this class can also take powerups
    /// i.e. score 3x in mind.
    /// </summary>
    /// <param name="scoreToAdd">Base score value to add</param>
    public void AddScore(int scoreToAdd)
    {
        Score += scoreToAdd;
        //Debug.Log("Current score: " + Score);
        scoreDisplayText.text = "Score: " + Score;
    }
}
