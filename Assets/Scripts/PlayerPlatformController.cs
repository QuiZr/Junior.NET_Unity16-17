using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player controlls for PlatformController.
/// </summary>
// Unity will make sure that PlatformController will be attached to this game object.
[RequireComponent(typeof(PlatformController))]
public class PlayerPlatformController : MonoBehaviour
{
    private PlatformController thisController;
    private bool hasJumped = false;

    // Use this for initialization (executes at object spawn).
    void Start()
    {
        thisController = GetComponent<PlatformController>();
    }

    // Update executes at every GRAPHICAL frame.
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            hasJumped = true;
        }
    }

    // FixedUpdate executes at every PHYSICAL frame.
    void FixedUpdate()
    {
        // Axis are defined in Unity's editor: Edit -> Project Settings -> Input
        float x = Input.GetAxis("Horizontal");

        // We're moving character every physical frame because we're using Unity physics.
        // Always remember to deal with physics in FixedUpdate.
        thisController.Move(x, hasJumped);
        hasJumped = false;
    }
}
