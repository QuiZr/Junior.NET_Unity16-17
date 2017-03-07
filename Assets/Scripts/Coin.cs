using UnityEngine;
using System.Collections;

/// <summary>
/// This class will increment score on ScoreManager by scoreToAdd 
/// when OnTriggerEnter2D triggers.
/// </summary>
public class Coin : MonoBehaviour
{
    public int scoreToAdd = 1;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ScoreManager.Instance.AddScore(scoreToAdd);

            // Destroys a whole gameobject that this scipt is attached to.
            Destroy(gameObject);
        }
    }
}
