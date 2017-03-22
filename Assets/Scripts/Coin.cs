using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour
{
    public int scoreToAdd = 1;

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Make sure that what we hit is a player
        if (collision.gameObject.tag == "Player")
        {
            // If yes then add score and destroy this gameobject.
            ScoreManager.Instance.AddScore(scoreToAdd);
            Destroy(gameObject);
        }
    }
}
