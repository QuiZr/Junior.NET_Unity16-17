using UnityEngine;
using System.Collections;

public class LevelEnd : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.Instance.LoadNextLevel();
        }
    }
}
