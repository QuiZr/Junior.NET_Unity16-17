using UnityEngine;
using System.Collections;

/// <summary>
/// Singleton for managing score.
/// </summary>
public class ScoreManager : MonoBehaviour
{
    // This is a simple singleton pattern example.
    // You can read more about it here:
    // http://wiki.unity3d.com/index.php/Singleton
    // Basically it's a class that only one instance of should be initialized
    // at a time, and that instance can be accesed by a static property.
    public static ScoreManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ScoreManager>();

                if (instance == null)
                {
                    throw new System.Exception("ScoreMenager was not found on the scene.");
                }
            }

            return instance;
        }
    }
    private static ScoreManager instance;

    // Property that is publicly readable and can be set only by
    // ScoreMenager itself.
    public int Score { get; private set; }

    public void AddScore(int score)
    {
        Score += score;
    }
}
