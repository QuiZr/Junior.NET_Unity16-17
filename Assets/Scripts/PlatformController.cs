using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base for any basic moving character. Requires additional component
/// like PlayerPlatformController to actually do anything.
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class PlatformController : MonoBehaviour
{
    // Public variables are shown in Unity's inspector and can be edited through it at any time
    [Tooltip("Max horizontal movement speed")]
    public float moveSpeed = 5f;

    // Same goes for private variables with SerializeField tag.
    [Tooltip("Force applied in y+ direction at jump")]
    [SerializeField]
    private int jumpForce = 300;

    public Transform groundCheckPosition;

    // Rigibody tells Unity to enable physics on this game object.
    private Rigidbody2D localRigibody;

    private bool goingLeft = true;

    void Start()
    {
        localRigibody = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Sets acceleration of a character by moveValue * moveSpeed and can make it jump.
    /// Gravity, collisions etc. are handled by Unity's physics engine (Box2D).
    /// </summary>
    /// <param name="moveValue">Multiplier of max speed</param>
    /// <param name="wantToJump">True = jump</param>
    public void Move(float moveValue, bool wantToJump)
    {
        // Make sure that our graphics are displayed in correct direction
        if ((goingLeft && moveValue > 0) || (!goingLeft && moveValue < 0))
        {
            goingLeft = !goingLeft;
            Flip();
        }

        bool canJump = false;

        // Check if there is something beneeth our foot
        Collider2D[] hits = Physics2D.OverlapCircleAll(groundCheckPosition.position, 0.1f);
        foreach (Collider2D collider in hits)
        {
            if (collider.gameObject != gameObject)
            {
                // If there is, and that something is not us then we're
                // standing on something! 
                canJump = true;
                break;
            }
        }

        // Jump
        if (wantToJump && canJump)
        {
            localRigibody.AddForce(new Vector2(0, jumpForce));
        }

        // Horizontal movement.
        float newHorizontalVelocity = moveValue * moveSpeed;
        Vector2 newVelocity = new Vector2(newHorizontalVelocity, localRigibody.velocity.y);
        localRigibody.velocity = newVelocity;
    }

    /// <summary>
    /// Flip the player GameObject so that we won't have to
    /// make 2 sets of animations for different rotation.
    /// </summary>
    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
