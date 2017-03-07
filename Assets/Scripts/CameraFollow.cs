﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Reference to the player game object
    public GameObject player;

    // Offset distance between the player and camera
    private Vector3 offset;

    void Start()
    {
        //Calculate and store the offset value by getting 
        // the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be 
        // the same as the player's, but offset by the calculated offset distance.
        transform.position = new Vector3(
            player.transform.position.x + offset.x,
            transform.position.y,
            transform.position.z
            );
    }
}
