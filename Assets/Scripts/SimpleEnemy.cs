using UnityEngine;
using System.Collections;

/// <summary>
/// This class is a simple ai that moves back and forth.
/// </summary>
[RequireComponent(typeof(PlatformController))]
public class SimpleEnemy : MonoBehaviour
{
    // Public field for setting cooldown
    public float turnCd = 0.5f;

    // Current cd
    private float currentTurnCd;

    private PlatformController controller;

    // Direction that player moves in
    private int direction = -1;

    void Start()
    {
        controller = GetComponent<PlatformController>();
        currentTurnCd = turnCd;
    }

    void Update()
    {
        // Count passing time
        currentTurnCd -= Time.deltaTime;
        if (currentTurnCd <= 0)
        {
            direction *= -1;
            currentTurnCd = turnCd;
        }

        controller.Move(direction, false);
    }
}
