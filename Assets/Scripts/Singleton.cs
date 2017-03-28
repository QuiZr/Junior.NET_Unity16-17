using UnityEngine;
using System.Collections;

public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    // This is a simple singleton pattern example.
    // You can read more about it here:
    // http://wiki.unity3d.com/index.php/Singleton
    // Basically it's a class that only one instance of should be initialized
    // at a time, and that instance can be accesed by a static property.
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();

                if (instance == null)
                {
                    throw new System.Exception("Scripts object was not found on the scene.");
                }
            }

            return instance;
        }
    }
    private static T instance;

    void Start()
    {
        if (Instance != null && Instance != this)
        {
            Debug.LogWarning("You have other scripts object spawned, destroying this gameobject.");
            Destroy(gameObject);
        }

        // Make sure that Unity won't destroy this gameobject on loading.
        DontDestroyOnLoad(gameObject);
    }
}
