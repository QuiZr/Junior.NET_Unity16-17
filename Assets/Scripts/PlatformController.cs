using UnityEngine;
using System.Collections;

/// <summary>
/// This whole class will be splitted into two separate ones.
/// PlatformController will be responsible for actually moving the 
/// character but not for receiving input.
/// </summary>
public class PlatformController : MonoBehaviour
{
    // Public variables are shown in Unity's inspector and can be edited through it at any time
    [Tooltip("Max horizontal movement speed")]
    public int maxMoveSpeed = 5;

    // Same goes for private variables with SerializeField tag.
    [Tooltip("Force applied in y+ direction at jump")]
    [SerializeField]
    private int jumpForce = 40;

    // Rigibody tells Unity to enable physics on this game object.
    private Rigidbody2D thisRigidbody;

    private bool hasJumped = false;

    // FixedUpdate executes at every PHYSICAL frame.
    void FixedUpdate()
    {
        // We're moving character every physical frame because we're using Unity physics.
        // Always remember to deal with physics in FixedUpdate.
        Move(0, hasJumped);
    }

    // Update executes at every GRAPHICAL frame.
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            hasJumped = true;
        }
    }

    // Use this for initialization (executes at object spawn).
    void Start()
    {
        thisRigidbody = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Will Sets acceleration of a character by moveValue * moveSpeed and can make it jump.
    /// Gravity, collisions etc. are handled by Unity's physics engine (Box2D).
    /// </summary>
    /// <param name="moveValue">Multiplier of max speed</param>
    /// <param name="wantToJump">True = jump</param>
    public void Move(float moveValue, bool wantToJump)
    {
        if (wantToJump)
        {
            hasJumped = false;
            thisRigidbody.AddForce(new Vector2(0, jumpForce));
        }
    }
}
