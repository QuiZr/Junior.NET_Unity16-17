using UnityEngine;
using UnityEngine.SceneManagement;

public class Restarter : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Get the name of the current scene and reload it.
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
