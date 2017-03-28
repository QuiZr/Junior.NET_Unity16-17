using UnityEngine;
using System.Collections;

/// <summary>
/// Singleton for managing score.
/// </summary>
public class ScoreManager : Singleton<ScoreManager>
{
    // Property that is publicly readable and can be set only by
    // ScoreMenager itself.
    public int Score { get; private set; }

    public void AddScore(int score)
    {
        Score += score;
    }
}
