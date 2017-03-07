using UnityEngine;
using System.Collections;

public class PlayerPlatformController : MonoBehaviour
{
    private PlatformController controller;
    private bool hasJumped = false;

    void Start()
    {
        controller = GetComponent<PlatformController>();
    }

    // FixedUpdate executes at every PHYSICAL frame.
    void FixedUpdate()
    {
        float moveValue = Input.GetAxis("Horizontal"); 
        // We're moving character every physical frame because we're using Unity physics.
        // Always remember to deal with physics in FixedUpdate.
        controller.Move(moveValue, hasJumped);
        hasJumped = false;
    }

    // Update executes at every GRAPHICAL frame.
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            hasJumped = true;
        }
    }
}
